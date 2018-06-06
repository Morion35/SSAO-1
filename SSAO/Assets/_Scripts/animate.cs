using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class animate : NetworkBehaviour
{
	private Animator anim;
	// Use this for initialization
	void Awake ()
	{
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
	{

		if (isLocalPlayer)
		{
			float h = Input.GetAxisRaw("Horizontal");
			float v = Input.GetAxisRaw("Vertical");
			anim.SetBool("iswalking", h != 0f || v != 0f);
		}
		else
			return;

	}
}
