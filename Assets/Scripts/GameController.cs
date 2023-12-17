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

    public List<Animal> Animals
    {
        get { return animals; }
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
