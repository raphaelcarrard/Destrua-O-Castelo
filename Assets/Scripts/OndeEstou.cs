using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OndeEstou : MonoBehaviour
{

    public static OndeEstou instance;
    public int fase = -1;
    public string faseN;
    public string faseMestra;
    public Button bntM1, btnM2;

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
        SceneManager.sceneLoaded += VerificaFase;
    }

    void VerificaFase(Scene cena, LoadSceneMode modo)
    {
        fase = SceneManager.GetActiveScene().buildIndex;
        faseN = SceneManager.GetActiveScene().name;
        if (faseN == "MenuFasesPai")
        {
            bntM1 = GameObject.Find("ButtonM1").GetComponent<Button>();
            btnM2 = GameObject.Find("ButtonM2").GetComponent<Button>();
            bntM1.onClick.AddListener(() => Mestra("Mestra1"));
            btnM2.onClick.AddListener(() => Mestra("Mestra2"));
        }
    }

    //Mestra
    public void Mestra(string nome)
    {
        faseMestra = nome;
        SceneManager.LoadScene(faseMestra);
    }
}
