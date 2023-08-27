using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level2 : MonoBehaviour
{


    
     void Update()
    {
        // onClick go back to Main Menu
              if(Input.GetMouseButtonDown(0))
                {
    SceneManager.LoadScene("Level2v2");
                }

    }

    void Start()
    {
        
    }

    // Update is called once per frame
  
}
