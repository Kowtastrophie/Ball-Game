using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumping : MonoBehaviour
{

    private bool canJump = false;
    public float jumpAmount = 10;
    void start()
    {
        if (Input.GetKey(KeyCode.Space) && canJump == true)
        {

            GetComponent<Rigidbody>().AddForce(transform.up * jumpAmount, ForceMode.Impulse);

        }

    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Ground")
        {
            canJump = true;

        }
        else
        {
            canJump = false;
        }
    }
}






