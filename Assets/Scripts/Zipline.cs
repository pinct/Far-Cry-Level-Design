using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class Zipline : MonoBehaviour
{
	public GameObject FPSController;
	public GameObject TextDisplay;
	public float TheDistance = PlayerCasting.DistanceFromTarget;
	bool canzip = false;
    // Start is called before the first frame update
    void Start()
    {
		
    }

    // Update is called once per frame
    void Update()
    {
        TheDistance = PlayerCasting.DistanceFromTarget;
		if ((TheDistance <= 2) && Input.GetKey(KeyCode.E) && canzip)
		{
			FPSController.GetComponent<Animation>().Play("Zipline");
		}
    }
	void OnMouseOver()
	{
		if(TheDistance <= 2)
		{
			TextDisplay.GetComponent<Text>().text="Press E to Zipline";
		}
	}
	void OnMouseExit()
	{
		if(TheDistance > 2)
		{
			TextDisplay.GetComponent<Text>().text="";
		}
	}
	void OnTriggerEnter(Collider other)
    {
		canzip = true;
    }
	void OnTriggerExit(Collider other)
    {
		canzip = false;
		TextDisplay.GetComponent<Text>().text="";
    }
}
