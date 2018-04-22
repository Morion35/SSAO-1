using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyMovement : MonoBehaviour {

    Transform Player;

    UnityEngine.AI.NavMeshAgent nav;

    Animator anim;

    private Vector3 initialPos;

	private Quaternion initialDir;

	// Use this for initialization
	void Awake () {
        initialPos = transform.position;

		initialDir = transform.rotation;

        Player = GameObject.FindGameObjectWithTag("Player").transform;

        nav = GetComponent<NavMeshAgent>();

        anim = GetComponent<Animator>();
        
	}
	
	// Update is called once per frame
	void Update () {
	    NavMeshHit hit;
	    Vector3 targetDir = Player.position - transform.position;
	    float angle = Vector3.Angle(targetDir, transform.forward);
        if ((Player.position - transform.position).magnitude < 2f && !nav.Raycast(Player.position, out hit) && angle < 60f)
        {
            nav.isStopped = false;
            nav.SetDestination(Player.position);
            anim.SetBool("player in sight", true);
        }
        else
        {
            
            if ((transform.position - initialPos).magnitude <= 0.5f)
            {
                anim.SetBool("player in sight", false);
                nav.isStopped = true;
	            transform.rotation = initialDir;
            }
            else
                nav.SetDestination(initialPos);
                
        }
    }
}
