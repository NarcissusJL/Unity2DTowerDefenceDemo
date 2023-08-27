using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
  public void Play()
  {
    SceneManager.LoadScene("IntroStory");
  }
  public void levelSelect()
  {
    SceneManager.LoadScene("LevelSelect");
  }
  public void Credit()
  {
    SceneManager.LoadScene("Rolling Credits");
  }
}
