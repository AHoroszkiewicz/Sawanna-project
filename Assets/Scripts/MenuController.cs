using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    [SerializeField] private AnimalPanel[] animalPanels;
    [SerializeField] private GameObject optionsObject;
    private int currentPanelId;

    public void MenuButton()
    {
        foreach (var panel in animalPanels)
        {
            if (panel.IsOpen)
            {
                CloseAllPanels(true);
                return;
            }
        }
        OpenPanelId(0);
    }

    public void OpenPanelId(int id)
    {
        CloseAllPanels();
        optionsObject.SetActive(true);
        animalPanels[id].OpenPanel();
        currentPanelId = id;
    }

    private void CloseAllPanels(bool forceClose = false)
    {
        foreach (AnimalPanel panel in animalPanels)
        {
            panel.ClosePanel();
        }
        if (forceClose)
        {
            optionsObject.SetActive(false);
        }
    }
}
