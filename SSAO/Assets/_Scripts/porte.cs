using UnityEngine;

using System.Collections;



public class porte : MonoBehaviour {

    public Rigidbody rig;

    public int HP;

    private Vector3 pos;



    private void Start()

    {
        rig = GetComponent<Rigidbody>();
        HP = 100;
    }


    private void FixedUpdate()

    {

        if (HP <= 0)
        {
            rig.AddForce(-20,0,0);
            
        }
    }
}