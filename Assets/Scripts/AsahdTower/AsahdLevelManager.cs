using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class AsahdLevelManager : MonoBehaviour
{
    public int currentLevelIndex;
    int levelCurrentWave = 1;
    int[] arrayToPassIn;
    public int[,] spawnOrder;
    [SerializeField] public int totalWaves;
    [SerializeField] GameObject enemySpawner;
    [SerializeField] TextMeshProUGUI goldCounter;
    [SerializeField] GameObject winText;
    [SerializeField] public int enemy1Size;
    [SerializeField] public int enemy2Size;
    [SerializeField] public int enemy3Size;
    [SerializeField] Button waveStartButton;
    [SerializeField] TextMeshProUGUI waveMin;
    [SerializeField] TextMeshProUGUI waveMax;
    
    public int goldNumber;

    IEnumerator changeLevel(){
        winText.SetActive(true);
        yield return new WaitForSeconds(5f);
        winText.SetActive(false);
        SceneManager.LoadScene(currentLevelIndex+1);
    }
    IEnumerator waitUntilEnemiesGone(){
        waveStartButton.interactable = false;
        yield return new WaitForSeconds(30f);
        waveStartButton.interactable = true;
        levelCurrentWave++;
        minwaveSetText(levelCurrentWave.ToString());
    }
    void setText(string bean){
        goldCounter.text = bean;
    }

    void minwaveSetText(string bean){
        waveMin.text="Wave: "+ bean;
    }
    void maxwaveSetText(string bean){
        waveMax.text="Max Wave: " + bean;
    }

    public void addGold(int value){
        goldNumber+=value;
        setText(goldNumber.ToString());
    }

    // Start is called before the first frame update
    void Awake()
    {
     goldNumber = 300;
     enemy1Size = 1;
     enemy2Size = 1;
     enemy3Size = 1;
     setText(goldNumber.ToString());
     minwaveSetText("1");
     maxwaveSetText(totalWaves.ToString());
     currentLevelIndex=SceneManager.GetActiveScene().buildIndex;
    }

    void buttonManagement(){
        if (levelCurrentWave == totalWaves){
            StartCoroutine(changeLevel());
        }
        else{

            for(int i=0;i<arrayToPassIn.Length;i++){
                arrayToPassIn[i] = spawnOrder[levelCurrentWave-1,i];
            }
            enemySpawner.GetComponent<Spawner>().StartCoroutine("asahdSpawnEnemies", arrayToPassIn);
            StartCoroutine(waitUntilEnemiesGone());


        }
    }

    void Start(){
        Debug.Log("The level we're at is -> " + currentLevelIndex);
        waveStartButton.onClick.AddListener(buttonManagement);
        if( currentLevelIndex == 2){
            arrayToPassIn= new int[] {0,0,0,0,0,0,0,0,0,0};
            spawnOrder= new int[,] {{1,2,3,0,0,0,0,0,0,0}, {1,2,3,2,3,1,0,0,0,0}, {1,2,3,1,1,3,3,0,0,0}, {1,1,1,1,1,2,2,3,3,3}, {3,3,3,3,3,2,3,3,3,1}};
        }
        else if( currentLevelIndex == 3){
            arrayToPassIn= new int[] {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0};
            spawnOrder= new int[,] {{2,2,2,1,1,0,0,0,0,0,0,0,0,0,0}, {2,2,1,3,3,2,3,1,0,0,0,0,0,0,0}, {3,3,1,3,3,3,2,3,2,1,0,0,0,0,0}, {3,2,2,2,1,2,1,3,3,2,1,3,3,2,1}, {3,3,3,3,3,3,3,3,3,3,2,2,1,1,1}};
        }
        else if( currentLevelIndex == 4){
            arrayToPassIn= new int[] {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0};
            spawnOrder = new int [,] {{1,1,2,3,1,1,2,2,2,0,0,0,0,0,0,0,0,0,0,0,0}, {1,2,3,2,2,1,3,2,1,2,1,2,3,1,0,0,0,0,0,0,0}, {3,3,3,3,3,2,1,2,2,3,1,2,1,3,2,3,1,2,3,3,3}, {2,2,2,1,3,1,2,3,1,2,3,1,1,2,3,2,1,2,3,1,2}, {2,2,2,1,3,1,2,3,1,2,3,1,1,2,3,2,1,2,3,1,2}};
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
