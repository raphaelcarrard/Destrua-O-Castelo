using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MataRastro : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        MataRastroObjeto();
    }

    void MataRastroObjeto()
    {
        if (GameManager.instance.objetoLancado)
        {
            if (transform.parent == null)
            {
                Destroy(gameObject,10.0f);
            }
        }
    }
}
