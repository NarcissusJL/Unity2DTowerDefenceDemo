using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level3 : MonoBehaviour
{


    
    void Start()
    {
        
    }

    // Update is called once per frame
   
    
     void Update()
    {
        // onClick go back to Main Menu
              if(Input.GetMouseButtonDown(0))
                {
    SceneManager.LoadScene("Level3v2");
                }

    }
}
