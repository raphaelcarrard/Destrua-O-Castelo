using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LoadingInfo : MonoBehaviour
{

    //public io.newgrounds.core ngio_core;

    public TextMeshProUGUI txtComp;

    /*void unlockMedal(int medal_id) {
        io.newgrounds.components.Medal.unlock medal_unlock = new io.newgrounds.components.Medal.unlock();
        medal_unlock.id = medal_id;
        medal_unlock.callWith(ngio_core, onMedalUnlocked);
    }

    void onMedalUnlocked(io.newgrounds.results.Medal.unlock result) {
        io.newgrounds.objects.medal medal = result.medal;
        Debug.Log( "Medal Unlocked: " + medal.name + " (" + medal.value + " points)" );
    }*/

    void Start()
    {

    }

    public void BtnClick(string s)
    {
        //unlockMedal(70880);
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

    public void MySocialNetworks()
    {
        //unlockMedal(70881);
        Application.OpenURL("linktr.ee/raphaelcarrard");
    }

    public void SairDoJogo()
    {
        Application.Quit();
    }
}
