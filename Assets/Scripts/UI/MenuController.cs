using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    [SerializeField] private GameController gameController;
    [SerializeField] private AnimalPanel[] animalPanels;
    [SerializeField] private GameObject optionsObject;
    [SerializeField] private AnimalOptionController animalOptionController;
    private int currentPanelId;
    private List<Animal> animals => gameController.Animals;

    private void Start()
    {
        foreach (var panel in animalPanels)
        {
            CloseAllPanels(true);
        }
    }

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

    public void OpenLionOptions(int number)
    {
        animalOptionController.Initialize(gameController.Lions[number].Id, number);

        CloseAllPanels();
        OpenPanelId(6);
    }

    public void OpenAntelopeOptions(int number)
    {
        animalOptionController.Initialize(gameController.Antelopes[number].Id, number);

        CloseAllPanels();
        OpenPanelId(6);
    }

    public void OpenBirdOptions(int number)
    {
        animalOptionController.Initialize(gameController.Birds[number].Id, number);

        CloseAllPanels();
        OpenPanelId(6);
    }

    public void OpenHyenaOptions(int number)
    {
        animalOptionController.Initialize(gameController.Hyenas[number].Id, number);

        CloseAllPanels();
        OpenPanelId(6);
    }

    public void OpenSnakeOptions(int number)
    {
        animalOptionController.Initialize(gameController.Snakes[number].Id, number);

        CloseAllPanels();
        OpenPanelId(6);
    }
}
