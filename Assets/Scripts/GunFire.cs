using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunFire : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && (GlobalAmmo.LoadedAmmo != 0))
		{
			AudioSource gunsound = GetComponent<AudioSource>();
			gunsound.Play();
			GetComponent<Animation>().Play("Gunshot");
			GlobalAmmo.LoadedAmmo -= 1;
		}
    }
}
