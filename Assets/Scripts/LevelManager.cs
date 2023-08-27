using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
  [SerializeField]
  private GameObject tile;
  public float TileWidth
  {
    get { return tile.GetComponent<SpriteRenderer>().sprite.bounds.size.x;}
  }



    // Start is called before the first frame update
    void Start()
    {
      CreateLevel();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void CreateLevel()
    {
      Vector3 StartPosition = Camera.main.ScreenToWorldPoint(new Vector3(0,Screen.height));

      for(int y = 0; y < 10; y++)
      {
        for(int x = 0; x < 10; x++)
        {
          PlaceTile(x,y,StartPosition);
        }
      }
    }
    private void PlaceTile(int x, int y, Vector3 StartPosition)
    {
      GameObject newTile = Instantiate(tile);
      newTile.transform.position = new Vector3(StartPosition.x + (TileWidth*x) , StartPosition.y - (TileWidth*y) , 0);
    }





}
