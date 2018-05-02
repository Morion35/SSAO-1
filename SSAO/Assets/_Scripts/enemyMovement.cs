using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class enemyMovement : MonoBehaviour {

    public bool isFocused;

	public bool hint;

	public Transform Player;

	public float HP = 100;

	private GameObject[] Players;
	
	AudioSource audio;

    UnityEngine.AI.NavMeshAgent nav;

	float _time;

	private float _fov = 60f;

    Animator anim;

    private Vector3 initialPos;

	private Quaternion initialDir;

	// Use this for initialization
	void Start () {
        initialPos = transform.position;

		initialDir = transform.rotation;

		Players = GameObject.FindGameObjectsWithTag("Player");

		int i = 0;
		while (!Players[i].activeSelf)
		{
			i++;
		}
		Player = Players[i].transform;

		isFocused = false;

		audio = Players[0].GetComponent<AudioSource>();

        nav = GetComponent<NavMeshAgent>();

        anim = GetComponent<Animator>();
        
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (HP <= 0)
		{
			anim.SetTrigger("dead");
			anim.SetBool("walking",false);
			anim.SetBool("suspicious", false);
			anim.SetBool("detected", false);
			nav.isStopped = true;
			Destroy(gameObject, 3f);
			return;
		}
	    NavMeshHit hit;
		
		if (!isFocused)
		{
			foreach (GameObject player in Players)
			{
				if (player.activeSelf)
				{
					if (Vector3.Angle(player.transform.position - transform.position, transform.forward) < _fov && (player.transform.position - transform.position).magnitude < 3f && !nav.Raycast(player.transform.position, out hit) || player.GetComponent<AudioSource>().minDistance > (player.transform.position - transform.position).magnitude)
					{
						Player = player.transform;
						audio = player.GetComponent<AudioSource>();
						isFocused = true;
						break;
					}
					if ((player.transform.position - transform.position).magnitude < (Player.position - transform.position).magnitude)
					{
						Player = player.transform;
						audio = player.GetComponent<AudioSource>();
					}
					
				}
			}
			
		}
		Vector3 targetDir = Player.position - transform.position;
		float angle = Vector3.Angle(targetDir, transform.forward);
		if (hint || ((targetDir).magnitude < 3f && !nav.Raycast(Player.position, out hit) && angle < _fov || audio.minDistance > targetDir.magnitude))
		{
			hint = false;
			isFocused = true;
			_time = 0f;
			nav.isStopped = false;
			anim.SetBool("walking",false);
			anim.SetBool("suspicious", false);
			anim.SetBool("detected", true);
			nav.SetDestination(Player.position);
		}
		else
		{
			isFocused = false;
			if (anim.GetBool("detected") && (Player.position - transform.position).magnitude < 2f)
			{
				_time = 0f;
				nav.isStopped = false;
				anim.SetBool("walking",false);
				anim.SetBool("suspicious", false);
				anim.SetBool("detected", true);
				nav.SetDestination(Player.position);
				isFocused = true;
			}
			
			if (audio.maxDistance > targetDir.magnitude)
			{
				anim.SetBool("suspicious",true);
				_fov = 90f;
			}
			if ((nav.destination - transform.position).magnitude <= 0.2f)
			{
				anim.SetBool("detected", false);
				if (anim.GetBool("walking"))
				{
					if (_time > 3f)
					{
						anim.SetBool("suspicious", false);
						_fov = 60f;
						_time = 0f;
					}
					anim.SetBool("walking",false);
					nav.isStopped = true;
					transform.rotation = initialDir;
				}
				else
				{
					anim.SetBool("suspicious",true);
					if (_time > 3f)
					{
						anim.SetBool("suspicious", false);
						anim.SetBool("walking", true);
						nav.SetDestination(initialPos);
						_time = 0f;
					}
				}
				if (anim.GetBool("suspicious"))
				{
					_time += Time.deltaTime;
				}
			}
		}
		
    }
}
