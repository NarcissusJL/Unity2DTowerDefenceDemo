using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level1 : MonoBehaviour
{


    
   
    void Update()
    {
        // onClick go back to Main Menu
              if(Input.GetMouseButtonDown(0))
                {
            SceneManager.LoadScene("OfficialScene");
                }

    }

    void Start()
    {
        
    }

    // Update is called once per frame
    
}
