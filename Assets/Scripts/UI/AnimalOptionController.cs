using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class AnimalOptionController : MonoBehaviour
{
    [SerializeField] public GameController gameController;
    [SerializeField] private TextMeshProUGUI title;
    [SerializeField] private Slider maxAgeSlider;
    [SerializeField] private TextMeshProUGUI maxAgeTxt;
    [SerializeField] private GameObject venomRegenObject;
    [SerializeField] private Slider venomRegenSlider;
    [SerializeField] private TextMeshProUGUI venomRegenTxt;
    private int currentAnimalId;

    private void Start()
    {
        maxAgeSlider.onValueChanged.AddListener((value) =>
        {
            UpdateMaxAge((int)value);
        });  

        venomRegenSlider.onValueChanged.AddListener((value) =>
        {
            UpdateVenomRegen((int)value);
        });
    }

    public void Initialize(int id, int number)
    {
        venomRegenObject.SetActive(false);
        currentAnimalId = id;
        Animal currentAnimal = gameController.Animals[id];
        maxAgeSlider.value = currentAnimal.MaxAge;
        maxAgeTxt.text = "Max Age: " + currentAnimal.MaxAge;
        switch (currentAnimal.AnimalType)
        {
            case Animal.AnimalTypes.lion:
                title.text = "Lion "+number;
                break;
            case Animal.AnimalTypes.deer:
                title.text = "Deer " + number;
                break;
            case Animal.AnimalTypes.bird:
                title.text = "Bird " + number;
                break;
            case Animal.AnimalTypes.hyena:
                title.text = "Hyena " + number;
                break;
            case Animal.AnimalTypes.snake:
                venomRegenObject.SetActive(true);
                Snake snake = currentAnimal.GetComponent<Snake>();
                venomRegenSlider.value = snake.VenomRegenRate;
                title.text = "Snake " + number;
                break;
            default:
                break;
        }
    }

    public void UpdateMaxAge(int value)
    {
        gameController.Animals[currentAnimalId].MaxAge = value;
        maxAgeTxt.text = "Max Age: " + value;
    }

    public void UpdateVenomRegen(int value)
    {
        foreach (Snake snake in gameController.Snakes)
        {
            if (snake.Id != currentAnimalId) continue;
            snake.VenomRegenRate = value;
            venomRegenTxt.text = "Venom Regen: " + value;
        }
    }
}
