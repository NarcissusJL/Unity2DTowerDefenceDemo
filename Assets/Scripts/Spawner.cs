using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private GameObject enemyPrefab;
    



    private float _waveTimer;
    private int _waveCount;
    private int _spawnedEnemies;

    private ObjectPooler _objectPooler1;
    private ObjectPooler _objectPooler2;
    private ObjectPooler _objectPooler3;
    


    private Waypoint _waypoint;

    //private Animator myAnimator;

    // Start is called before the first frame update
    private void Start()
    {
        _objectPooler1 = GameObject.Find("Pooler1").GetComponent<ObjectPooler>();
        _objectPooler2 = GameObject.Find("Pooler2").GetComponent<ObjectPooler>();
        _objectPooler3 = GameObject.Find("Pooler3").GetComponent<ObjectPooler>();
        
        _waypoint = GetComponent<Waypoint>();
        
    }

    // Update is called once per frame
    void Update(){
        // _waveTimer -= Time.deltaTime;
        // if(_waveTimer < 0)
        // {
        //   if(waveCount > _waveCount)
       
        //     StartCoroutine(SpawnWave());
           
        // _waveTimer = waveDelay;
          
        // }
        

    }
    // IEnumerator SpawnWave()
    // {
    //     for (int i = 0; i < enemyCount; i++)
    //     {
    //         //SpawnEnemy();
    //         asahdSpawnWave();
    //         yield return new WaitForSeconds(spawnDelay);
    //     }
    //     _waveCount++;
    // }


    // private void SpawnEnemy(){
    //     //myAnimator = GetComponent<Animator>();
    //     GameObject newInstance = _objectPooler.GetInstanceFromPool();
    //     newInstance.SetActive(true); // Set true to see them moving
    //     newInstance.transform.position = _waypoint.GetWaypoint(0);
    // }


    public IEnumerator unleashWave(){
      yield return null;
    }
    public IEnumerator asahdSpawnEnemies(int[] spawnOrder){
          
      for(int j=0; j<spawnOrder.Length; j++){
        switch (spawnOrder[j]){
          case 1:
            GameObject newInstance1 =_objectPooler1.GetInstanceFromPool(); 
            newInstance1.transform.position = _waypoint.GetWaypoint(0);
            newInstance1.SetActive(true);
            break;
          case 2:
            GameObject newInstance2 =_objectPooler2.GetInstanceFromPool();
            newInstance2.transform.position = _waypoint.GetWaypoint(0);
            newInstance2.SetActive(true);
            break;
          case 3:
            GameObject newInstance3 =_objectPooler3.GetInstanceFromPool();
            newInstance3.transform.position = _waypoint.GetWaypoint(0);
            newInstance3.SetActive(true);
            break;
        }
        yield return new WaitForSeconds(1f);
      }


    }




/*
    private Animation(Point CurPos, Point newPos)
    {
      if(CurPos.Y > newPos.Y) // Enemy moving down
      {
        myAnimator.SetInteger("Horizontal",0);
        myAnimator.SetInteger("Vertical",1);
      }
      else if(CurPos.Y < newPos.Y) //Enemy moving up
      {
        myAnimator.SetInteger("Horizontal",0);
        myAnimator.SetInteger("Vertical",-1);
      }
      if(CurPos.Y == newPos.Y)
      {
        if(CurPos.X > newPos.X)//Enemy moving left
        {
          myAnimator.SetInteger("Horizontal",-1);
          myAnimator.SetInteger("Vertical",0);
        }
        else if(CurPos.X < newPos.X) //Enemy moving right
        {
          myAnimator.SetInteger("Horizontal",1);
          myAnimator.SetInteger("Vertical",0);
        }
      }

    }
    */


}
