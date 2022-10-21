using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TesteInp : MonoBehaviour
{

    public Animator animMenu, animE1, animE2, animE3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animMenu.Play("MenuWinAnimado");
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            animE1.Play("Estrela1_Animada");
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            animE2.Play("Estrela2_Animada");
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            animE3.Play("Estrela3_Animada");
        }
    }
}
