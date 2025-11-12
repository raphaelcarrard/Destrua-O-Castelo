using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public static AudioManager instance;

    public AudioClip[] clip;
    public AudioSource audioS;

    public int pause = -1;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        audioS = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        if (pause == 1)
        {
            audioS.Pause();
        }
        else if (!audioS.isPlaying)
        {
            audioS.Play();
        }
        if(OndeEstou.instance.fase == 29){
            Destroy(gameObject);
        }
    }

    public void GetSom(int clips)
    {
        if (clips == 0)
        {
            audioS.clip = clip[0];
            audioS.loop = true;
            audioS.Play();
        }else if (clips == 1)
        {
            audioS.clip = clip[1];
            audioS.loop = true;
            audioS.Play();
        }
    }
}
