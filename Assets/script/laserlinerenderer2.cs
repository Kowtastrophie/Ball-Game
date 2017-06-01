using UnityEngine;
using System.Collections;

public class laserlinerenderer2 : MonoBehaviour
{

    public LineRenderer laserLineRenderer;
    public float scaleLimit = 5.0f;
    public float z = 100.0f;
    public float laserWidth = 0.1f;
    public float laserMaxLength = 5f;
    public int count = 30;
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
        if (Input.GetButton("Fire1"))
            for(int i = 0; i < count; i++)
            {
                Laser();
                //Debug.Log("Run number: " + (i + 1));
            }
        else
        {
            laserLineRenderer.enabled = false;


        }



    }


    public void Laser()
    {
        float randomRadius = Random.Range(0, scaleLimit);
        float randomAngle = Random.Range(0, 2 * Mathf.PI);
        
        Vector3 direction = new Vector3(
            randomRadius * Mathf.Cos(randomAngle), randomRadius * Mathf.Sin(randomAngle), z);
        direction = transform.TransformDirection(direction.normalized);
        Ray r = new Ray(transform.position, direction);
        RaycastHit hit;

        if (Physics.Raycast(r, out hit))
        {


            laserLineRenderer.SetPosition(0, transform.position);
            laserLineRenderer.SetPosition(1, hit.point);
            laserLineRenderer.enabled = true;
           // Debug.Log("endpoint: " + (hit.point) + " startpoint: " + (direction));
        }


    }


}