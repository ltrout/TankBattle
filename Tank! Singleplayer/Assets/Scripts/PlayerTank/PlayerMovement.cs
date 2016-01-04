using UnityEngine;
using System.Collections;
using EnemyInfo;
using Shell;

namespace PlayerInfo
{
	public class PlayerMovement : MonoBehaviour 
	{
		public float Speed = 10f;
		public float TurnSpeed = 180f;
		public AudioSource MovementAudio;
		public AudioClip EngineIdling;
		public AudioClip EngineDriving;

		string MovementAxisName;
		string TurnAxisName;
		Rigidbody Rigidbody;
		float MovementInputValue;
		float TurnInputValue;

		void Awake ()
		{
			Rigidbody = GetComponent<Rigidbody> ();
		}

		void OnEnable ()
		{
			Rigidbody.isKinematic = false;

			MovementInputValue = 0f;
			TurnInputValue = 0f;
		}

		void OnDisable ()
		{
			Rigidbody.isKinematic = true;
		}

		void Start ()
		{
			MovementAxisName = "Vertical";
			TurnAxisName = "Horizontal";
		}

		void Update ()
		{
			MovementInputValue = Input.GetAxis (MovementAxisName);
			TurnInputValue = Input.GetAxis (TurnAxisName);

			EngineAudio ();
		}

		void EngineAudio ()
		{
			// If there is no input (the tank is stationary)...
			if (Mathf.Abs (MovementInputValue) < 0.1f && Mathf.Abs (TurnInputValue) < 0.1f)
			{
				// ... and if the audio source is currently playing the driving clip...
				if (MovementAudio.clip == EngineDriving)
				{
					// ... change the clip to idling and play it.
					MovementAudio.clip = EngineIdling;
					MovementAudio.Play ();
				}
			}
			else
			{
				// Otherwise if the tank is moving and if the idling clip is currently playing...
				if (MovementAudio.clip == EngineIdling)
				{
					// ... change the clip to driving and play.
					MovementAudio.clip = EngineDriving;
					MovementAudio.Play();
				}
			}
		}

		void FixedUpdate ()
		{
			Move ();
			Turn ();
		}

		void Move ()
		{
			Vector3 movement = transform.forward * MovementInputValue * Speed * Time.deltaTime;

			Rigidbody.MovePosition (Rigidbody.position + movement);
		}

		void Turn ()
		{
			float turn = TurnInputValue * TurnSpeed * Time.deltaTime;

			Quaternion turnRotation = Quaternion.Euler (0f, turn, 0f);

			Rigidbody.MoveRotation (Rigidbody.rotation * turnRotation);
		}

	}
}