using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
	public GameObject Player;
	public GameObject Enemy;
	public float speed;
	public int MoveTrigger;
	public RaycastHit shot;
	public float TargetDistance;
    // Start is called before the first frame update
    void Start()
    {
        Enemy.GetComponent<Animation>().Play();
    }

    // Update is called once per frame
    void Update()
    {
		Enemy.GetComponent<Animator>().SetInteger("MoveTrigger", MoveTrigger);
		if (Player != null)
		{
			Enemy.transform.LookAt(Player.transform);
			if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out shot))
			{
				TargetDistance = shot.distance;
				if (TargetDistance < 10)
				{
					speed = 0.04f;
					Enemy.transform.position = Vector3.MoveTowards(transform.position, new Vector3(Player.transform.position.x, Player.transform.position.y - 1.1f, Player.transform.position.z), speed);
					MoveTrigger = 1;
				}
				else
				{
					speed = 0.00f;
					MoveTrigger = 0;
				}
			}
		}
    }
}
