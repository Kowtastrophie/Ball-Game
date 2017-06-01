using System;
using System.Collections;
using UnityEngine;

public class mouselook : MonoBehaviour
{
    public float mouseSensitivity = 500.0f;
    public float clampAngle = 80.0f;

    private float rotY = 0.0f; // rotation around the up/y axis
    private float rotX = 0.0f; // rotation around the right/x axis
    private float recoilTimer = .1f;
    public float scaleLimit = 0.0f;
    public float z = 100f;
    public float rayTime = .5f;
    public int force = 10;
    public int count = 30;
    public LineRenderer laserLineRenderer;
    private bool allowedToFire = true;
    private bool allowedToShotgunFire = true;
    public float sniperFireRate = 1.0f;
    public float laserWidth = 0.1f;
    public float laserMaxLength = 5f;
    int timer;
    public float recoilWait = .1f;
    public float recoilAmount = 1f;
    public float shotgunFireRate = .05f;
    private bool isRunning = false;
    private bool changeMouseY = false;
    public bool shotgunChangeMouseY = false;
    public float maxSniperMouseYChange = .5f;
    public float sniperMouseXChange = 1;
    public float minSniperMouseYChange = .25f;
    public float shotgunMinMouseYChange = .125f;
    public float shotgunMaxMouseYChange = .5f;
    public float shotgunMouseXChange = .4f;
    private bool antiRecoilY = false;
    private bool antiRecoilXNeg = false;
    private bool antiRecoilXPos = false;


    void Start()
    {
        Vector3 rot = transform.localRotation.eulerAngles;
        rotY = rot.y;
        rotX = rot.x;
        Cursor.lockState = CursorLockMode.Locked;
    }
    IEnumerator SniperWaitTime()
    {
        yield return new WaitForSeconds(sniperFireRate);
        allowedToFire = true;
    }
    IEnumerator ShotgunWaitTime()
    {
        yield return new WaitForSeconds(shotgunFireRate);
        allowedToShotgunFire = true;
    }
    IEnumerator RecoilWaitTime()
    {
      
        yield return new WaitForEndOfFrame();
        changeMouseY = true;
        
        


    }
    IEnumerator ShotgunRecoilWaitTime()
    {
        yield return new WaitForSeconds(shotgunFireRate);
        shotgunChangeMouseY = true;
        
    }
    IEnumerator AntiRecoilY1()
    {
        
            yield return new WaitForSeconds(.1f);
        antiRecoilY = true;
        yield return new WaitForEndOfFrame();
        antiRecoilY = false;
        yield return new WaitForEndOfFrame();
        antiRecoilY = true;
        yield return new WaitForEndOfFrame();
        antiRecoilY = false;
        yield return new WaitForEndOfFrame();
        antiRecoilY = true;
        yield return new WaitForEndOfFrame();
        antiRecoilY = false;
        yield return new WaitForEndOfFrame();
        antiRecoilY = true;
        yield return new WaitForEndOfFrame();
        antiRecoilY = false;
        yield return new WaitForEndOfFrame();
        antiRecoilY = true;
        yield return new WaitForEndOfFrame();
        antiRecoilY = false;
     
    }
    IEnumerator AntiRecoilY2()
    {

        yield return new WaitForSeconds(.1f);
        antiRecoilY = true;
        yield return new WaitForEndOfFrame();
        antiRecoilY = false;
        yield return new WaitForEndOfFrame();
        antiRecoilY = true;
        yield return new WaitForEndOfFrame();
        antiRecoilY = false;
        yield return new WaitForEndOfFrame();
        antiRecoilY = true;
        yield return new WaitForEndOfFrame();
        antiRecoilY = false;
        yield return new WaitForEndOfFrame();
        antiRecoilY = true;
        yield return new WaitForEndOfFrame();
        antiRecoilY = false;
        yield return new WaitForEndOfFrame();
        antiRecoilY = true;
        yield return new WaitForEndOfFrame();
        antiRecoilY = false;
        yield return new WaitForEndOfFrame();
        antiRecoilY = true;
        yield return new WaitForEndOfFrame();
        antiRecoilY = false;
    }
    IEnumerator AntiRecoilY3()
    {

        yield return new WaitForSeconds(.1f);
        antiRecoilY = true;
        yield return new WaitForEndOfFrame();
        antiRecoilY = false;
        yield return new WaitForEndOfFrame();
        antiRecoilY = true;
        yield return new WaitForEndOfFrame();
        antiRecoilY = false;
        yield return new WaitForEndOfFrame();
        antiRecoilY = true;
        yield return new WaitForEndOfFrame();
        antiRecoilY = false;
        yield return new WaitForEndOfFrame();
        antiRecoilY = true;
        yield return new WaitForEndOfFrame();
        antiRecoilY = false;
        yield return new WaitForEndOfFrame();
        antiRecoilY = true;
        yield return new WaitForEndOfFrame();
        antiRecoilY = false;
        yield return new WaitForEndOfFrame();
        antiRecoilY = true;
        yield return new WaitForEndOfFrame();
        antiRecoilY = false;
        yield return new WaitForEndOfFrame();
        antiRecoilY = true;
        yield return new WaitForEndOfFrame();
        antiRecoilY = false;
    }
    IEnumerator AntiRecoilY4()
    {

        yield return new WaitForSeconds(.1f);
        antiRecoilY = true;
        yield return new WaitForEndOfFrame();
        antiRecoilY = false;
        yield return new WaitForEndOfFrame();
        antiRecoilY = true;
        yield return new WaitForEndOfFrame();
        antiRecoilY = false;
        yield return new WaitForEndOfFrame();
        antiRecoilY = true;
        yield return new WaitForEndOfFrame();
        antiRecoilY = false;
        yield return new WaitForEndOfFrame();
        antiRecoilY = true;
        yield return new WaitForEndOfFrame();
        antiRecoilY = false;
        yield return new WaitForEndOfFrame();
        antiRecoilY = true;
        yield return new WaitForEndOfFrame();
        antiRecoilY = false;
        yield return new WaitForEndOfFrame();
        antiRecoilY = true;
        yield return new WaitForEndOfFrame();
        antiRecoilY = false;
        yield return new WaitForEndOfFrame();
        antiRecoilY = true;
        yield return new WaitForEndOfFrame();
        antiRecoilY = false;
        yield return new WaitForEndOfFrame();
        antiRecoilY = true;
        yield return new WaitForEndOfFrame();
        antiRecoilY = false;
    }
    IEnumerator AntiRecoilY5()
    {

        yield return new WaitForSeconds(.1f);
        antiRecoilY = true;
        yield return new WaitForEndOfFrame();
        antiRecoilY = false;
        yield return new WaitForEndOfFrame();
        antiRecoilY = true;
        yield return new WaitForEndOfFrame();
        antiRecoilY = false;
        yield return new WaitForEndOfFrame();
        antiRecoilY = true;
        yield return new WaitForEndOfFrame();
        antiRecoilY = false;
        yield return new WaitForEndOfFrame();
        antiRecoilY = true;
        yield return new WaitForEndOfFrame();
        antiRecoilY = false;
        yield return new WaitForEndOfFrame();
        antiRecoilY = true;
        yield return new WaitForEndOfFrame();
        antiRecoilY = false;
        yield return new WaitForEndOfFrame();
        antiRecoilY = true;
        yield return new WaitForEndOfFrame();
        antiRecoilY = false;
        yield return new WaitForEndOfFrame();
        antiRecoilY = true;
        yield return new WaitForEndOfFrame();
        antiRecoilY = false;
        yield return new WaitForEndOfFrame();
        antiRecoilY = true;
        yield return new WaitForEndOfFrame();
        antiRecoilY = false;
        yield return new WaitForEndOfFrame();
        antiRecoilY = true;
        yield return new WaitForEndOfFrame();
        antiRecoilY = false;
    }

