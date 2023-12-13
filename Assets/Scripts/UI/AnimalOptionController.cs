using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AnimalOptionController : MonoBehaviour
{
    [SerializeField] public List<Animal> animals;
    [SerializeField] private TextMeshProUGUI title;
    [SerializeField] private TextMeshProUGUI maxAgeTxt;
    [SerializeField] private Slider maxAgeSlider;
    private int currentAnimalId;

    private void Start()
    {
        maxAgeSlider.onValueChanged.AddListener((value) =>
        {
            UpdateMaxAge((int)value);
        });  
    }

    public void Initialize(int id, int number)
    {
        currentAnimalId = id;
        maxAgeSlider.value = animals[id].maxAge;
        maxAgeTxt.text = "Max Age: " + animals[id].maxAge;
        switch (animals[id].AnimalType)
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
                title.text = "Snake " + number;
                break;
            default:
                break;
        }
    }

    public void UpdateMaxAge(int value)
    {
        animals[currentAnimalId].maxAge = value;
        maxAgeTxt.text = "Max Age: " + value;
    }
}
