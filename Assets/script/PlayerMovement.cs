using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float mouseSensitivity = 100.0f;
    public float clampAngle = 80.0f;
    public float jumpAmount = 10.0f;
    private float rotY = 0.0f; // rotation around the up/y axis
    private float rotX = 0.0f; // rotation around the right/x axis
    public int movementspeed = 1;
    private bool canJump = false;
    private Vector3 totalforce;
    private float terminalVelocity;
    public float g = 9.807f;
    private float rho = 1;
    private float A;
    public float sprintSpeed = 15;
    public float jetPack = 5;
    public float fuel = 100;
    void Start()
    {
        Vector3 rot = transform.localRotation.eulerAngles;
        rotY = rot.y;
        rotX = rot.x;
        A = 4 * Mathf.PI * Mathf.Pow(transform.localScale.x / 2, 2);
        terminalVelocity = Mathf.Sqrt((2 * GetComponent<Rigidbody>().mass * g) / (rho * A * GetComponent<Rigidbody>().angularDrag));
        }

    void Update()
    {
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift))
        {
            if (totalforce.z < terminalVelocity)
            {
                GetComponent<Rigidbody>().AddForce(Camera.main.transform.forward * sprintSpeed);
                totalforce = GetComponent<Rigidbody>().angularVelocity;
            }
         
        }
            if (Input.GetKey(KeyCode.W))
            {
                if (totalforce.z < terminalVelocity)
                {
                    GetComponent<Rigidbody>().AddForce(Camera.main.transform.forward * movementspeed);
                    totalforce = GetComponent<Rigidbody>().angularVelocity;
                }
            }
            if (Input.GetKey(KeyCode.S))
            {
                if (totalforce.z > -terminalVelocity)
                {
                    GetComponent<Rigidbody>().AddForce(-Camera.main.transform.forward * movementspeed);
                    totalforce = GetComponent<Rigidbody>().angularVelocity;
                }
            }
            if (Input.GetKey(KeyCode.A))
            {
                if (totalforce.x > -terminalVelocity)
                    GetComponent<Rigidbody>().AddForce(-Camera.main.transform.right * movementspeed);
                totalforce = GetComponent<Rigidbody>().angularVelocity;
            }
            if (Input.GetKey(KeyCode.D))
            {
                if (totalforce.x < terminalVelocity)
                    GetComponent<Rigidbody>().AddForce(Camera.main.transform.right * movementspeed);
                totalforce = GetComponent<Rigidbody>().angularVelocity;
            }
        if (Input.GetKey(KeyCode.LeftControl) && fuel > 0)
        {
            for (int i = 0; i < fuel; i++)


                transform.rotation = new Quaternion(0, 0, 0, transform.rotation.y);
            GetComponent<Rigidbody>().AddForce(Camera.main.transform.up * jetPack, ForceMode.Acceleration);
            totalforce = GetComponent<Rigidbody>().angularVelocity;
        }
    




        Camera.main.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
        }

        void OnCollisionStay(Collision col)
    {
            if (col.gameObject.tag == "Ground" && Input.GetKeyDown(KeyCode.Space))
            {
                transform.rotation = new Quaternion(0, 0, 0, transform.rotation.w);
                GetComponent<Rigidbody>().AddForce(transform.up * jumpAmount, ForceMode.Impulse);
            }


        }

    }


        

    
    
