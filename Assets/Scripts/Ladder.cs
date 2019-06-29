using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Ladder : MonoBehaviour
{
	public FirstPersonController controller;
    GameObject playerOBJ;
     bool canClimb = false;
     float speed = 10;
     void OnTriggerEnter(Collider coll)
     {
         if (coll.gameObject.tag == "Player")
         {
			 controller.GetComponent<FirstPersonController>().CanMove = false;
             canClimb = true;
             playerOBJ = coll.gameObject;
         }
     }
 
     void OnTriggerExit(Collider coll2)
     {
         if (coll2.gameObject.tag == "Player")
         {
			 controller.GetComponent<FirstPersonController>().CanMove = true;
             canClimb = false;
             playerOBJ = null;
         }
     }
     void Update()
     {
         if (canClimb)
		 {
            if (Input.GetKey(KeyCode.W))
            {
                playerOBJ.transform.Translate(new Vector3(0, 1, 0) * Time.deltaTime * speed);
            }
            if (Input.GetKey(KeyCode.S))
            {
				playerOBJ.transform.Translate(new Vector3(0, -1, 0) * Time.deltaTime * speed);
            }
         }
     }
}
