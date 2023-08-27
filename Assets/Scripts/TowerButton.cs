using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;



public class TowerButton : MonoBehaviour
{
    public Button someButton;
    [SerializeField] Tilemap theTiles;
    [SerializeField] int towerToCall;

    void OnEnable(){
        someButton.onClick.AddListener(() => theTiles.GetComponent<TilemapScript>().boolSwitch(towerToCall));
    }

    void OnDisable(){
        someButton.onClick.RemoveAllListeners();
    }
}
