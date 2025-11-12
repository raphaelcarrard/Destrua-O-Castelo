using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MorteTudo : MonoBehaviour
{



    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(morte());
    }

    IEnumerator morte()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }
}
