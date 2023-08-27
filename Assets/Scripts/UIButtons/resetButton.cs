using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class resetButton : MonoBehaviour
{
    public int currentLevelIndex;


    void Awake(){
        currentLevelIndex=SceneManager.GetActiveScene().buildIndex;
    }
    public void doReset(){
        SceneManager.LoadScene(currentLevelIndex);
    }
}
