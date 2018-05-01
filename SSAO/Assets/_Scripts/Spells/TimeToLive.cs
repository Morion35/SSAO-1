using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters;
using UnityEngine;

public class TimeToLive : MonoBehaviour
{

	public float TTL;

	private float Life;
	
	private void Start()
	{
		Life = Time.time + TTL;
	}

	private void Update()
	{
		End();
	}

	private void End()
	{
		if (Time.time > Life)
		{
			Destroy(gameObject);
		}
	}
}
