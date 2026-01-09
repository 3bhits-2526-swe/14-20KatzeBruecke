using UnityEngine;

public class Zuckerstange : MonoBehaviour
{
    private void OnMouseDown()
    {
        BridgeManager.Instance.ActivateBridgeMode();
        Debug.Log("Brückenmodus AKTIV");
    }
}
