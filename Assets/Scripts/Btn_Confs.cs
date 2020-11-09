using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Btn_Confs : MonoBehaviour
{

    public static Btn_Confs instance;

    void Awake()
    {
        if (instance==null)
        {
            instance = this;
        }
    }

    public bool liga = false;
    public Animator animaConf, animaEngre;

    public void ClickBtn()
    {
        liga = !liga;
        if (liga)
        {
            animaConf.Play("ConfAnim");
            animaEngre.Play("AnimaEngrenagem");
        }
        else
        {
            animaConf.Play("ConfAnimInverse");
            animaEngre.Play("AnimaEngrenagemInverse");
        }
    }
}
