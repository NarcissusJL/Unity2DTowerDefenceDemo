using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectButton : MonoBehaviour
{
  public void level_1()
  {
    SceneManager.LoadScene("OfficialScene");
  }
  public void level_2()
  {
    SceneManager.LoadScene("Level2v2");
  }
  public void level_3()
  {
    SceneManager.LoadScene("Level3v2");
  }

}
