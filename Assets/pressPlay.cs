using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pressPlay : MonoBehaviour
{
    // Start is called before the first frame update
    bool tectOn = true;

    public void TurnOffText(){
        if(tectOn){
            gameObject.SetActive(false);
        }
    }
}
