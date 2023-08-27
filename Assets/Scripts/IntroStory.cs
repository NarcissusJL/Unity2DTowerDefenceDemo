using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroStory : MonoBehaviour
{
  void Start()
  {
    StartCoroutine(waitSeconds());
  }
  // void OnEnable()
  // {
  //
  // }
  IEnumerator waitSeconds(){
    yield return new WaitForSeconds(36f);
    SceneManager.LoadScene("OfficialScene");
  }
  //, LoadSceneMode.Single
  // IEnumerator waitUntilSceneEnds(){
  //   StartCoroutine(waitSeconds());
    // SceneManager.LoadScene("OfficialScene", LoadSceneMode.Single);
  //   yield return null;
  // }

  // void Start(){
  //   StartCoroutine(waitUntilSceneEnds());
  // }
}
