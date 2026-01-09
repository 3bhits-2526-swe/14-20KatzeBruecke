using UnityEngine;

public class BridgeManager : MonoBehaviour
{
    public static BridgeManager Instance;

    public bool bridgeMode;

    public Transform firstNode;
    public Transform secondNode;

    public GameObject bridgePrefab;

    public GameObject previewPrefab;
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
        if (firstNode == null || secondNode == null)
            return;

            if (previewInstance != null)
{
    UpdatePreviewTransform(previewInstance, firstNode.position, secondNode.position);
    Destroy(previewInstance);
}


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

    public void ShowPreviewAtFirstNode()
{
    if (previewInstance != null)
        Destroy(previewInstance);

    previewInstance = Instantiate(
        previewPrefab,
        firstNode.position,
        Quaternion.identity
    );
}

private void UpdatePreviewTransform(GameObject obj, Vector3 a, Vector3 b)
{
    Vector3 pos = (a + b) / 2f;
    Vector3 dir = b - a;

    float length = dir.magnitude;
    float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

    obj.transform.position = pos;
    obj.transform.rotation = Quaternion.Euler(0, 0, angle);
    obj.transform.localScale = new Vector3(length, 1f, 1f);
}


}
