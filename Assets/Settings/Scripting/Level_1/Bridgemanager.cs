using UnityEngine;

public class BridgeManager : MonoBehaviour
{
    public static BridgeManager Instance;

    public bool bridgeMode;

    public Transform firstNode;
    public Transform secondNode;

    public GameObject bridgePrefab;
    public GameObject previewPrefab;
    public GameObject candyPrefab;

    public Transform parentcandy;

    private GameObject previewInstance;

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
        if (!bridgeMode || firstNode == null || secondNode == null)
            return;

        if (previewInstance != null)
            Destroy(previewInstance);

        Vector3 pos = (firstNode.position + secondNode.position) / 2f;
        Vector3 dir = secondNode.position - firstNode.position;

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        GameObject bridge = Instantiate(
            bridgePrefab,
            pos,
            Quaternion.Euler(0, 0, angle)
        );

        bridge.transform.localScale =
            new Vector3(dir.magnitude, 1f, 1f);

        SpawnCandy();

        bridgeMode = false;
    }

    public void ShowPreviewAtFirstNode()
    {
        if (!bridgeMode || firstNode == null)
            return;

        if (previewInstance != null)
            Destroy(previewInstance);

        previewInstance = Instantiate(
            previewPrefab,
            firstNode.position,
            Quaternion.identity
        );
    }

   public void SpawnCandy()
{
    if (candyPrefab == null || firstNode == null || secondNode == null)
        return;

    Vector3 pos = (firstNode.position + secondNode.position) / 2f;
    Vector3 dir = secondNode.position - firstNode.position;
    float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

    GameObject candy = Instantiate(
        candyPrefab,
        pos,
        Quaternion.Euler(0, 0, angle)
    );

    candy.transform.SetParent(parentcandy, true); // true = worldPosition behalten

    Vector3 scale = candy.transform.localScale;
    candy.transform.localScale =
        new Vector3(dir.magnitude, scale.y, scale.z);
}

}
