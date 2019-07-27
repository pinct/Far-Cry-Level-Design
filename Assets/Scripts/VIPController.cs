using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VIPController : MonoBehaviour
{
    public GameObject Player;
	public GameObject VIP;
	public float speed = 0.00f;
	public int MoveTrigger;
	public int ShootTrigger;
	public RaycastHit shot;
	public float TargetDistance;
	public int IsShooting = 0;
	public bool IsAwake = false;
	public GameObject TextDisplay;
	public float TheDistance = PlayerCasting.DistanceFromTarget;
	LayerMask mask = 1 << 10;
    // Start is called before the first frame update
    void Start()
    {
		mask = ~mask;
    }

    // Update is called once per frame
    void Update()
    {
		TheDistance = PlayerCasting.DistanceFromTarget;
		if (IsAwake)
		{
			TextDisplay.GetComponent<Text>().text="";
			VIP.transform.LookAt(Player.transform);
			if (Physics.Raycast(VIP.transform.position, VIP.transform.TransformDirection(Vector3.forward), out shot, Mathf.Infinity, mask))
			{
				Debug.Log(shot.transform.gameObject.name);
				if (shot.transform.tag == "Player")
				{
					TargetDistance = shot.distance;
					if (TargetDistance > 5)
					{
						speed = 0.04f;
						VIP.transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, speed);
					}
					else
					{
						speed = 0.00f;
					}
				}
			}
		}
		if (Input.GetKey(KeyCode.E) && TextDisplay.GetComponent<Text>().text == "Press E to Wake VIP")
		{
			IsAwake = true;
		}
    }
	void OnMouseOver()
	{
		if(TheDistance <= 2)
		{
			TextDisplay.GetComponent<Text>().text="Press E to Wake VIP";
		}
	}
	void OnMouseExit()
	{
		if(TheDistance > 2)
		{
			TextDisplay.GetComponent<Text>().text="";
		}
	}
}
