using UnityEngine;
using System.Collections;

public class fakeshotgun : MonoBehaviour
{
    public Rigidbody Pellet;
    public float speed = 100;


    public int pelletamount = 10;
    public float spread = 0.5f;




    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
            for (int i = 0; i < pelletamount; i++)
                if (i <= pelletamount)
                {
                    Rigidbody instantiatedProjectile = Instantiate(Pellet, transform.position, transform.rotation) as Rigidbody;
                    instantiatedProjectile.velocity = Camera.main.transform.forward + new Vector3
                                (Random.Range(-spread * Camera.main.transform.forward.x, Camera.main.transform.forward.x * spread),
                                Random.Range(Camera.main.transform.forward.y * -spread, Camera.main.transform.forward.y * spread),
                                Random.Range(Camera.main.transform.forward.z * -spread, Camera.main.transform.forward.z * spread)) * speed;
                    instantiatedProjectile.tag = "Pellet";
                }






    }
}
