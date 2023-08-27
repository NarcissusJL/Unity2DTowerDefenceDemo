using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuStart : MonoBehaviour
{



    void OnMouseDown(){
        SceneManager.LoadScene("IntroStory");
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
