using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteChange : MonoBehaviour {
    public float waitInBetweenSprites = .2f;
    private Sprite reload1;
    private Sprite reload2;
    private Sprite reload3;
    private Sprite reload4;
    private Sprite reload5;
    private Sprite reload6;
    private Sprite reload7;
    private Sprite reload8;
    private bool changeToSprite1 = false;
    private bool changeToSprite2 = false;
    private bool changeToSprite3 = false;
    private bool changeToSprite4 = false;
    private bool changeToSprite5 = false;
    private bool changeToSprite6 = false;
    private bool changeToSprite7 = false;
    private bool changeToSprite8 = false;
    // Use this for initialization
    void Start () {
		
	}
    IEnumerator ChangeToSprite1()
    {
        yield return new WaitForEndOfFrame();
        changeToSprite1 = true;
    }
    IEnumerator ChangeToSprite2()
    {
        yield return new WaitForSeconds(waitInBetweenSprites);
        changeToSprite2 = true;
    }
    IEnumerator ChangeToSprite3()
    {
        yield return new WaitForSeconds(waitInBetweenSprites);
        changeToSprite3 = true;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.R))
        {

            StartCoroutine("ChangeToSprite1");
        }
        if (changeToSprite1 == true)
        {
            StartCoroutine("ChageToSprite2");
        }
        changeToSprite1 = false;
        if (changeToSprite2 == true)
        {
            StartCoroutine("ChangeToSprite3");
        }
        changeToSprite2 = false;
        if (changeToSprite3 == true)
        {
            StartCoroutine("ChangeToSprite4");
        }


    }
}
