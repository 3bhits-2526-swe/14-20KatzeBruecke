using UnityEngine;

public class BridgeManager : MonoBehaviour
{
    public static BridgeManager Instance;

    public bool bridgeMode;

    public Transform firstNode;
    public Transform secondNode;

    public GameObject bridgePrefab;

    private void Awake()
    {
        Instance = this;
    }

    public void ActivateBridgeMode()
    {
        bridgeMode = true;
        firstNode = null;
        secondNode = null;
    }

    public void CreateBridge()
    {
        if (firstNode == null || secondNode == null)
            return;

        Vector3 pos = (firstNode.position + secondNode.position) / 2f;
        Vector3 dir = secondNode.position - firstNode.position;

        float length = dir.magnitude;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        GameObject bridge = Instantiate(
            bridgePrefab,
            pos,
            Quaternion.Euler(0, 0, angle)
        );

        bridge.transform.localScale = new Vector3(length, 1f, 1f);
    }
}
