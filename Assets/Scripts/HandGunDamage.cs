using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class HandGunDamage : MonoBehaviour
{
	public int DamageAmount = 5;
	public float TargetDistance;
	public float AllowedRange = 100.0f;


	void Update () {
		if(Input.GetButtonDown("Fire1") && GlobalAmmo.LoadedAmmo != 0) {
			RaycastHit Shot;
			if (Physics.Raycast (transform.position, transform.TransformDirection(Vector3.forward), out Shot)) {
				TargetDistance = Shot.distance;
				if (TargetDistance < AllowedRange) {
					Shot.transform.SendMessage("DeductPoints", DamageAmount, SendMessageOptions.DontRequireReceiver);
				}
			}
		}
	}
}
