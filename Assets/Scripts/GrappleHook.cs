using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.UI;


public class GrappleHook : MonoBehaviour
{
	public FirstPersonController controller;
    GameObject playerOBJ;
    float speed = 10;
	public GameObject box;
	public GameObject TextDisplay;
	public float TheDistance = PlayerCasting.DistanceFromTarget;
	bool cangrapple = false;
    void OnTriggerEnter(Collider coll)
     {
         if (coll.gameObject.tag == "Player")
         {
             playerOBJ = coll.gameObject;
         }
     }
 
     void OnTriggerExit(Collider coll2)
     {
         if (coll2.gameObject.tag == "Player")
         {
			 controller.GetComponent<FirstPersonController>().CanMove = true;
             cangrapple = false;
             playerOBJ = null;
			 TextDisplay.GetComponent<Text>().text="";
         }
     }
     void Update()
     {
		 if (Input.GetKey(KeyCode.E) && playerOBJ != null)
		{
			controller.GetComponent<FirstPersonController>().CanMove = false;
			cangrapple = true;
			TextDisplay.GetComponent<Text>().text="Press Space to Cancel";
			
		}
		if (Input.GetKey(KeyCode.Space))
		{
			controller.GetComponent<FirstPersonController>().CanMove = true;
			TextDisplay.GetComponent<Text>().text="";
			
		}
		 if (cangrapple)
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
	void OnMouseOver()
	{
		if(TheDistance <= 100 && playerOBJ != null && controller.GetComponent<FirstPersonController>().CanMove)
		{
			TextDisplay.GetComponent<Text>().text="Press E to Grapple";
		}
	}
	void OnMouseExit()
	{
		if(TheDistance > 100)
		{
			TextDisplay.GetComponent<Text>().text="";
		}
	}
}
