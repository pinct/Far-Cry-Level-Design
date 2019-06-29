using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickupOld : MonoBehaviour
{
	public AudioSource AmmoPickupSound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	void OnTriggerEnter(Collider other)
    {
		AmmoPickupSound.Play();
        GlobalAmmo.LoadedAmmo = 10;
		GlobalAmmo.CurrentAmmo = 50;
    }
}
