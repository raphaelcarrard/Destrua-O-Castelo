﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoom : MonoBehaviour
{

    public float orthoZoomSpeed = 1f;
    public bool liberaZoom;
    public int trava = 1;
    public bool um_click = false;
    public float tempoParaDuploClick;
    public float delay = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (GameManager.instance.jogoComecou && GameManager.instance.pausado == false) {
            if (Input.GetMouseButtonDown(0))
            {
                if (um_click == false)
                {
                    um_click = true;
                    tempoParaDuploClick = Time.time;
                }
                else
                {
                    um_click = false;
                    liberaZoom = true;
                }
            }

            if (um_click == true)
            {
                if ((Time.time - tempoParaDuploClick) > delay)
                {
                    um_click = false;
                }
            }
        }



        if (Camera.main.orthographicSize > CameraSizeHandler.camSize/2 && trava == 1)
        {
            if (liberaZoom)
            {
                Camera.main.orthographicSize -= orthoZoomSpeed;
                if (Camera.main.orthographicSize <= CameraSizeHandler.camSize / 2)
                {
                    liberaZoom = false;
                    trava = 2;
                }
            }
        }else if (Camera.main.orthographicSize < CameraSizeHandler.camSize && trava == 2)
        {
            if (liberaZoom)
            {
                Camera.main.orthographicSize += orthoZoomSpeed;
                if (Camera.main.orthographicSize == CameraSizeHandler.camSize)
                {
                    liberaZoom = false;
                    trava = 1;
                }
            }
        }
    }
}
