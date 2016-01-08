using UnityEngine;
using System.Collections;
using PlayerInfo;
using Shell;

namespace EnemyInfo
{
	public class EnemyMovement_Med : MonoBehaviour 
	{
		public Transform player;
		public Transform EnemyTank;
		public int AttackRange = 27;
		public bool inRange;
		public int TooClose = 9;

		NavMeshAgent agent;
		static PlayerHealth pHealth;
		static EnemyHealth eHealth;
		Rigidbody Rigidbody;

		void Awake ()
		{
			player = GameObject.FindWithTag ("Player").transform;
			pHealth = player.GetComponent<PlayerHealth> ();
			eHealth = GetComponent<EnemyHealth> ();
			Rigidbody = GetComponent<Rigidbody> ();
		}

		void OnEnable ()
		{
			Rigidbody.isKinematic = false;
		}

		void OnDisable ()
		{
			Rigidbody.isKinematic = true;
		}

		void Update ()
		{
			NavMeshAgent agent = GetComponent<NavMeshAgent> ();

			if (pHealth.CurrentHealth > 0 && eHealth.CurrentHealth > 0) 
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