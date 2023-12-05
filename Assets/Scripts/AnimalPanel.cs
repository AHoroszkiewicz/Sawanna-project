using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalPanel : MonoBehaviour
{
    private bool isOpen = false;
    [SerializeField] private PanelTypes panelType;

    public bool IsOpen => isOpen;
    public PanelTypes PanelType => panelType;

    public void OpenPanel()
    {
        gameObject.SetActive(true);
        isOpen = true;
    }

    public void ClosePanel()
    {
        gameObject.SetActive(false);
        isOpen = false;
    }

    public enum PanelTypes
    {
        none = 0,
        Animal = 1,
        Lion = 2,
        Deer = 3,
        Bird = 4,
        Hyena = 5,
        Snake = 6,
    }
}
