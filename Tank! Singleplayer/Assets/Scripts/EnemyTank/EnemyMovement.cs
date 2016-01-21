using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using PlayerInfo;
using Shell;

namespace EnemyInfo
{
	public class EnemyMovement : MonoBehaviour 
	{
		public Transform player;
		public Transform EnemyTank;
		public int AttackRange = 20;
		public bool inRange;
		public int TooClose = 10;

		NavMeshAgent agent;
		static PlayerHealth pHealth;
		static EnemyHealth eHealth;
		Rigidbody Rigidbody;

		void Start ()
		{
			player = GameObject.FindWithTag ("Player").transform;
			pHealth = player.GetComponent<PlayerHealth> ();
			eHealth = GetComponent<EnemyHealth> ();
			Rigidbody = GetComponent<Rigidbody> ();
		}

		public void OnEnable ()
		{
			Rigidbody.isKinematic = false;
		}

		public void OnDisable ()
		{
			Rigidbody.isKinematic = true;
		}

		public void LateUpdate ()
		{
			NavMeshAgent agent = GetComponent<NavMeshAgent> ();

			//if (pHealth.CurrentHealth > 0 && eHealth.CurrentHealth > 0) 
			if (agent.enabled)
			{
				agent.SetDestination (player.position);
				transform.LookAt (player.position);
			} 
			else 
			{
				agent.enabled = false;
			}

			if (Vector3.Distance (player.position, EnemyTank.position) < AttackRange) {
				if (Vector3.Distance (player.position, EnemyTank.position) > TooClose)
				{
					inRange = true;
				}
			} 
			else if (Vector3.Distance (player.position, EnemyTank.position) > AttackRange)
			{
				inRange = false;
			}
		}
	}
}