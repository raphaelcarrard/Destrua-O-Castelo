using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuebraParentesco : MonoBehaviour
{

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Untagged"))
        {
            transform.DetachChildren();
        }
    }
}
