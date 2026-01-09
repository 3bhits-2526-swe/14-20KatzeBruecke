using UnityEngine;

public class Knotenpunkt : MonoBehaviour
{
    private void OnMouseDown()
    {
        if (!BridgeManager.Instance.bridgeMode)
            return;

        if (BridgeManager.Instance.firstNode == null)
        {
            BridgeManager.Instance.firstNode = transform;
            BridgeManager.Instance.ShowPreviewAtFirstNode();
            Debug.Log("Erster Knoten gewählt");
        }
        else if (BridgeManager.Instance.secondNode == null)
        {
            BridgeManager.Instance.secondNode = transform;
            Debug.Log("Zweiter Knoten gewählt");

            BridgeManager.Instance.bridgeMode = false;
            BridgeManager.Instance.CreateBridge();
        }
    }
}
