using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using PlayerInfo;
using Shell;

namespace EnemyInfo
{
	public class EnemyAttack : MonoBehaviour 
	{
		public float timeBetweenAttacks = 0.75f;
		public float attackDamage;
		public GameObject Shell;
		public Transform FireTransform;
		public AudioSource ShootingAudio;
		public AudioClip Firing;
		public float LaunchForce;
		public Transform ETank;
		public Transform PTank;
		public int missChance = 45;

		GameObject player;
		PlayerHealth pHealth;
		EnemyHealth eHealth;
		PlayerAttack pShoot;
		EnemyAttack eShoot;
		float timer;
		EnemyMovement eMove;
		ShellExplosion sExplo;

		void OnEnable ()
		{

		}

		void Awake ()
		{
			player = GameObject.FindGameObjectWithTag ("Player");
			pHealth = player.GetComponent<PlayerHealth> ();
			eHealth = GetComponent<EnemyHealth> ();
			eMove = GetComponent<EnemyMovement> ();
		}

		void LateUpdate ()
		{
			timer += Time.deltaTime;

			if (timer >= timeBetweenAttacks && eMove.inRange && eHealth.CurrentHealth > 0 && pHealth.CurrentHealth > 0)
			{
				Attack ();
			}
		}

		void Attack ()
		{
			int randPercent = Random.Range (1, 100);

			if (randPercent <= missChance) 
			{
				LaunchForce = 100;
			} 
			else 
			{
				LaunchForce = eMove.shotDistance;
			}

			timer = 0f;

			Rigidbody shellInstance = (Instantiate (Shell, FireTransform.position, FireTransform.rotation) as GameObject).GetComponent<Rigidbody>();

			shellInstance.velocity = LaunchForce * FireTransform.forward;
		}
	}
}