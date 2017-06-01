using UnityEngine;
using System.Collections;

public class ShotgunDamage : MonoBehaviour
{
    public float scaleLimit = 5.0f;
    public float z = 100f;
    public float rayTime = .5f;
    public int force = 10;
    public int count = 30;
    public LineRenderer laserLineRenderer;
    private bool allowedToFire = true;
    public float fireRate = .05f;
    public float laserWidth = 0.05f;
    public float laserMaxLength = 5f;
    int timer;
    private float ammo = 200;
    public float reloadTime = 1.2f;
    public float maxAmmo = 200;
    private bool isRunning = false;

    // Update is called once per frame
    void Start()
    {
        Vector3[] initLaserPositions = new Vector3[2] { Vector3.zero, Vector3.zero };
        laserLineRenderer.SetPositions(initLaserPositions);
        laserLineRenderer.startWidth = laserWidth;
        laserLineRenderer.endWidth = laserWidth;
        StartCoroutine("WaitTime");
    }

    IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(fireRate);
        allowedToFire = true;
    }
    IEnumerator ReloadTime()
    {
        yield return new WaitForSeconds(reloadTime);
        ammo = maxAmmo;
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
        if (Input.GetButton("Fire2") && ammo > 0 && isRunning == false)
        {

            //Debug.Log("isRunning");


            shootRay();
        }

        else
        {
            laserLineRenderer.enabled = false;


        }
        if (Input.GetKey(KeyCode.R))
        {

            StartCoroutine("ReloadTime");

        }

    }

    void shootRay()
    {
        if (allowedToFire == true)
        {
            allowedToFire = false;
            float randomRadius = Random.Range(0, 0);
            float randomAngle = Random.Range(0, 2 * 0);
            Vector3 direction = new Vector3(
                randomRadius * Mathf.Cos(randomAngle), randomRadius * Mathf.Sin(randomAngle), z);
            direction = transform.TransformDirection(direction.normalized);
            Ray r = new Ray(transform.position, direction);
            RaycastHit hit;
            if (Physics.Raycast(r, out hit))
            {
                if (hit.rigidbody)
                    hit.rigidbody.AddForceAtPosition(force * direction, hit.point);
                //Debug.DrawLine(transform.position, hit.point, Color.blue, rayTime);
                laserLineRenderer.SetPosition(0, transform.position);
                laserLineRenderer.SetPosition(1, hit.point);
                laserLineRenderer.enabled = true;
                StartCoroutine("WaitTime");
                ammo--;
            }



        }


    }
}






