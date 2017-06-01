using UnityEngine;
using System.Collections;

public class DamageSniper : MonoBehaviour
{
    public float scaleLimit = 0.0f;
    public float z = 100f;
    public float rayTime = .5f;
    public int force = 10;
    public int count = 30;
    public LineRenderer laserLineRenderer;
    private bool allowedToFire = true;
    public float fireRate = 1.0f;
    public float laserWidth = 0.1f;
    public float laserMaxLength = 5f;
    int timer;
   // private float rotY = 0.0f; // rotation around the up/y axis
    //private float rotX = 0.0f; // rotation around the right/x axis
    private bool isRunning = false;
    // Update is called once per frame
    void Start()
    {
        StartCoroutine("WaitTime");
    }
    IEnumerator WaitTime ()
    {
        yield return new WaitForSeconds(fireRate);
        allowedToFire = true;
    }
   
    


    void Update()
    {   
        if (Input.GetKey(KeyCode.LeftShift))
        {
            isRunning = true;
        }
        else
        {
            isRunning = false;
        }
        timer++;
        if (Input.GetButtonDown("Fire1") && allowedToFire == true && isRunning == false)
            for (int i = 0; i < count; i++)
            {
                
                shootRay();


                
            }




    }

    void shootRay()
    {
        allowedToFire = false;
        
        float randomRadius = Random.Range(0, 0);
        float randomAngle = Random.Range(0, 0);
        Vector3 direction = new Vector3(
            randomRadius * Mathf.Cos(randomAngle),-1, z);
        direction = transform.TransformDirection(direction.normalized);
        Ray r = new Ray(transform.position, direction);
        RaycastHit hit;
        if (Physics.Raycast(r, out hit))
        {
            if (hit.rigidbody)
                hit.rigidbody.AddForceAtPosition(force * direction, hit.point);
            //Debug.DrawLine(transform.position, hit.point, Color.blue, rayTime);
            StartCoroutine("WaitTime");
            //Debug.Log(allowedToFire);


        }


    }



}

