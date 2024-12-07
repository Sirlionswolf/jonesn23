using UnityEngine;

public class ShopMenus : MonoBehaviour
{
    [SerializeField]
    GameObject shopUI;

    [SerializeField]
    GameObject gameUI;

    [SerializeField]
    GameObject closeButton;

    [SerializeField]
    GameObject petButton;

    [SerializeField]
    GameObject backMainButton;


    public void ResetButtons()
    {
        if (shopUI.activeSelf)
        {
            petButton.SetActive(false);
            backMainButton.SetActive(false);
            closeButton.SetActive(false);
        }
    }


    public void ShopOpen()
    {
        gameUI.SetActive(false);
        shopUI.SetActive(true);

        MainMenu();
    }

    public void ShopClose()
    {
        gameUI.SetActive(true);
        shopUI.SetActive(false);
    }


    //Indicidual Menus
    public void MainMenu()
    {
        ResetButtons();
        petButton.SetActive(true);
        closeButton.SetActive(true);
    }

    public void PetMenu()
    {
        ResetButtons();
        backMainButton.SetActive(true);
    }
}