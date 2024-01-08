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
        var a = 0;
        for (int i = 0; i < animals.Count; i++)
        {
            if (animals[i].AnimalType == Animal.AnimalTypes.lion && a < number)
            {
                a++;
            }
            else if(animals[i].AnimalType == Animal.AnimalTypes.lion)
            {
                animalOptionController.Initialize(i, number);
            }
        }
        CloseAllPanels();
        OpenPanelId(6);
    }

    public void OpenDeerOptions(int number)
    {
        var a = 0;
        for (int i = 0; i < animals.Count; i++)
        {
            if (animals[i].AnimalType == Animal.AnimalTypes.deer && a < number)
            {
                a++;
            }
            else if (animals[i].AnimalType == Animal.AnimalTypes.deer)
            {
                animalOptionController.Initialize(i, number);
            }
        }
        CloseAllPanels();
        OpenPanelId(6);
    }

    public void OpenBirdOptions(int number)
    {
        var a = 0;
        for (int i = 0; i < animals.Count; i++)
        {
            if (animals[i].AnimalType == Animal.AnimalTypes.bird && a < number)
            {
                a++;
            }
            else if (animals[i].AnimalType == Animal.AnimalTypes.bird)
            {
                animalOptionController.Initialize(i, number);
            }
        }
        CloseAllPanels();
        OpenPanelId(6);
    }

    public void OpenHyenaOptions(int number)
    {
        var a = 0;
        for (int i = 0; i < animals.Count; i++)
        {
            if (animals[i].AnimalType == Animal.AnimalTypes.hyena && a < number)
            {
                a++;
            }
            else if (animals[i].AnimalType == Animal.AnimalTypes.hyena)
            {
                animalOptionController.Initialize(i, number);
            }
        }
        CloseAllPanels();
        OpenPanelId(6);
    }

    public void OpenSnakeOptions(int number)
    {
        //var a = 0;
        //for (int i = 0; i < animals.Count; i++)
        //{
        //    if (animals[i].AnimalType == Animal.AnimalTypes.snake && a < number)
        //    {
        //        a++;
        //    }
        //    else if (animals[i].AnimalType == Animal.AnimalTypes.snake)
        //    {
        //        animalOptionController.Initialize(i, number);
        //    }
        //}

        animalOptionController.Initialize(gameController.Snakes[number].Id, number);

        CloseAllPanels();
        OpenPanelId(6);
    }
}
