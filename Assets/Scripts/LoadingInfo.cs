﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LoadingInfo : MonoBehaviour
{

    public TextMeshProUGUI txtComp;

    public void BtnClick(string s)
    {
        if(s == "Menu1"){
            NGHelper.instance.unlockMedal(70880);
        }
        StartCoroutine(LoadGameProg(s));
    }

    IEnumerator LoadGameProg(string val)
    {
        AsyncOperation async = SceneManager.LoadSceneAsync(val);

        while (!async.isDone)
        {
            txtComp.enabled = true;
            yield return null;
        }
    }
    public void SairDoJogo()
    {
        Application.Quit();
    }
}
