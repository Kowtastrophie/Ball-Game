using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PelletCollider : MonoBehaviour
{
    public Rigidbody Pellet;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {



    }
    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Pellet")
        {
            Physics.IgnoreCollision(collision.collider, GetComponent<Collider>());
        }




    }
}