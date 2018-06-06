using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerafollow : MonoBehaviour
{
	private Vector3 offset;

	private GameObject[] Players;

	public GameObject Player;

	public float smoothing = 5f;
	
	int i = 0;
	// Use this for initialization
	void Start ()
	{
		Players = GameObject.FindGameObjectsWithTag("Player");
		Player = Players[0];
		offset = Player.transform.position - transform.position;
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.Confined;
		if (Input.GetAxisRaw("Horizontal") < 0)
		{
			i = (i - 1 + Players.Length) % Players.Length;
			Player = Players[i];
		}
		if (Input.GetAxisRaw("Horizontal") > 0)
		{
			i = (i+ 1) % Players.Length;
			Player = Players[i];
		}
		if (Player.GetComponent<CharacterController>().enabled && Player.activeSelf)
		{
			Vector3 TargetPos = Player.transform.position + offset;
			transform.position = Vector3.Lerp(transform.position, TargetPos, smoothing);
		}
	}
}
