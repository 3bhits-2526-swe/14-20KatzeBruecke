using UnityEngine;

public class Knotenpunkte : MonoBehaviour
{
    private void OnMouseDown()
    {
        if (!BridgeManager.Instance.bridgeMode)
            return;

        if (BridgeManager.Instance.firstNode == null)
        {
            BridgeManager.Instance.firstNode = transform;
            BridgeManager.Instance.ShowPreviewAtFirstNode();
        }
        else if (BridgeManager.Instance.secondNode == null &&
                 BridgeManager.Instance.firstNode != transform)
        {
            BridgeManager.Instance.secondNode = transform;
            BridgeManager.Instance.CreateBridge();
        }
    }
}
