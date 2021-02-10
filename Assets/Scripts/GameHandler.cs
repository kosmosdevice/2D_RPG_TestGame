using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey;
using CodeMonkey.Utils;

public class GameHandler : MonoBehaviour {

    private void Start() {
        Debug.Log("GameHandler.Start");

        int i = 0;
        FunctionPeriodic.Create(() => {
            CMDebug.TextPopupMouse("Ding "+i+"!");
            i++;
        }, .5f);
    }

    private void Update() {
        
    }

}
