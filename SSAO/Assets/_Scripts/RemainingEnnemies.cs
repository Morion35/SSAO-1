using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class RemainingEnnemies : MonoBehaviour
{

	public GameObject ennemies;

	private int max_ennemies;

	private float _time;

	public float count;
	// Use this for initialization
	void Start ()
	{
		max_ennemies = ennemies.transform.childCount;
		_time = 10f;
	}

	private void OnCollisionStay(Collision other)
	{
		if (other.gameObject.CompareTag("enemy") && count > Time.time)
		{
			count = Time.deltaTime + _time;
		}
	}
}
