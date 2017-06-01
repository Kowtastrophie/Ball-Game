using UnityEngine;
using System.Collections;
using System;
public class BlowBubbles : MonoBehaviour
{
    public Rigidbody projectile;
    public float speed = 1;
    public int amount = 10;
    private static System.Timers.Timer life;
    private float radius = 0f;
    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
    
                shoot(1);
        }





    }
    private void shoot(int times)
    {
        for (int i = 0; i < times; i++)
        {
            //float randomRadius = Random.Range(0, scaleLimit);
            Rigidbody instantiatedProjectile = Instantiate(projectile, transform.position, transform.rotation) as Rigidbody;

            //GetComponent<Rigidbody>(radius += .1f);
        }
    }




}