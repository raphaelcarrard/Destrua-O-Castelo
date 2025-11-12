using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PausaAudio : MonoBehaviour
{

    public Image btn;

    // Update is called once per frame
    void Update()
    {
        if (AudioManager.instance.pause == 1)
        {
            btn.color = new Color(0.2f, 0.2f, 0.2f, 0.5f);
        }
        else
        {
            btn.color = new Color(1, 1, 1, 1);
        }
    }

    public void PausarSom()
    {
        AudioManager.instance.pause *= -1;
        Btn_Confs.instance.liga = false;
        Btn_Confs.instance.animaConf.Play("ConfAnimInverse");
        Btn_Confs.instance.animaEngre.Play("AnimaEngrenagemInverse");
    }
}
