using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;

public class GooglePlayGamesManager : MonoBehaviour
{
    
    public static GooglePlayGamesManager instance;
    public bool medal1, medal2, medal3, medal4, medal5;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        PlayGamesPlatform.Activate();
        Login();
    }

    public void Login()
    {
        PlayGamesPlatform.Instance.Authenticate(ProcessAuthentication);
    }

    internal void ProcessAuthentication(SignInStatus status)
    {
        if (status == SignInStatus.Success)
        {
            Debug.Log("Google Play Games connected with successfull");
        }
        else
        {
            Debug.Log("Google Play Games connection failed");
        }
    }

    public void ShowAchievements()
    {
        if (PlayGamesPlatform.Instance.localUser.authenticated)
        {
            PlayGamesPlatform.Instance.ShowAchievementsUI();
        }
        else
        {
            Login();
        }
    }

    public void CheckAchievements()
    {
        if (OndeEstou.instance.faseN == "Level6_Mestra1" && medal1 == false)
        {
            Debug.Log("Level 6 completed");
            //NGHelper.instance.unlockMedal(84720);
            //NGHelper.instance.unlockMedal(84721);
            PlayGamesPlatform.Instance.ReportProgress("CgkI0bKp9fgPEAIQAg", 100.0f, (bool success) => { });
            medal1 = true;
        }
        if (OndeEstou.instance.faseN == "Level12_Mestra1" && medal2 == false)
            {
            Debug.Log("Phase 1 completed");
            //NGHelper.instance.unlockMedal(84720);
            //NGHelper.instance.unlockMedal(84721);
            PlayGamesPlatform.Instance.ReportProgress("CgkI0bKp9fgPEAIQAw", 100.0f, (bool success) => { });
            medal2 = true;
        }
        if (OndeEstou.instance.faseN == "Level18_Mestra2" && medal3 == false)
        {
            Debug.Log("Level 18 completed");
            //NGHelper.instance.unlockMedal(84720);
            //NGHelper.instance.unlockMedal(84721);
            PlayGamesPlatform.Instance.ReportProgress("CgkI0bKp9fgPEAIQBA", 100.0f, (bool success) => { });
            medal3 = true;
        }
        if (OndeEstou.instance.faseN == "Level24_Mestra2" && medal4 == false)
        {
            Debug.Log("Phase 2 completed");
            //NGHelper.instance.unlockMedal(84720);
            //NGHelper.instance.unlockMedal(84721);
            PlayGamesPlatform.Instance.ReportProgress("CgkI0bKp9fgPEAIQBQ", 100.0f, (bool success) => { });
            medal4 = true;
        }
        if (OndeEstou.instance.faseN == "SecretRhythmGame" && medal5 == false)
        {
            Debug.Log("You found a secret game and unlocked a medal!");
            //NGHelper.instance.unlockMedal(84720);
            //NGHelper.instance.unlockMedal(84721);
            PlayGamesPlatform.Instance.ReportProgress("CgkI0bKp9fgPEAIQAQ", 100.0f, (bool success) => { });
            medal5 = true;
        }
    }
}
