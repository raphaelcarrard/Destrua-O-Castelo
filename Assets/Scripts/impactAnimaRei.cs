using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class impactAnimaRei : MonoBehaviour
{

    private Animator animacoes;
    private int limite = -1;
    public string[] clips;
    [SerializeField]
    private GameObject bomba, pontos1000;

    // Start is called before the first frame update
    void Start()
    {
        animacoes = GetComponent<Animator>();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (GameManager.instance.jogoComecou == true)
        {
            if (col.relativeVelocity.magnitude > 1 && col.relativeVelocity.magnitude < 6)
            {
                if (limite < clips.Length - 1)
                {
                    limite++;
                    animacoes.Play(clips[limite]);
                }
                else if (limite == clips.Length - 1)
                {
                    Instantiate(pontos1000, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
                    Instantiate(bomba, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
                    if (GameManager.instance.numReisCena < 0) 
                    {
                        GameManager.instance.numReisCena = 0;
                    }
                    Destroy(gameObject);
                    GameManager.instance.numReisCena -= 1;
                    GameManager.instance.morteReis += 1;
                    GameManager.instance.pontosGame += 1000;
                    UIManager.instance.pontosTxt.text = GameManager.instance.pontosGame.ToString();
                }
            }
            else if (col.relativeVelocity.magnitude > 10 && (col.gameObject.CompareTag("Player")))
            {
                Instantiate(pontos1000, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
                Instantiate(bomba, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
                Destroy(gameObject);
                GameManager.instance.numReisCena -= 1;
                GameManager.instance.morteReis += 1;
                if (GameManager.instance.numReisCena < 0)
                {
                    GameManager.instance.numReisCena = 0;
                }
                GameManager.instance.pontosGame += 1000;
                UIManager.instance.pontosTxt.text = GameManager.instance.pontosGame.ToString();
            }
            else if (col.gameObject.CompareTag("clone"))
            {
                Instantiate(pontos1000, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
                Instantiate(bomba, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
                Destroy(gameObject);
                GameManager.instance.numReisCena -= 1;
                GameManager.instance.morteReis += 1;
                if (GameManager.instance.numReisCena < 0)
                {
                     GameManager.instance.numReisCena = 0;
                }
                GameManager.instance.pontosGame += 1000;
                UIManager.instance.pontosTxt.text = GameManager.instance.pontosGame.ToString();
            }
        }
    }
}
