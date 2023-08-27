using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
  [SerializeField] private GameObject pauseObject;
  [SerializeField] private potraitChange potrait;

  public TextMeshProUGUI Sentences;
  public string[] lines;
  public float textSpeed;
  public bool isShown = false;

  private int index;


    // Start is called before the first frame update
    void Start()
    {
      if(!isShown)
        Sentences.text = string.Empty;
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
      if(Input.GetMouseButtonDown(0))
      {
        if(Sentences.text == lines[index])
        {
          nextLine();
        }
        else
        {
          Sentences.text = lines[index];
        }
        potrait.GetComponent<potraitChange>().ChangeSprite();
      }
    }
    void StartDialogue()
    {
      pauseObject.GetComponent<pauseGame>().TogglePause();
      index = 0;
      Sentences.text = lines[index];
      isShown = true;

    }


    void nextLine()
    {
      if (index<lines.Length - 1)
      {
        index++;
        Sentences.text = string.Empty;
        Sentences.text = lines[index];
      }
      else
      {
        gameObject.SetActive(false);
        pauseObject.GetComponent<pauseGame>().TogglePause();

      }
    }
}
