using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Multiplo : MonoBehaviour
{

    private Vector3 start;
    public Rigidbody2D pedra1, pedra2, pedraRb, pedraPrefb;
    private bool libera = false;
    public int trava = 0;
    private Touch touch;
    private TrailRenderer rastro;

    // Start is called before the first frame update
    void Start()
    {

        pedraRb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        //Mouse
        if (Input.GetMouseButtonDown(0) && pedraRb.isKinematic == false && trava == 0)
        {
            libera = true;
            start = transform.position;
            pedra1 = Instantiate(pedraPrefb, new Vector3(start.x, start.y + 0.1f, start.z),Quaternion.identity);
            pedra2 = Instantiate(pedraPrefb, new Vector3(start.x, start.y - 0.1f, start.z), Quaternion.identity);
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
                    start = transform.position;
                    pedra1 = Instantiate(pedraPrefb, new Vector3(start.x, start.y + 0.1f, start.z), Quaternion.identity);
                    pedra2 = Instantiate(pedraPrefb, new Vector3(start.x, start.y - 0.1f, start.z), Quaternion.identity);
                    libera = true;
                }
            }
        }
    }

    void FixedUpdate()
    {
        if (libera)
        {
            print("liberado");
            pedra1.velocity = pedraRb.velocity * 1.5f;
            pedraRb.velocity = pedraRb.velocity * 0.8f;
            pedra2.velocity = pedraRb.velocity * 1.1f;
            libera = false;
        }
    }
}
