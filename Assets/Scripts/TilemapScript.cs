using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class TilemapScript : MonoBehaviour
{
    [SerializeField] GameObject FloatingTextPrefab;

    
    [SerializeField] GameObject levelManager;
    [SerializeField] GameObject Tower1;
    [SerializeField] GameObject Tower2;
    [SerializeField] GameObject Tower3;
    [SerializeField] Tilemap gameMap;
    
    bool isClicked1 = false;
    bool isClicked2 = false;
    bool isClicked3 = false;
    private Camera smackCam; // a joke but also a camera ahaa
    string  str = "Not enough gold!";


    public void boolSwitch(int whichTower){
        if (!isClicked1 && !isClicked2 && !isClicked3){
            if (whichTower == 1){
                isClicked1 = true;
                isClicked2 = false;
                isClicked3 = false;
            Debug.Log("SET TO TRUE 1");

            }
            else if(whichTower == 2 ){
                isClicked1 = false;
                isClicked2 = true;
                isClicked3 = false;
            Debug.Log("SET TO TRUE 2");

            }
            else if (whichTower == 3 ){
                isClicked1 = false;
                isClicked2 = false;
                isClicked3 = true;
            Debug.Log("SET TO TRUE 3");
            }
        }
        else{
            isClicked1 = false;
            isClicked2 = false;
            isClicked3 = false;
        }
    }
    void ShowFloatingText(){
        //  Instatiates the floating text prefab in the middle of the screen 
        var t = Instantiate(FloatingTextPrefab, new Vector3(0,4.5f,0), Quaternion.identity);
        t.GetComponent<TextMesh>().text = str;
        t.GetComponent<Animator>().enabled = false;
    }
    void Update(){
            if(Input.GetMouseButtonDown(0)){
                if(isClicked1){
                    if (levelManager.GetComponent<AsahdLevelManager>().goldNumber > 99 ){
                        Vector3 worldPoint = smackCam.ScreenToWorldPoint(Input.mousePosition); //Get the position of the left click
                        Vector3Int clickPosition = gameMap.WorldToCell(worldPoint);

                        if(gameMap.GetTile<Tile>(clickPosition) != null){
                            Debug.Log(gameMap.GetTile<Tile>(clickPosition).name );
                            if(gameMap.GetTile<Tile>(clickPosition).name =="grass_03"
                            || gameMap.GetTile<Tile>(clickPosition).name =="pipo-map001_at-kusa_4"){
                                    Debug.Log(gameMap.GetTile<Tile>(clickPosition).name);
                            int gridX = Mathf.FloorToInt(worldPoint.x / gameMap.cellSize.x);
                            int gridY = Mathf.FloorToInt(worldPoint.y / gameMap.cellSize.y);
                            GameObject tower1 = Instantiate(Tower1, new Vector3(gridX * gameMap.cellSize.x, gridY * gameMap.cellSize.y, 0), Quaternion.identity);
                            tower1.transform.position = clickPosition + new Vector3(.5f,1,0);
                            levelManager.GetComponent<AsahdLevelManager>().addGold(-100);
                            tower1.SetActive(true);
                            }
                        else{
                            Debug.Log("Tile is invalid");
                            Debug.Log("Can't place tower here");
                            str = "Can't place tower here!";
                            if(FloatingTextPrefab){
                                ShowFloatingText();
                                }
                        }
                        
                        }
                        else{
                            Debug.Log("Tile is null");
                            Debug.Log("Can't place tower here");
                            str = "Can't place tower here!";
                            if(FloatingTextPrefab){
                                ShowFloatingText();
                                }
                        }
                    }else
                    {
                        Debug.Log("Not enough gold");
                        if(FloatingTextPrefab){
                         ShowFloatingText();
                        }
                    } 
                    isClicked1 = false; 

                }
                else if(isClicked2){
                           if (levelManager.GetComponent<AsahdLevelManager>().goldNumber > 199 ){
                        Vector3 worldPoint = smackCam.ScreenToWorldPoint(Input.mousePosition); //Get the position of the left click
                        Vector3Int clickPosition = gameMap.WorldToCell(worldPoint);

                        if(gameMap.GetTile<Tile>(clickPosition) != null){
                            Debug.Log(gameMap.GetTile<Tile>(clickPosition).name );
                            if(gameMap.GetTile<Tile>(clickPosition).name =="grass_03"
                            || gameMap.GetTile<Tile>(clickPosition).name =="pipo-map001_at-kusa_4"){
                                    Debug.Log(gameMap.GetTile<Tile>(clickPosition).name);
                            int gridX = Mathf.FloorToInt(worldPoint.x / gameMap.cellSize.x);
                            int gridY = Mathf.FloorToInt(worldPoint.y / gameMap.cellSize.y);
                            GameObject tower2 = Instantiate(Tower2, new Vector3(gridX * gameMap.cellSize.x, gridY * gameMap.cellSize.y, 0), Quaternion.identity);
                            tower2.transform.position = clickPosition + new Vector3(.5f,1,0);
                            levelManager.GetComponent<AsahdLevelManager>().addGold(-200);
                            tower2.SetActive(true);
                            }
                        else{
                            Debug.Log("Tile is invalid");
                            Debug.Log("Can't place tower here");
                            str = "Can't place tower here!";
                            if(FloatingTextPrefab){
                                ShowFloatingText();
                                }
                        }
                        
                        }
                        else{
                            Debug.Log("Tile is null");
                            Debug.Log("Can't place tower here");
                            str = "Can't place tower here!";
                            if(FloatingTextPrefab){
                                ShowFloatingText();
                                }
                        }
                    }else
                    {
                        Debug.Log("Not enough gold");
                        if(FloatingTextPrefab){
                         ShowFloatingText();
                        }
                    } 
                       isClicked2 = false; 

                }
                else if(isClicked3){
                            if (levelManager.GetComponent<AsahdLevelManager>().goldNumber > 299 ){
                        Vector3 worldPoint = smackCam.ScreenToWorldPoint(Input.mousePosition); //Get the position of the left click
                        Vector3Int clickPosition = gameMap.WorldToCell(worldPoint);

                        if(gameMap.GetTile<Tile>(clickPosition) != null){
                            Debug.Log(gameMap.GetTile<Tile>(clickPosition).name );
                            if(gameMap.GetTile<Tile>(clickPosition).name =="grass_03"
                            || gameMap.GetTile<Tile>(clickPosition).name =="pipo-map001_at-kusa_4"){
                                    Debug.Log(gameMap.GetTile<Tile>(clickPosition).name);
                            int gridX = Mathf.FloorToInt(worldPoint.x / gameMap.cellSize.x);
                            int gridY = Mathf.FloorToInt(worldPoint.y / gameMap.cellSize.y);
                            GameObject tower3 = Instantiate(Tower3, new Vector3(gridX * gameMap.cellSize.x, gridY * gameMap.cellSize.y, 0), Quaternion.identity);
                            tower3.transform.position = clickPosition + new Vector3(.5f,1,0);
                            levelManager.GetComponent<AsahdLevelManager>().addGold(-300);
                            tower3.SetActive(true);
                            }
                        else{
                            Debug.Log("Tile is invalid");
                            Debug.Log("Can't place tower here");
                            str = "Can't place tower here!";
                            if(FloatingTextPrefab){
                                ShowFloatingText();
                                }
                        }
                        
                        }
                        else{
                            Debug.Log("Tile is null");
                            Debug.Log("Can't place tower here");
                            str = "Can't place tower here!";
                            if(FloatingTextPrefab){
                                ShowFloatingText();
                                }
                        }
                    }else
                    {
                        Debug.Log("Not enough gold");
                        if(FloatingTextPrefab){
                         ShowFloatingText();
                        }
                    } 
                       isClicked3 = false; 

                }
            }
    }

    void Start(){
        smackCam = Camera.main;
    }
}
