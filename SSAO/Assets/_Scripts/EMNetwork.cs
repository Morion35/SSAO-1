using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Networking;
public class EMNetwork : NetworkBehaviour {

	[SyncVar]
	public bool isFocused;

	[SyncVar]
	public bool hint;

	public Transform Player;

	[SyncVar]
	public float HP = 100;
	
	private GameObject[] Players;
	
	AudioSource audio;

    UnityEngine.AI.NavMeshAgent nav;

	float _time;

	private float _fov = 60f;

    Animator anim;

    private Vector3 initialPos;

	private Quaternion initialDir;

	public float firetime = 3f;

	public float damage = 15f;

	private float fireuse = 4f;

	// Use this for initialization
	void Start () {
		
        initialPos = transform.position;
		
		initialDir = transform.rotation;

		Players = GameObject.FindGameObjectsWithTag("Player");

		int i = 0;
		while (i < Players.Length && !Players[i].activeSelf)
		{
			i++;
		}
		Player = Players[i].transform;

		isFocused = false;

		audio = Players[0].GetComponent<AudioSource>();

        nav = GetComponent<NavMeshAgent>();

        anim = GetComponent<Animator>();
		fireuse = 0f;
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
					if (Vector3.Angle(player.transform.position - transform.position, transform.forward) < _fov && (player.transform.position - transform.position).magnitude < 3f
					    && !nav.Raycast(player.transform.position, out hit) || player.GetComponent<AudioSource>().minDistance > (player.transform.position - transform.position).magnitude)
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
			if (anim.GetBool("detected") && (Player.position - transform.position).magnitude < 1f)
			{
				_time = 0f;
				nav.isStopped = false;
				anim.SetBool("walking",false);
				anim.SetBool("suspicious", false);
				anim.SetBool("detected", true);
				nav.SetDestination(Player.position);
				isFocused = true;
			}
			else
			{
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
		if (anim.GetBool("detected") && (Player.position - transform.position).magnitude < 0.45f && Time.time > fireuse)
		{
			fireuse = Time.time + firetime;
			Player.GetComponent<PSNetwork>().Damage(damage);
		}
		if (Player.GetComponent<PSNetwork>().isdead)
		{
			Players = GameObject.FindGameObjectsWithTag("Player");
			isFocused = false;
			Player = Players[0].transform;
		}
    }

	private void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.CompareTag("porte"))
		{
			other.gameObject.GetComponent<porte>().HP = 0;
		}
	}

	public void Damage(float damage)
	{
		if (!isServer)
		{
			return;
		}
		HP -= damage;
	}
}
