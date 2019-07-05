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
    // Start is called before the first frame update
    void Start()
    {
        Enemy.GetComponent<Animation>().Play();
    }

    // Update is called once per frame
    void Update()
    {
		Enemy.GetComponent<Animator>().SetInteger("MoveTrigger", MoveTrigger);
		Enemy.GetComponent<Animator>().SetInteger("ShootTrigger", ShootTrigger);
		if (Player != null)
		{
			Enemy.transform.LookAt(Player.transform);
			if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out shot))
			{
				TargetDistance = shot.distance;
				if (shot.transform.tag == "Player")
				{
					if (TargetDistance > 20)
					{
						speed = 0.02f;
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
	IEnumerator EnemyDamage()
	{
		IsShooting = 1;
		yield return new WaitForSeconds(1.0f/30.0f);
		GlobalHealth.PlayerHealth -= 1;
		yield return new WaitForSeconds(29.0f/30.0f);
		IsShooting = 0;
	}
}
