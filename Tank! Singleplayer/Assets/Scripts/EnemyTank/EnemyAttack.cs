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
		public Rigidbody Shell;
		public Transform FireTransform;
		public AudioSource ShootingAudio;
		public AudioClip Firing;
		public float LaunchForce;

		GameObject player;
		PlayerHealth pHealth;
		EnemyHealth eHealth;
		PlayerAttack pShoot;
		EnemyAttack eShoot;
		float timer;
		EnemyMovement eMove;
		ShellExplosion sExplo;
		bool isMiss;

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
			LaunchForce = Random.Range (10, 30);

			timer = 0f;

			Rigidbody shellInstance = Instantiate (Shell, FireTransform.position, FireTransform.rotation) as Rigidbody;

			shellInstance.velocity = LaunchForce * FireTransform.forward;
		}
	}
}