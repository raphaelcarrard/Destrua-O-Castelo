using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointManager : MonoBehaviour
{

    public static PointManager instance;

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
    }

    public void MelhorPontuacaoSave(string level,int pt)
    {
            if (!ZPlayerPrefs.HasKey(level + "best" + OndeEstou.instance.faseMestra))
            {
                ZPlayerPrefs.SetInt(level + "best" + OndeEstou.instance.faseMestra, pt);
            }
            else
            {
                if (GameManager.instance.pontosGame > ZPlayerPrefs.GetInt(level + "best" + OndeEstou.instance.faseMestra))
                {
                    ZPlayerPrefs.SetInt(level + "best" + OndeEstou.instance.faseMestra, GameManager.instance.pontosGame);
                }
        }
    }

    public int MelhorPontuacaoLoad(string level)
    {
        if (ZPlayerPrefs.HasKey(level + "best" + OndeEstou.instance.faseMestra))
        {
            return ZPlayerPrefs.GetInt(level + "best" + OndeEstou.instance.faseMestra);
        }else
        {
            return 0;
        }
    }
}
