using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteObject : MonoBehaviour
{

    public bool canBePressed;
    public KeyCode keyToPress;
    public bool obtained;
    public GameObject hitEffect, goodEffect, perfectEffect, missEffect;

    void Start(){

    }

    void Update(){
        if(Input.GetKeyDown(keyToPress)){
            if(canBePressed){
                obtained = true;
                gameObject.SetActive(false);
                if(Mathf.Abs(transform.position.y) > 0.25){
                    Debug.Log("Hit");
                    RhythmGameManager.instance.NormalHit();
                    Instantiate(hitEffect, transform.position, hitEffect.transform.rotation);
                }
                else if(Mathf.Abs(transform.position.y) > 0.05f){
                    Debug.Log("Good");
                    RhythmGameManager.instance.GoodHit();
                    Instantiate(goodEffect, transform.position, goodEffect.transform.rotation);
                }
                else 
                {
                    Debug.Log("Perfect");
                    RhythmGameManager.instance.PerfectHit();
                    Instantiate(perfectEffect, transform.position, perfectEffect.transform.rotation);
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Activator"){
            canBePressed = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other){
        if(other.tag == "Activator"){
            canBePressed = false;
            if(!obtained){
                RhythmGameManager.instance.NoteMissed();
                Instantiate(missEffect, transform.position, missEffect.transform.rotation);
            }
        }
    }
}
