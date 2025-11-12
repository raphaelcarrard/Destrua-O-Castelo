using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Impulso : MonoBehaviour
{

    private Rigidbody2D objeto;

    // Start is called before the first frame update
    void Start()
    {
        objeto = GetComponent<Rigidbody2D>();
        objeto.AddForce(new Vector2(Random.Range(5,11),Random.Range(5,11)), ForceMode2D.Impulse);
    }
}
