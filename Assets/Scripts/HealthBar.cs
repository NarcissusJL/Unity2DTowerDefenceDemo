using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

  public Slider slider;
  public int healthM;


  public void SetMaxHealth(int health)
  {
    slider.maxValue = health;
    slider.value = health;
    healthM = health; 
  }
  public void SetHealth(int health)
  {
    slider.value = health;
  }
  public void TakeDamage(int damage)
  {
    slider.value -= damage;
    healthM -= damage;
  }
  public void Start()
  {
    slider = GetComponent<Slider>();

  }
}
