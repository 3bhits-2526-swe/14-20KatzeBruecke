using UnityEngine;
using UnityEngine.SceneManagement;

public class Starter : MonoBehaviour
{

   public string level = "Level";
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log("Funktioniert");
            SceneManager.LoadScene(level);
        }

        
    }
}
