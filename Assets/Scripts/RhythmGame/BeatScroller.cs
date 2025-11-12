using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatScroller : MonoBehaviour
{

    public float beatTime;
    public bool hasStarted;

    // Start is called before the first frame update
    void Start()
    {
        beatTime = beatTime / 60f;
    }

    // Update is called once per frame
    void Update()
    {
        if(!hasStarted){
            if(Input.anyKeyDown){
                hasStarted = true;
            }
        }
        else
        {
            transform.position -= new Vector3(0f, beatTime * Time.deltaTime, 0f);
        }
    }
}
