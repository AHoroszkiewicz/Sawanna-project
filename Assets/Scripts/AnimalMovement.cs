using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalMovementScript : MonoBehaviour
{
    public List<Transform> nodes; // Lista nodów, po których porusza siê zwierzê
    private int currentNodeIndex = 0; // Indeks aktualnego noda
    private int previousNodeIndex = -1; // Indeks poprzedniego noda
    public float moveSpeed = 5f; // Szybkoœæ poruszania siê zwierzêcia

    private void Start()
    {
        SetNextNode();
    }

    private void Update()
    {
        MoveToNextNode();
    }

    private void MoveToNextNode()
    {
        if (nodes == null || nodes.Count == 0)
        {
            Debug.LogError("Brak przypisanych nodów do zwierzêcia: " + gameObject.name);
            return;
        }

        // Kieruj zwierzê w stronê aktualnego noda
        Vector3 direction = (nodes[currentNodeIndex].position - transform.position).normalized;
        transform.Translate(direction * moveSpeed * Time.deltaTime);

        // SprawdŸ, czy zwierzê jest wystarczaj¹co blisko do noda, aby przejœæ do nastêpnego
        if (Vector3.Distance(transform.position, nodes[currentNodeIndex].position) < 0.1f)
        {
            SetNextNode();
        }
    }

    private void SetNextNode()
    {
        // Wybierz losowy node, z pominiêciem obecnego i poprzedniego
        List<Transform> availableNodes = new List<Transform>(nodes);
        availableNodes.Remove(nodes[currentNodeIndex]);
        if (previousNodeIndex != -1)
        {
            availableNodes.Remove(nodes[previousNodeIndex]);
        }

        if (availableNodes.Count > 0)
        {
            previousNodeIndex = currentNodeIndex;
            currentNodeIndex = nodes.IndexOf(availableNodes[Random.Range(0, availableNodes.Count)]);
        }
        else
        {
            // Jeœli wszystkie nody zosta³y odwiedzone, zacznij od nowa
            previousNodeIndex = -1;
            currentNodeIndex = Random.Range(0, nodes.Count);
        }
    }
}