    IEnumerator AntiRecoilX1()
    {
        yield return new WaitForSeconds(.1f);
        antiRecoilXNeg = true;
        yield return new WaitForEndOfFrame();
        antiRecoilXNeg = false;
        yield return new WaitForEndOfFrame();
        antiRecoilXNeg = true;
        yield return new WaitForEndOfFrame();
        antiRecoilXNeg = false;
        yield return new WaitForEndOfFrame();
        antiRecoilXNeg = true;
        yield return new WaitForEndOfFrame();
        antiRecoilXNeg = false;
        yield return new WaitForEndOfFrame();
        antiRecoilXNeg = true;
        yield return new WaitForEndOfFrame();
        antiRecoilXNeg = false;
        yield return new WaitForEndOfFrame();
        antiRecoilXNeg = true;
        yield return new WaitForEndOfFrame();
        antiRecoilXNeg = false;

    }
    IEnumerator AntiRecoilX2()
    {
      yield return new WaitForSeconds(.1f);
        antiRecoilXNeg = true;
        yield return new WaitForEndOfFrame();
        antiRecoilXNeg = false;
        yield return new WaitForEndOfFrame();
        antiRecoilXNeg = true;
        yield return new WaitForEndOfFrame();
        antiRecoilXNeg = false;
        yield return new WaitForEndOfFrame();
        antiRecoilXNeg = true;
        yield return new WaitForEndOfFrame();
        antiRecoilXNeg = false;
    }
    IEnumerator AntiRecoilX3()
    {
        yield return new WaitForSeconds(.1f);
        antiRecoilXPos = true;
        yield return new WaitForEndOfFrame();
        antiRecoilXPos = false;
        yield return new WaitForEndOfFrame();
        antiRecoilXPos = true;
        yield return new WaitForEndOfFrame();
        antiRecoilXPos = false;
        yield return new WaitForEndOfFrame();
        antiRecoilXPos = true;
        yield return new WaitForEndOfFrame();
        antiRecoilXPos = false;
    }
    IEnumerator AntiRecoilX4()
    {
        yield return new WaitForSeconds(.1f);
        antiRecoilXPos = true;
        yield return new WaitForEndOfFrame();
        antiRecoilXPos = false;
        yield return new WaitForEndOfFrame();
        antiRecoilXPos = true;
        yield return new WaitForEndOfFrame();
        antiRecoilXPos = false;
        yield return new WaitForEndOfFrame();
        antiRecoilXPos = true;
        yield return new WaitForEndOfFrame();
        antiRecoilXPos = false;
        yield return new WaitForEndOfFrame();
        antiRecoilXPos = true;
        yield return new WaitForEndOfFrame();
        antiRecoilXPos = false;
        yield return new WaitForEndOfFrame();
        antiRecoilXPos = true;
        yield return new WaitForEndOfFrame();
        antiRecoilXPos = false;
        yield return new WaitForEndOfFrame();
        antiRecoilXPos = true;
        yield return new WaitForEndOfFrame();
        antiRecoilXPos = false;
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
        
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = -Input.GetAxis("Mouse Y");
        if (changeMouseY == true)
        {
            float mouseYChange = UnityEngine.Random.Range(minSniperMouseYChange, maxSniperMouseYChange);
            mouseY -= mouseYChange;
            float mouseXChange = UnityEngine.Random.Range(-sniperMouseXChange, sniperMouseXChange);
            mouseX += mouseXChange;
            if (mouseYChange >= .25f && mouseYChange <= .3f)
            {
                StartCoroutine("AntiRecoilY1");
            }
            if (mouseYChange > .3f && mouseYChange <= .35f)
            {
                StartCoroutine("AntiRecoilY2");
            }
            if (mouseYChange > .35f && mouseYChange <= .4f)
            {
                StartCoroutine("AntiRecoilY3");
            }
            if (mouseYChange > .4f && mouseYChange <= .45f)
            {
                StartCoroutine("AntiRecoilY4");
            }
            if (mouseYChange > .45f && mouseYChange <= .5f)
            {
                StartCoroutine("AntiRecoilY5");
            }
            if (mouseXChange <=-.5f && mouseXChange >=-1f)
            {
                StartCoroutine("AntiRecoilX1");
            }
            if (mouseXChange > .5f && mouseXChange <= 0f)
            {
                StartCoroutine("AntiRecoilX2");
            }
            if (mouseXChange > 0f && mouseXChange <= .5f)
            {
                StartCoroutine("AntiRecoilX3");
            }
            if (mouseXChange > .5f && mouseXChange <= 1f)
            {
                StartCoroutine("AntiRecoilX4");
            }


        }
        if (shotgunChangeMouseY == true)
        {
            float machineGunMouseYChange = UnityEngine.Random.Range(shotgunMinMouseYChange, shotgunMaxMouseYChange);
            mouseY -= machineGunMouseYChange;
            float machineGunMouseXChange = UnityEngine.Random.Range(-shotgunMouseXChange, shotgunMouseXChange);
            mouseX += machineGunMouseXChange;
            
        }
        if (antiRecoilY == true)
        {
            mouseY += .05f;

        }
        if (antiRecoilXNeg == true)
        {
            mouseX += .1f;

        }
        if (antiRecoilXPos == true)
        {
            mouseX -= .1f;

        }
        if (Input.GetButtonDown("Fire1") && allowedToFire == true && isRunning == false)
        {
            shootRay();
            StartCoroutine("RecoilWaitTime");
            
            
        }
        else
        {
            changeMouseY = false;
        }
        if (Input.GetButton("Fire2") && isRunning == false && allowedToShotgunFire == true)
        {

            shootShotgun();
            StartCoroutine("ShotgunRecoilWaitTime");

        }
        else
        {
            shotgunChangeMouseY = false;
        }
        rotY += mouseX * mouseSensitivity * Time.deltaTime;
        rotX += mouseY * mouseSensitivity * Time.deltaTime;

        rotX = Mathf.Clamp(rotX, -clampAngle, clampAngle);

        Quaternion localRotation = Quaternion.Euler(rotX, rotY, 0.0f);
        transform.rotation = localRotation;
    }
    void shootRay()
    {
        if (allowedToFire == true)
        {
            allowedToFire = false;


            StartCoroutine("SniperWaitTime");
        }


    }

    void shootShotgun()
    {
        if (allowedToShotgunFire == true)
        {
            allowedToShotgunFire = false;


            StartCoroutine("ShotgunWaitTime");

            }
    

        }

    }




