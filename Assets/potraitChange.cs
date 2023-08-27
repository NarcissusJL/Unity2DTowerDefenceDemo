using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class potraitChange : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite oldSprite;
    public Sprite newSprite;
    public bool change = true;
    public void ChangeSprite()
    {
        if(change){
            spriteRenderer.sprite = newSprite;
            change = false;
        }else{
            spriteRenderer.sprite = oldSprite;
            change =true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
