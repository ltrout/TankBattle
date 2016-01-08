using UnityEngine;
using System.Collections;

public class InGameControls : MonoBehaviour 
{
	public void Update () 
	{
		if (Input.GetKeyDown(KeyCode.Escape))
				Application.Quit();
	}
}
