using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class SecretGameButton : MonoBehaviour
{

    private GameObject btnBlock, nomeGame, nomeSecret, btnPlayGame, btnConf, btnAchiev, btnRapha, btnSecret;
    public TMP_InputField campoDeTexto;
    public Button botaoConfirmar;
    public string palavraCorreta = "fnf";
    public string nomeCenaDestino = "SecretRhythmGame";

    void Awake()
    {
        btnBlock = GameObject.Find("FechaSecret");
        btnBlock.SetActive(false);
        nomeGame = GameObject.FindWithTag("nomegame");
        nomeSecret = GameObject.Find("TitleSecret");
        nomeSecret.SetActive(false);
        btnConf = GameObject.Find("Conf");
        btnAchiev = GameObject.Find("GooglePlayAchievementButton");
        btnRapha = GameObject.Find("RaphaSiteButton");
        btnSecret = GameObject.Find("SecretGameButton");
        btnPlayGame = GameObject.Find("PlayGame");
	botaoConfirmar.gameObject.SetActive(false);
    }

    void Start()
    {
        botaoConfirmar.onClick.AddListener(VerificarPalavra);
    }

    public void VerificarPalavra()
    {
        string textoDigitado = campoDeTexto.text.Trim().ToLower();
        if (textoDigitado == palavraCorreta.ToLower())
        {
            SceneManager.LoadScene(nomeCenaDestino);
        }
        else
        {
            Debug.Log("Palavra Incorreta!");
        }
    }


    public void ActivateButton()
    {
        btnBlock.SetActive(true);
        nomeGame.SetActive(false);
        btnPlayGame.SetActive(false);
        btnConf.SetActive(false);
        btnAchiev.SetActive(false);
        btnRapha.SetActive(false);
        btnSecret.SetActive(false);
        nomeSecret.SetActive(true);
        campoDeTexto.gameObject.SetActive(true);
        botaoConfirmar.gameObject.SetActive(true);
    }

    public void DeactivateSecretFunction()
    {
        btnBlock.SetActive(false);
        nomeGame.SetActive(true);
        btnPlayGame.SetActive(true);
        btnConf.SetActive(true);
        btnAchiev.SetActive(true);
        btnRapha.SetActive(true);
        btnSecret.SetActive(true);
        nomeSecret.SetActive(false);
        campoDeTexto.gameObject.SetActive(false);
        botaoConfirmar.gameObject.SetActive(false);
    }
}
