using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shredder : MonoBehaviour
{

    void OnTriggerEnter(Collider col)
    {
       Destroy(col.gameObject);
    }
}