using UnityEngine;
using System.Collections;

public class Target : MonoBehaviour
{
    public float scaleLimit = 5.0f;
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

    // Update is called once per frame
    void Start()
    {
        Vector3[] initLaserPositions = new Vector3[2] { Vector3.zero, Vector3.zero };
        laserLineRenderer.SetPositions(initLaserPositions);
        laserLineRenderer.startWidth = laserWidth;
        laserLineRenderer.endWidth = laserWidth;

    }


    void Update()
    {
        timer++;
        if (Input.GetButton("Fire1"))
            for (int i = 0; i < count; i++)
            {

                shootRay();

            }
        else
        {
            laserLineRenderer.enabled = false;


        }



    }

    void shootRay()
    {
        allowedToFire = false;
        float randomRadius = Random.Range(0, scaleLimit);
        float randomAngle = Random.Range(0, 2 * Mathf.PI);
        Vector3 direction = new Vector3(
            randomRadius * Mathf.Cos(randomAngle), randomRadius * Mathf.Sin(randomAngle), z);
        direction = transform.TransformDirection(direction.normalized);
        Ray r = new Ray(transform.position, direction);
        RaycastHit hit;
        if (Physics.Raycast(r, out hit))
        {
           
            //Debug.DrawLine(transform.position, hit.point, Color.blue, rayTime);
            laserLineRenderer.SetPosition(0, transform.position);
            laserLineRenderer.SetPosition(1, hit.point);
            laserLineRenderer.enabled = true;



        }


    }



}