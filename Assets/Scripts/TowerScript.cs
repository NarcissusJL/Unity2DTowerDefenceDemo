/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerScript : MonoBehaviour
{
  public GameObject basicTowerObject;
  private GameObject TowerPlacement;
  private GameObject hoverTile;
  public Camera cam;
  public LayerMask mask;
  public LayerMask towerMask;
  public bool IsBuilding;

  public void start()
  {
    startBuild();
  }

  public Vector2 GetMousePosition()
  {
    return cam.ScreenToWorldPoint(Input.mousePosition);
  }

  public void GetCurrentHoverTile()
  {
    Vector2 mousePosition = GetMousePosition();
    RaycastHit2D hit = Physics2D.Raycast(mousePosition,new Vector2(0,0),0.1f,mask,-100,100);

    if (hit.collider != null)
    {
      hoverTile = hit.collider.gameObject;
    }
  }
  public bool TowerCheck()
  {
    bool towerOnSlot = false;
    Vector2 mousePosition = GetMousePosition();
    RaycastHit2D hit = Physics2D.Raycast(mousePosition,new Vector2(0,0),0.1f,mask,-100,100);

    if (hit.collider != null)
    {
      towerOnSlot = true;
    }
  }

  public void startBuild()
  {
    IsBuilding = true;
    TowerPlacement = Instantiate(basicTowerObject);
  }
  public void EndBuild()
  {
    IsBuilding = false;
  }


  public void update()
  {
    //Debug.Log(GetMousePosition());
      //startBuild();
      if (IsBuilding == true)
      {
        if(TowerPlacement != null)
        {
          GetCurrentHoverTile();
          TowerPlacement.transform.position = hoverTile.transform.position;
        }
      }
  }
}
*/
