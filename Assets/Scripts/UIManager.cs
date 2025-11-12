using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{

    public static UIManager instance;

    public Animator painelGameOver, painelWin, painelPause;
    public Button winBtnMenu, winBtnNovamente, winBtnProximo;
    public Animator estrela1, estrela2, estrela3;
    [SerializeField]
    private Button loseBtnMenu, loseBtnNovamente;
    [SerializeField]
    private Button pauseBtn, pauseBtnPlay, pauseBtnNovamente, pauseBtnMenu;
    public AudioSource winSom;
    public AudioSource loseSom;
    public Text pontosTxt, bestPontoTxt;
    private Image fundoPreto; 

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
        SceneManager.sceneLoaded += Carrega;
        DadosParaCarregamento();
    }

    void Carrega(Scene cena, LoadSceneMode modo)
    {
        DadosParaCarregamento();
    }

    void DadosParaCarregamento()
    {
        if (OndeEstou.instance.fase != 0 && OndeEstou.instance.fase != 25 && OndeEstou.instance.fase != 26 && OndeEstou.instance.fase != 27 && OndeEstou.instance.fase != 28 && OndeEstou.instance.fase != 29)
        {
            //Painel
            painelGameOver = GameObject.Find("Menu_Lose").GetComponent<Animator>();
            painelWin = GameObject.Find("Menu_Win").GetComponent<Animator>();
            painelPause = GameObject.Find("Painel_Pause").GetComponent<Animator>();
            //Btn Win
            winBtnMenu = GameObject.Find("Button_Menu").GetComponent<Button>();
            winBtnNovamente = GameObject.Find("Button_Novamente").GetComponent<Button>();
            winBtnProximo = GameObject.Find("Button_Avancar").GetComponent<Button>();
            //Estrelas
            estrela1 = GameObject.Find("Estrela1_Win").GetComponent<Animator>();
            estrela2 = GameObject.Find("Estrela2_Win").GetComponent<Animator>();
            estrela3 = GameObject.Find("Estrela3_Win").GetComponent<Animator>();
            //Btn Lose
            loseBtnMenu = GameObject.Find("Button_MenuL").GetComponent<Button>();
            loseBtnNovamente = GameObject.Find("Button_NovamenteL").GetComponent<Button>();
            //Btn Pause
            pauseBtn = GameObject.Find("Pause").GetComponent<Button>();
            pauseBtnPlay = GameObject.Find("Play").GetComponent<Button>();
            pauseBtnNovamente = GameObject.Find("Again").GetComponent<Button>();
            pauseBtnMenu = GameObject.Find("Scene").GetComponent<Button>();
            //audio
            winSom = painelWin.GetComponent<AudioSource>();
            loseSom = painelGameOver.GetComponent<AudioSource>();
            //Pontos
            pontosTxt = GameObject.FindWithTag("pointVal").GetComponent<Text>();
            bestPontoTxt = GameObject.FindWithTag("ptBest").GetComponent<Text>();
            //Imagem de fundo preto
            fundoPreto = GameObject.FindWithTag("fundoPreto").GetComponent<Image>();
            //Eventos
            //Pause
            pauseBtn.onClick.AddListener(Pausar);
            pauseBtnPlay.onClick.AddListener(PausarInverso);
            pauseBtnNovamente.onClick.AddListener(Novamente);
            pauseBtnMenu.onClick.AddListener(VoltarAoMenu);
            //Lose
            loseBtnMenu.onClick.AddListener(VoltarAoMenu);
            loseBtnNovamente.onClick.AddListener(Novamente);
            //Win
            winBtnMenu.onClick.AddListener(VoltarAoMenu);
            winBtnNovamente.onClick.AddListener(Novamente);
            winBtnProximo.onClick.AddListener(ProximoLevel);
        }
    }

    //Método de pausar o jogo
    void Pausar()
    {
            GameManager.instance.pausado = true;
            Time.timeScale = 0;
            fundoPreto.enabled = true;
            painelPause.Play("MenuPauseAnim");
    }

    void PausarInverso()
    {
        GameManager.instance.pausado = false;
        Time.timeScale = 1;
        fundoPreto.enabled = false;
        painelPause.Play("MenuPauseAnimInverse");
    }

    //Método de jogar novamente no menu de pausa
    void Novamente()
    {
        SceneManager.LoadScene(OndeEstou.instance.fase);
        Time.timeScale = 1;
        GameManager.instance.pausado = false;
    }

    //Método para voltar ao menu de fases no menu de pausa
    void VoltarAoMenu()
    {
        if (OndeEstou.instance.faseMestra == "Mestra1")
        {
            SceneManager.LoadScene("Mestra1");
        }else if (OndeEstou.instance.faseMestra == "Mestra2")
        {
            SceneManager.LoadScene("Mestra2");
        }
        Time.timeScale = 1;
        GameManager.instance.pausado = false;
        AudioManager.instance.GetSom(1);
    }

    //Método para avançar para a próxima fase
    void ProximoLevel()
    {
        if (OndeEstou.instance.faseN == "Level12_Mestra1")
        {
            SceneManager.LoadScene("MenuFasesPai");
            AudioManager.instance.GetSom(1);
        }
        else if(OndeEstou.instance.faseN == "Level24_Mestra2")
        {
            SceneManager.LoadScene("MenuFasesPai");
            AudioManager.instance.GetSom(1);
        } 
        else 
        {
            SceneManager.LoadScene(OndeEstou.instance.fase + 1);
        }
    }

    public void DesativaBotãoPause()
    {
        if (pauseBtn == null) return;
        pauseBtn.gameObject.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {

    }
}
