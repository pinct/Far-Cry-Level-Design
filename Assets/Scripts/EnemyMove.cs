using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
	public GameObject Player;
	public GameObject Enemy;
	public float speed = 0.00f;
	public int MoveTrigger;
	public int ShootTrigger;
	public RaycastHit shot;
	public float TargetDistance;
	public int IsShooting = 0;
	public bool IsAlert = false;
	public GameObject cylinder;
	public GameObject cube;
	public GameObject spot1;
	public GameObject spot2;
	public float changeTime = 3.0f;
	float timer;
    int direction = 1;
    // Start is called before the first frame update
    void Start()
    {
        Enemy.GetComponent<Animation>().Play();
		if (spot1 != null && spot2 != null)
		{
			StartCoroutine(EnemyPace());
		}
    }

    // Update is called once per frame
    void Update()
    {
		if (timer < 0)
        {
            direction = -direction;
            timer = changeTime;
        }
		Enemy.GetComponent<Animator>().SetInteger("MoveTrigger", MoveTrigger);
		Enemy.GetComponent<Animator>().SetInteger("ShootTrigger", ShootTrigger);
		if (IsAlert)
		{
			Enemy.transform.LookAt(Player.transform);
			cube.transform.LookAt(Player.transform);
			if (Physics.Raycast(cube.transform.position, cube.transform.TransformDirection(Vector3.forward), out shot))
			{
				if (shot.transform.tag == "Player")
				{
					TargetDistance = shot.distance;
					if (TargetDistance > 50)
					{
						speed = 0.04f;
						Enemy.transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, speed);
						MoveTrigger = 1;
						ShootTrigger = 0;
					}
					else
					{
						speed = 0.00f;
						MoveTrigger = 0;
						ShootTrigger = 1;
						if (IsShooting == 0)
						{
							StartCoroutine(EnemyDamage());
						}
					}
				}
			}
		}
    }
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			cylinder.GetComponent<MeshCollider>().enabled = false;
			if (Physics.Linecast(Enemy.transform.position, Player.transform.position))
			{
				IsAlert = true;
			}
		}
	}
	IEnumerator EnemyDamage()
	{
		IsShooting = 1;
		yield return new WaitForSeconds(1.0f/30.0f);
		GlobalHealth.PlayerHealth -= 1;
		yield return new WaitForSeconds(29.0f/30.0f);
		IsShooting = 0;
	}
	IEnumerator EnemyPace()
	{
		while (!IsAlert)
		{
			float counter = 0f;
			float travelDuration = 4.0f;
			transform.Rotate(0, 180, 0, Space.World);
			 while( counter < travelDuration )
			 {
				 MoveTrigger = 1;
				 transform.position = Vector3.Lerp (spot1.transform.position, spot2.transform.position, counter / travelDuration);
				 counter += Time.deltaTime;
				 yield return null;
			 }
			 transform.position = spot2.transform.position;
			 
			 MoveTrigger = 0;
			 yield return new WaitForSeconds(1.0f);
	 
			 // Third step, travel back from B to A
			 transform.Rotate(0, 180, 0, Space.World);
			 counter = 0f;
			 while( counter < travelDuration )
			 {
				 MoveTrigger = 1;
				 transform.position = Vector3.Lerp (spot2.transform.position, spot1.transform.position, counter / travelDuration);
				 counter += Time.deltaTime;
				 yield return null;
			 }
	 
			 transform.position = spot1.transform.position;
			 MoveTrigger = 0;
			 yield return new WaitForSeconds(1.0f);
		}
	}
}
