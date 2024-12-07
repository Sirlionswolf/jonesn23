using UnityEngine;

public class InventoryMenu : MonoBehaviour
{
    [SerializeField]
    GameObject inventoryUI;

    [SerializeField]
    GameObject gameUI;

    [SerializeField]
    GameObject closeButton;

    [SerializeField]
    GameObject crateButton;

    [SerializeField]
    GameObject bedButton;

    public void InventoryOpen()
    {
        gameUI.SetActive(false);
        inventoryUI.SetActive(true);

        UpdateButtons();
    }

    public void InventoryClose()
    {
        gameUI.SetActive(true);
        inventoryUI.SetActive(false);
    }

    public void UpdateButtons()
    {
        ResetButtons();

        closeButton.SetActive(true);

        if (Player.inventory["crate"] == 1)
        {
            crateButton.SetActive(true);
        }
        if (Player.inventory["bed"] == 1)
        {
            bedButton.SetActive(true);
        }
    }

    public void ResetButtons()
    {
        if (inventoryUI.activeSelf)
        {
            closeButton.SetActive(false);
            crateButton.SetActive(false);
            bedButton.SetActive(false);
        }
    }

    public void SelectItem(string item)
    {
        GetComponent<Placement>().activeItem = item;
    }
}
