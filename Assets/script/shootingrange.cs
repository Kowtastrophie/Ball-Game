using UnityEngine;
using System.Collections;
using System;
public class shootingrange : MonoBehaviour
{
    public Rigidbody projectile;
    public float speed = 1;

    private static System.Timers.Timer life;
    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.Space))
        {
            //Debug.Log(transform.position);
            Rigidbody instantiatedProjectile = Instantiate(projectile, transform.position, transform.rotation) as Rigidbody;
            instantiatedProjectile.velocity = Camera.main.transform.forward * speed;
            instantiatedProjectile.name = "projectileclone";
        }




    }
}