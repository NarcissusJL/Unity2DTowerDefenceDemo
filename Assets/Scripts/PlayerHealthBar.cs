using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class PlayerHealthBar : MonoBehaviour
{
  // public static event Action OnPlayerDeath;
  public Slider slider;
  [SerializeField] public float current_health;
  [SerializeField] public float max_health;

  public void SetMaxHealth(int health)
  {
    slider.maxValue = health;
    slider.value = health;
  }
  public void SetHealth(int health)
  {
    slider.value = health;
  }
  public void TakeDamage(float damage)
  {
    slider.value -= damage;
    if(slider.value <= 0)
    {
      slider.value = 0;
      SceneManager.LoadScene("EndGame");
    //   Debug.Log("Dead");
    //   // OnPlayerDeath?.Invoke();
    }
  }
  // public void playerDeath()
  // {
  //   SceneManager.LoadScene("EndGame");
  // }
  void Start()
  {
    slider.value = max_health;
  }



}
