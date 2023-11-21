using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletAttribute : MonoBehaviour {
    float damage;
	// Use this for initialization
	void Start () {
        var ob = GameObject.Find("Sweapon");
        if (ob != null)
        {
            damage = 10;
            Debug.Log("Find");
        }
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
