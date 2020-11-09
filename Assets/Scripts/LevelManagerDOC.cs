using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManagerDOC : MonoBehaviour
{
    public static LevelManagerDOC instance;
    private int levelsMestre1 = 0, levelsMestre2 = 2;

    void Awake()
    {
        ZPlayerPrefs.Initialize("863874", "destruaocastelogame");
        if (instance==null)
        {
            instance = this;
        }
    }

    void Start()
    {
        ListaAdd();
    }

    void Update()
    {

    }

    [System.Serializable]
    public class Level
    {
        public string levelText;
        public bool habilitado;
        public int desbloqueado;
        public bool txtAtivo;
        public string levelReal;
    }

    public GameObject botao;
    public Transform localBtn;
    public List<Level> levelList;

    void ListaAdd()
    {
        foreach(Level level in levelList)
        {
            GameObject btnNovo = Instantiate(botao) as GameObject;
            botaoLevel btnNew = btnNovo.GetComponent<botaoLevel>();
            btnNew.levelTxtBtn.text = level.levelText;
            btnNew.realLevel = level.levelReal;
            if (ZPlayerPrefs.GetInt("Level"+ btnNew.realLevel + "_" + OndeEstou.instance.faseMestra) == 1)
            {
                level.desbloqueado = 1;
                level.habilitado = true;
                level.txtAtivo = true;
            }
            btnNew.desbloqueadoBtn = level.desbloqueado;
            btnNew.GetComponent<Button>().interactable = level.habilitado;
            btnNew.GetComponentInChildren<Text>().enabled = level.txtAtivo;
            btnNew.GetComponent<Button>().onClick.AddListener(() => ClickLevel("Level" + level.levelReal + "_" + OndeEstou.instance.faseMestra));
            if (ZPlayerPrefs.GetInt("Level" + btnNew.realLevel + "_" + OndeEstou.instance.faseMestra + "estrelas") == 1) {
                btnNew.estrela1.enabled = true;
            }else if (ZPlayerPrefs.GetInt("Level" + btnNew.realLevel + "_" + OndeEstou.instance.faseMestra + "estrelas") == 2)
            {
                btnNew.estrela1.enabled = true;
                btnNew.estrela2.enabled = true;
            }else if (ZPlayerPrefs.GetInt("Level" + btnNew.realLevel + "_" + OndeEstou.instance.faseMestra + "estrelas") == 3)
            {
                btnNew.estrela1.enabled = true;
                btnNew.estrela2.enabled = true;
                btnNew.estrela3.enabled = true;
            }else if (ZPlayerPrefs.GetInt("Level" + btnNew.realLevel + "_" + OndeEstou.instance.faseMestra + "estrelas") == 0)
            {
                btnNew.estrela1.enabled = false;
                btnNew.estrela2.enabled = false;
                btnNew.estrela3.enabled = false;
            }
            if (OndeEstou.instance.faseMestra == "Mestra1")
            {
                levelsMestre1++;
                ZPlayerPrefs.SetInt("FasesNumMestra1", levelsMestre1);
            }
            else if (OndeEstou.instance.faseMestra == "Mestra2")
            {
                levelsMestre2++;
                ZPlayerPrefs.SetInt("FasesNumMestra2", levelsMestre2);
            }
            btnNovo.transform.SetParent(localBtn,false);
        }
    }

    void ClickLevel(string level) 
    {
        AudioManager.instance.GetSom(0);
        SceneManager.LoadScene(level);
    }
}
