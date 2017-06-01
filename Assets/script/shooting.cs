using UnityEngine;
using System.Collections;
using System;
public class shooting : MonoBehaviour
{
    public Rigidbody projectile;
    public float speed = 1;
    public int amount = 10;
    private static System.Timers.Timer life;
    // Update is called once per frame
    void Update()
    {
       
        if (Input.GetButton("Fire1"))
        {
            for (int i = 0; i < amount; i++)
                //Debug.Log(transform.position);
                shoot(1);
        }
  
     



    }
    private void shoot(int times)
    {
        for (int i = 0; i < times; i++)
        {
            //float randomRadius = Random.Range(0, scaleLimit);
            Rigidbody instantiatedProjectile = Instantiate(projectile, transform.position, transform.rotation) as Rigidbody;
            instantiatedProjectile.velocity = Camera.main.transform.forward * speed;
            instantiatedProjectile.name = "projectileclone";
        
        }
    }




}