using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Estrelas_Audio : MonoBehaviour
{

    public AudioSource aSource;
    public AudioClip clip;
    public string nomeEstrela;

    public void TocaAudioEstrela()
    {
        if (!aSource.isPlaying)
        {
            aSource.clip = clip;
            aSource.Play();
        }
    }

    public void Verifica_Estrela()
    {
        switch (nomeEstrela)
        {
            case "Estrela1_Win":
                GameManager.instance.estrela1Fim = true;
                break;
            case "Estrela2_Win":
                GameManager.instance.estrela2Fim = true;
                break;
        }
    }
}
