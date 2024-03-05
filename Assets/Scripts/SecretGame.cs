using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SecretGame : MonoBehaviour
{
    private string[] secretCode;
    private int index;

    void Start(){
        secretCode = new string[] { "f", "n", "f" };
        index = 0;
    }

    void Update(){
        if(Input.anyKeyDown){
            if(Input.GetKeyDown(secretCode[index])){
                index++;
            }
            else
            {
                index = 0;
            }
        }

        if(index == secretCode.Length){
            NGHelper.instance.unlockMedal(77647);
            SceneManager.LoadScene(29);
        }
    }
}
