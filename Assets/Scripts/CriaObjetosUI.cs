using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CriaObjetosUI : MonoBehaviour
{

    public GameObject[] objetos;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("TiroObjeto", 2f, 2f);
    }

    void TiroObjeto()
    {
        Instantiate(objetos[Random.Range(0,3)],transform.position,Quaternion.identity);
    }
}
