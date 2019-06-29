using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Elevator : MonoBehaviour
{
	public GameObject TextDisplay;
	public float TheDistance = PlayerCasting.DistanceFromTarget;
	bool canele = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TheDistance = PlayerCasting.DistanceFromTarget;
		if ((TheDistance <= 2) && Input.GetKey(KeyCode.E) && Keycard.card && canele)
		{
			GetComponent<Animation>().Play("ele");
		}
    }
	void OnMouseOver()
	{
		if(TheDistance <= 2 && Keycard.card && canele)
		{
			TextDisplay.GetComponent<Text>().text="Press E to use Elevator";
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
		canele = true;
    }
	void OnTriggerExit(Collider other)
    {
		canele = false;
		TextDisplay.GetComponent<Text>().text="";
    }
}
