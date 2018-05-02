using UnityEngine;

using System.Collections;



public class porte : MonoBehaviour {

    public Rigidbody rig = new Rigidbody();

    public int HP;

    private Vector3 pos;



    private void Start()

    {
        
        pos = rig.transform.position;

        HP = 300;

    }


    private void FixedUpdate()

    {

        if (IsDead())
        {
            Fall();
            
        }
    }


    private void OnTriggerEnter(Collider other)

    {

        if (other.tag == "Spell")

            HP -= 5;

    }


    private bool IsDead()

    {

        return HP <= 0;

    }


    private void Fall()

    {

        pos = rig.transform.position;

        if (pos.y >= -10F)

        {

            pos.y -= 0.05F;

        }

        rig.transform.position = pos;

    }
}