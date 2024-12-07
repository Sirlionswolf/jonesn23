using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    GameObject player;

    [SerializeField]
    GameObject pet;

    [SerializeField]
    GameObject progressUI;

    [SerializeField]
    GameObject gameUI;

    [SerializeField]
    GameObject shopUI;

    [SerializeField]
    GameObject inventoryUI;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player.SetActive(false);
        pet.SetActive(false);

        gameUI.SetActive(false);
        shopUI.SetActive(false);
        inventoryUI.SetActive(false);

        SetData();

        int currentTime = GetCurrentSecond();
        int daysSinceLastLogin = Mathf.FloorToInt((currentTime - Data.timeOfLastLogin) / 86400);
        int passedChecks = Mathf.FloorToInt((Data.phaseOfLastLogin + daysSinceLastLogin) / Data.trackedHabit.GetInterval());
        int currentPhase = (Data.phaseOfLastLogin + daysSinceLastLogin) % Data.trackedHabit.GetInterval();

        Debug.Log("Passed CheckIns: " + passedChecks);
        Debug.Log("Current Time: " + currentTime);

        Data.timeOfLastLogin = currentTime;
        Data.phaseOfLastLogin = currentPhase;

        GetComponent<ProgressChecker>().CheckProgress(passedChecks, currentPhase);
    }

    public void ContinueSetup()
    {
        Debug.Log("Current Streak: " + Data.streak);
        Debug.Log("Current Points: " + Data.totalPoints);

        UpdateGameGUI();
        StartGameplay();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.activeSelf)
        {
            player.GetComponent<Player>().RenderTick();

            GetComponent<Placement>().RenderTick();
        }
        if (pet.activeSelf)
        {
            pet.GetComponent<Pet>().RenderTick();
        }
    }


    public int GetCurrentSecond()
    {
        DateTime epochStart = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        int currentEpochTime = (int)(DateTime.UtcNow - epochStart).TotalSeconds;

        return currentEpochTime;
    }

    void SetData()
    {
        Data.timeOfLastLogin = GetCurrentSecond() - (14 * 86400);
        Data.phaseOfLastLogin = 0;
        Data.streak = 0;
        Data.totalPoints = 0;
        Data.petHealth = 7;
        Data.trackedHabit = new Habit("Sit Ups", 1);
    }

    void StartGameplay()
    {
        player.SetActive(true);
        pet.SetActive(true);
    }

    void UpdateGameGUI()
    {
        if (gameUI.activeSelf)
        {
            string streak = "Streak: " + Data.streak;
            string points = "Total Points: " + Data.totalPoints;

            GameObject.Find("Streak").GetComponent<Text>().text = streak;
            GameObject.Find("Points").GetComponent<Text>().text = points;
        }
    }
}