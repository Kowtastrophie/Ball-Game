using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
    IEnumerator WaitForMelee()
    {
        yield return new WaitForSeconds(.5f);
        transform.rotation = new Quaternion(0, 0, 0, transform.rotation.y);
        transform.Translate(-transform.forward * 10);
        
    }
    // Update is called once per frame
    void Update () {

        if (Input.GetKeyDown(KeyCode.E))
        {
            transform.rotation = new Quaternion(0, 0, 0, transform.rotation.y);
            transform.Translate(transform.forward * 10);
            StartCoroutine("WaitForMelee");
        }
    
    }
}
