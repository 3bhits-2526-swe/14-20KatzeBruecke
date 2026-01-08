using UnityEngine;
using UnityEngine.SceneManagement;

public class Level_Auswahl : MonoBehaviour
{
     public string level1 = "Level1";
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame

    void OnMouseDown()
    {

        
            Debug.Log("Funktioniert");
            SceneManager.LoadScene(level1);
        
    }

    
  
   
}

