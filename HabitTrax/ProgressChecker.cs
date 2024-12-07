using UnityEngine;
using UnityEngine.UI;

public class ProgressChecker : MonoBehaviour
{
    //Global variables for progress checking
    int totalNumberOfChecks;
    int currentCheckNumber;
    int phaseOfCurrentLogin;

    //References to the Progress and Game UI game objects
    [SerializeField] GameObject progressUI;
    [SerializeField] GameObject gameUI;

    //Method for initializing the progress checking
    public void CheckProgress(int totalNumberOfChecks, int phaseOfCurrentLogin)
    {
        //Setting the global variables based on the values passed into this constructor
        this.totalNumberOfChecks = totalNumberOfChecks;
        currentCheckNumber = 0;
        this.phaseOfCurrentLogin = phaseOfCurrentLogin;
            
        //Starting the first progress check
        CreateProgressPopUp();
    }

    //Creates a progress popup to investigate the time that is specified in the global variables
    void CreateProgressPopUp()
    {
        //Calculating the days that have passed since the currently investigated check was due
        int daysSince = phaseOfCurrentLogin + (Data.trackedHabit.GetInterval() * ((totalNumberOfChecks - 1) - currentCheckNumber));

        //Creating the messages taht will be displayed to the player (Message 1 is always the same, so there is no need to have that specified in the code)
        string message2 = Data.trackedHabit.GetName();
        string message3;
        if (daysSince == 0)
        {
            message3 = "Today?";
        }
        else if (daysSince == 1)
        {
            message3 = "Yesterday?";
        }
        else
        {
            message3 = daysSince + " days ago?";
        }

        //Setting the text of the message objects to be what was specified
        GameObject.Find("Message 2").GetComponent<Text>().text = message2;
        GameObject.Find("Message 3").GetComponent<Text>().text = message3;

        //Making the Progress UI visible, whether it was already or not
        progressUI.SetActive(true);
    }

    //Logic for starting the next Popup
    void NextPopUp()
    {
        currentCheckNumber++;

        //If the we have completed all of the checks, then we can make the Game UI visible, hide the Progress UI, and continue the game's setup
        //If not, then we create a new popup, now with currentCheckNumber incremented by 1
        if (currentCheckNumber == totalNumberOfChecks)
        {
            progressUI.SetActive(false);
            gameUI.SetActive(true);
            GetComponent<GameManager>().ContinueSetup();
        }
        else
        {
            CreateProgressPopUp();
        }
    }

    //Method that the Yes Button calls when it is pressed. Increments the streak by 1, and adds points to the user's total points
    //Starts the next popup logic at the end
    public void Yes()
    {
        Debug.Log("Woohoo!");

        Data.streak++;
        Data.totalPoints += CalculatePoints(Data.streak);

        NextPopUp();
    }

    //Method that the No Button calls when it is pressed. Resets the streak and grants no points
    //Starts the next popup logic at the end
    public void No()
    {
        Debug.Log("Aw man");

        Data.streak = 0;

        NextPopUp();
    }

    //Calulates the number of points to be added to the user's total based of their current streak amount
    int CalculatePoints(int streakLength)
    {
        return Mathf.FloorToInt(100 * Mathf.Sqrt(streakLength));
    }
}