using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;  
#endif

public class GameController : MonoBehaviour
{
    private bool isAutoRounds = false;
    private bool isRoundInProgress = false;
    [SerializeField] private GameObject autoRoundsBtn;
    [SerializeField] private Sprite autoRoundsOnSprite;
    [SerializeField] private Sprite autoRoundsOffSprite;
    [SerializeField] private List<Animal> animals = new List<Animal>();

    private List<Snake> snakes = new List<Snake>();
    private List<Lion> lions = new List<Lion>();
    private List<Antelope> antelopes = new List<Antelope>();
    private List<Bird> birds = new List<Bird>();
    private List<Hyena> hyenas = new List<Hyena>();

    public List<Animal> Animals => animals;
    public List<Snake> Snakes => snakes;
    public List<Lion> Lions => lions;
    public List<Antelope> Antelopes => antelopes;
    public List<Bird> Birds => birds;
    public List<Hyena> Hyenas => hyenas;

    private void Awake()
    {
        PopulateAnimals();
    }

    private void Start()
    {
        foreach (Animal animal in animals)
        {
            if (animal is Snake snake)
            {
                snakes.Add(snake);
            }
            else if (animal is Lion lion)
            {
                lions.Add(lion);
            }
            else if (animal is Antelope antelope)
            {
                antelopes.Add(antelope);
            }
            else if (animal is Bird bird)
            {
                birds.Add(bird);
            }
            else if (animal is Hyena hyena)
            {
                hyenas.Add(hyena);
            }
        }
    }

    public void NextRound()
    {
        StartCoroutine(NextRoundCoroutine());
    }

    private IEnumerator NextRoundCoroutine()
    {
        while (true)
        {
            isRoundInProgress = true;
            Debug.Log("Next Round");
            foreach (Animal animal in animals)
            {
                if (!animal.IsAlive) continue;
                animal.Move();
                animal.AgeUp();
                if (animal.Age >= animal.maxAge) animal.Die();
            }

            yield return new WaitForSeconds(2f);

            isRoundInProgress = false;
            if (!isAutoRounds) 
            { 
                yield break;
            }
        }
    }

    public void AutoRounds()
    {
        isAutoRounds = !isAutoRounds;
        if (!isRoundInProgress) NextRound();
        autoRoundsBtn.GetComponent<UnityEngine.UI.Image>().sprite = isAutoRounds ? autoRoundsOnSprite : autoRoundsOffSprite;
    }   

    #region Inspector
    public void PopulateAnimals()
    {
        animals.Clear();
        Animal[] animalArray = FindObjectsOfType<Animal>();
        for (int i = 0; i < animalArray.Length; i++)
        {
            animals.Add(animalArray[i]);
            animals[i].Id = i;
        }   
    }

    public void ClearAnimals()
    {
        animals.Clear();
    }
    #endregion      
}

#if UNITY_EDITOR
[CustomEditor(typeof(GameController))]
class GameControllerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        GameController gameController = (GameController)target;
        if (gameController == null) return;

        if (GUILayout.Button("Populate Animals"))
        {
            gameController.PopulateAnimals();
        }
        if (GUILayout.Button("Clear Animals"))
        {
            gameController.ClearAnimals();
        }
    }
}
#endif
