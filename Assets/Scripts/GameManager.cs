using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    //public io.newgrounds.core ngio_core;

    public static GameManager instance;
    public GameObject[] objetos;
    public int objetosNum;
    public int objetosEmCena = 0;
    public Transform pos;
    public bool win;
    public bool jogoComecou;
    public string nomeObjeto;
    public bool objetoLancado = false;
    public Transform objE, objD;
    public int numReisCena;
    private bool tocaWin = false, tocaLose = false;
    public bool lose;
    public bool estrela1Fim, estrela2Fim;
    public int aux;
    public int estrelasNum;
    public bool trava = false;
    public int pontosGame, bestPontoGame;
    public bool pausado = false;
    public int morteReis;

    void Awake() 
        {
            ZPlayerPrefs.Initialize("863874", "destruaocastelogame");
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
    } 

    /*void unlockMedal(int medal_id) {
        io.newgrounds.components.Medal.unlock medal_unlock = new io.newgrounds.components.Medal.unlock();
        medal_unlock.id = medal_id;
        medal_unlock.callWith(ngio_core, onMedalUnlocked);
    }

    void onMedalUnlocked(io.newgrounds.results.Medal.unlock result) {
        io.newgrounds.objects.medal medal = result.medal;
        Debug.Log( "Medal Unlocked: " + medal.name + " (" + medal.value + " points)" );
    }*/

    void Carrega(Scene cena, LoadSceneMode modo)
    {
        //ngio_core = GameObject.Find("Newgrounds.io Object").GetComponent<io.newgrounds.core>();
        if (OndeEstou.instance.fase != 0 && OndeEstou.instance.fase != 25 && OndeEstou.instance.fase != 26 && OndeEstou.instance.fase != 27 && OndeEstou.instance.fase != 28)
        {
            pos = GameObject.FindWithTag("pos").GetComponent<Transform>();
            objE = GameObject.FindWithTag("PE").GetComponent<Transform>();
            objD = GameObject.FindWithTag("PD").GetComponent<Transform>();
            //Objeto pos
            StartGame();
            objetosNum = GameObject.FindGameObjectsWithTag("Player").Length;
            objetos = new GameObject[objetosNum];

            for (int x = 0; x < GameObject.FindGameObjectsWithTag("Player").Length; x++)
            {
                objetos[x] = GameObject.Find("Pedra" + x);
            }
            numReisCena = GameObject.FindGameObjectsWithTag("rei").Length;
            aux = objetosNum;
        }
    }

    void NascObjeto()
    {
        if (objetosEmCena == 0 && objetosNum > 0)
        {
            for (int x=0; x < objetos.Length; x++)
            {
                if (objetos[x] != null)
                {
                    if (objetos[x].transform.position != pos.position && objetosEmCena == 0)
                    {
                        nomeObjeto = objetos[x].name;
                        objetos[x].transform.position = pos.position;
                        objetosEmCena = 1;
                    }
                }
            }
        }
    }

    void GameOver()
    {
        if (OndeEstou.instance.fase != 0 && OndeEstou.instance.fase != 25 && OndeEstou.instance.fase != 26 && OndeEstou.instance.fase != 27 && OndeEstou.instance.fase != 28)
        {
            jogoComecou = false;
            UIManager.instance.painelGameOver.Play("MenuLoseAnimado");
            if (!UIManager.instance.loseSom.isPlaying && tocaLose == false)
            {
                UIManager.instance.loseSom.Play();
                tocaLose = true;
            }
        }
    }

    void WinGame()
    {
        if (OndeEstou.instance.fase != 0 && OndeEstou.instance.fase != 25 && OndeEstou.instance.fase != 26 && OndeEstou.instance.fase != 27 && OndeEstou.instance.fase != 28)
        {
            if (jogoComecou != false)
            {
                int tempOnde = OndeEstou.instance.fase + 1;
                ZPlayerPrefs.SetInt("Level" + tempOnde + "_" + OndeEstou.instance.faseMestra, 1);
                jogoComecou = false;
                UIManager.instance.painelWin.Play("MenuWinAnimado");
                if (!UIManager.instance.winSom.isPlaying && tocaWin == false)
                {
                    UIManager.instance.winSom.Play();
                    tocaWin = true;
                }
                PointManager.instance.MelhorPontuacaoSave(OndeEstou.instance.faseN, pontosGame);
            }
            if (tocaWin && !UIManager.instance.winSom.isPlaying && trava == false)
            {
                if (objetosNum >= aux - 1)
                {
                    UIManager.instance.estrela1.Play("Estrela1_Animada");

                    if (estrela1Fim)
                    {
                        UIManager.instance.estrela2.Play("Estrela2_Animada");

                        if (estrela2Fim)
                        {
                            UIManager.instance.estrela3.Play("Estrela3_Animada");
                            trava = true;
                            UIManager.instance.winBtnMenu.interactable = true;
                            UIManager.instance.winBtnNovamente.interactable = true;
                            UIManager.instance.winBtnProximo.interactable = true;
                        }
                    }
                    estrelasNum = 3;
                }
                else if (objetosNum == aux - 2)
                {
                    UIManager.instance.estrela1.Play("Estrela1_Animada");
                    if (estrela1Fim)
                    {
                        UIManager.instance.estrela2.Play("Estrela2_Animada");
                        trava = true;
                        UIManager.instance.winBtnMenu.interactable = true;
                        UIManager.instance.winBtnNovamente.interactable = true;
                        UIManager.instance.winBtnProximo.interactable = true;
                    }
                    estrelasNum = 2;
                }
                else if (objetosNum <= aux - 3)
                {
                    UIManager.instance.estrela1.Play("Estrela1_Animada");
                    estrelasNum = 1;
                    trava = true;
                    UIManager.instance.winBtnMenu.interactable = true;
                    UIManager.instance.winBtnNovamente.interactable = true;
                    UIManager.instance.winBtnProximo.interactable = true;
                }
                else
                {
                    estrelasNum = 0;
                    trava = true;
                }

                if (!ZPlayerPrefs.HasKey(OndeEstou.instance.faseN + "estrelas"))
                {
                    ZPlayerPrefs.SetInt(OndeEstou.instance.faseN + "estrelas", estrelasNum);
                }
                else
                {
                    if (ZPlayerPrefs.GetInt(OndeEstou.instance.faseN + "estrelas") < estrelasNum)
                    {
                        ZPlayerPrefs.SetInt(OndeEstou.instance.faseN + "estrelas", estrelasNum);
                    }
                }
            }
        }
    }

    void StartGame()
    {
            jogoComecou = true;
            objetosEmCena = 0;
            win = false;
            lose = false;
            trava = false;
            objetoLancado = false;
            tocaLose = false;
            tocaWin = false;
            estrela1Fim = false;
            estrela2Fim = false;
            pontosGame = 0;
            bestPontoGame = PointManager.instance.MelhorPontuacaoLoad(OndeEstou.instance.faseN);
            UIManager.instance.pontosTxt.text = pontosGame.ToString();
            UIManager.instance.bestPontoTxt.text = bestPontoGame.ToString();
            UIManager.instance.winBtnMenu.interactable = false;
            UIManager.instance.winBtnNovamente.interactable = false;
            UIManager.instance.winBtnProximo.interactable = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        StartGame();
    }

    // Update is called once per frame
    void Update()
    {
        if (numReisCena <= 0 && objetosNum > 0)
        {
            win = true;
        }else if (numReisCena > 0 && objetosNum <= 0)
        {
            lose = true;
        }

        if (win)
        {
            WinGame();
        }
        else if (lose)
        {
            GameOver();
        }

        if(jogoComecou)
        {
            NascObjeto();
        }

        /*if(morteReis == 25){
            unlockMedal(70884);
        }*/
    }
}
