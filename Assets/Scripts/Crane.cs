using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Crane : MonoBehaviour
{
	public GameObject TextDisplay;
	public GameObject cube;
	public float TheDistance = PlayerCasting.DistanceFromTarget;
	bool cancrane = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TheDistance = PlayerCasting.DistanceFromTarget;
		if ((TheDistance <= 2) && Input.GetKey(KeyCode.E) && cancrane)
		{
			cube.GetComponent<Animation>().Play("Crane");
		}
    }
	void OnMouseOver()
	{
		if(TheDistance <= 2 && Keycard.card && cancrane)
		{
			TextDisplay.GetComponent<Text>().text="Press E to use Crane";
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
		cancrane = true;
    }
	void OnTriggerExit(Collider other)
    {
		cancrane = false;
		TextDisplay.GetComponent<Text>().text="";
    }
}
