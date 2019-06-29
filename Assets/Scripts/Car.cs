using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityStandardAssets.Vehicles.Car;
using UnityEngine.UI;

public class Car : MonoBehaviour
{
	public GameObject Panel;
	public GameObject Ammo1;
	public GameObject Ammo2;
	public GameObject UpCurs;
	public GameObject DownCurs;
	public GameObject LeftCurs;
	public GameObject RightCurs;
	public FirstPersonController controller;
	public GameObject playerOBJ;
	public GameObject FPSCamera;
	public GameObject Gun;
	public GameObject CarCamera;
	Transform PlayerTransform;
	public Transform TeleportGoal;
	public Transform CarGoal;
    public GameObject TextDisplay;
	public float TheDistance = PlayerCasting.DistanceFromTarget;
	bool cancar = false;
	// Start is called before the first frame update
    void Start()
    {
		PlayerTransform = GameObject.Find("FPSController").transform;
        GetComponent<CarController>().enabled = false;
		GetComponent<CarAudio>().enabled = false;
		GetComponent<CarUserControl>().enabled = false;
		CarCamera.GetComponent<Camera>().enabled = false;
		CarCamera.GetComponent<AudioListener>().enabled = false;
	}
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
			 playerOBJ = null;
         }
     }
     void Update()
     {
		 if (Input.GetKey(KeyCode.E) && playerOBJ != null)
		{
			Panel.GetComponent<Image>().enabled = false;
			Ammo1.GetComponent<Text>().enabled = false;
			Ammo2.GetComponent<Text>().enabled = false;
			UpCurs.GetComponent<RawImage>().enabled = false;
			DownCurs.GetComponent<RawImage>().enabled = false;
			LeftCurs.GetComponent<RawImage>().enabled = false;
			RightCurs.GetComponent<RawImage>().enabled = false;
			GetComponent<CarAudio>().pitchMultiplier = 1f;
			controller.GetComponent<FirstPersonController>().enabled = false;
			FPSCamera.GetComponent<AudioListener>().enabled = false;
			cancar = true;
			Gun.GetComponent<HandgunReloading>().enabled = false;
			Gun.GetComponent<GunFire>().enabled = false;
			TextDisplay.GetComponent<Text>().text="Press Space to Exit";
			PlayerTransform.position = TeleportGoal.position;
			
		}
		if (Input.GetKey(KeyCode.Space) && cancar == true)
		{
			Ammo1.GetComponent<Text>().enabled = true;
			Ammo2.GetComponent<Text>().enabled = true;
			Panel.GetComponent<Image>().enabled = true;
			UpCurs.GetComponent<RawImage>().enabled = true;
			DownCurs.GetComponent<RawImage>().enabled = true;
			LeftCurs.GetComponent<RawImage>().enabled = true;
			RightCurs.GetComponent<RawImage>().enabled = true;
			controller.GetComponent<CharacterController>().enabled = false;
			PlayerTransform.position = CarGoal.position;
			controller.GetComponent<CharacterController>().enabled = true;
			controller.GetComponent<FirstPersonController>().enabled = true;
			TextDisplay.GetComponent<Text>().text="";
			cancar = false;
			Gun.GetComponent<HandgunReloading>().enabled = true;
			Gun.GetComponent<GunFire>().enabled = true;
			GetComponent<CarController>().enabled = false;
			GetComponent<CarAudio>().pitchMultiplier = 0f;
			GetComponent<CarUserControl>().enabled = false;
			CarCamera.GetComponent<Camera>().enabled = false;
			CarCamera.GetComponent<AudioListener>().enabled = false;
			FPSCamera.GetComponent<AudioListener>().enabled = true;
			TextDisplay.GetComponent<Text>().text="";
			
			
		}
		 if (cancar)
		 {
            GetComponent<CarController>().enabled = true;
			GetComponent<CarAudio>().enabled = true;
			GetComponent<CarUserControl>().enabled = true;
			CarCamera.GetComponent<Camera>().enabled = true;
			CarCamera.GetComponent<AudioListener>().enabled = true;
         }
     }
	void OnMouseOver()
	{
		if(TheDistance <= 2 && playerOBJ != null && controller.GetComponent<FirstPersonController>().enabled)
		{
			TextDisplay.GetComponent<Text>().text="Press E to Enter Car";
		}
	}
}
