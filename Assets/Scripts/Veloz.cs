using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Veloz : MonoBehaviour
{

    public Rigidbody2D pedraRb;
    public bool libera = false;
    public int trava = 0;
    private Touch touch;

    // Start is called before the first frame update
    void Start()
    {
        pedraRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Mouse

        if(Input.GetMouseButtonDown(0) && pedraRb.isKinematic == false && trava == 0){
            libera = true;
            trava = 1;
        }

        //Touch
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Ended && trava < 2 && pedraRb.isKinematic == false)
            {
                trava++;
                if (trava == 2)
                {
                    libera = true;
                }
            }
        }
    }

    void FixedUpdate()
    {
        if (libera)
        {
            pedraRb.velocity = pedraRb.velocity * 1.5f;
            libera = false;
        }
    }
}