using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyMovement : MonoBehaviour {

    Transform Player;
	
	AudioSource audio;

    UnityEngine.AI.NavMeshAgent nav;

	float _time;

	private float _fov = 60f;

    Animator anim;

    private Vector3 initialPos;

	private Quaternion initialDir;

	// Use this for initialization
	void Awake () {
        initialPos = transform.position;

		initialDir = transform.rotation;

        Player = GameObject.FindGameObjectWithTag("Player").transform;

		audio = GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>();

        nav = GetComponent<NavMeshAgent>();

        anim = GetComponent<Animator>();
        
	}
	
	// Update is called once per frame
	void Update ()
	{
	    NavMeshHit hit;
		Vector3 targetDir = Player.position - transform.position;
		float angle = Vector3.Angle(targetDir, transform.forward);
		if ((Player.position - transform.position).magnitude < 3f && !nav.Raycast(Player.position, out hit) && angle < _fov || audio.minDistance > targetDir.magnitude)
		{
			_time = 0f;
			nav.isStopped = false;
			anim.SetBool("walking",false);
			anim.SetBool("suspicious", false);
			anim.SetBool("detected", true);
			nav.SetDestination(Player.position);
		}
		else
		{
			if (anim.GetBool("detected") && (Player.position - transform.position).magnitude < 2f)
			{
				_time = 0f;
				nav.isStopped = false;
				anim.SetBool("walking",false);
				anim.SetBool("suspicious", false);
				anim.SetBool("detected", true);
				nav.SetDestination(Player.position);
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
