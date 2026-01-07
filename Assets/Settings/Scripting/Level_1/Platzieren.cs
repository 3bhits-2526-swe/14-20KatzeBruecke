using UnityEngine;

public class Platzieren : MonoBehaviour
{
    private Transform PunktA;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                OnNodeClicked(hit.transform);
            }
        }
    }

    void OnNodeClicked(Transform node)
    {
        if (PunktA == null)
        {
            PunktA = node;
            Debug.Log("Startpunkt gesetzt: " + PunktA.name);
        }
        else
        {
            Debug.Log("Startpunkt wurde schon gesetzt: " + PunktA.name);
        }
    }
}
