using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalMovementScript : MonoBehaviour
{
    public List<Transform> nodes; // Lista nod�w, po kt�rych porusza si� zwierz�
    private int currentNodeIndex = 0; // Indeks aktualnego noda
    private int previousNodeIndex = -1; // Indeks poprzedniego noda
    public float moveSpeed = 5f; // Szybko�� poruszania si� zwierz�cia

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
            Debug.LogError("Brak przypisanych nod�w do zwierz�cia: " + gameObject.name);
            return;
        }

        // Kieruj zwierz� w stron� aktualnego noda
        Vector3 direction = (nodes[currentNodeIndex].position - transform.position).normalized;
        transform.Translate(direction * moveSpeed * Time.deltaTime);

        // Sprawd�, czy zwierz� jest wystarczaj�co blisko do noda, aby przej�� do nast�pnego
        if (Vector3.Distance(transform.position, nodes[currentNodeIndex].position) < 0.1f)
        {
            SetNextNode();
        }
    }

    private void SetNextNode()
    {
        // Wybierz losowy node, z pomini�ciem obecnego i poprzedniego
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
            // Je�li wszystkie nody zosta�y odwiedzone, zacznij od nowa
            previousNodeIndex = -1;
            currentNodeIndex = Random.Range(0, nodes.Count);
        }
    }
}
