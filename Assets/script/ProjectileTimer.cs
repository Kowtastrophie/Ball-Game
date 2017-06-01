using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileTimer : MonoBehaviour {
    private float timeLeft = 15; 
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0)
        {
            Destroy(gameObject);

        }
	}
}
