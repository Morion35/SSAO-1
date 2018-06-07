using UnityEngine;
using System.Collections;

public class Tonneau : MonoBehaviour
{
    public Transform Trans;
    public Explosion expl;
    public Rigidbody rig;
    public int HP;
    private Vector3 pos;
    void Start()
    {
        rig = GetComponent<Rigidbody>();
        HP = 10;


    }
    void OnTriggerEnter(Collider other) 
    {
        if ((other.tag == "Player") || (other.tag == "Enemy" )|| (other.tag == "Spell"))
        {
            Instantiate(expl, Trans.position, transform.rotation);
            HP -= 10;
        }
    }

    void FixedUpdate()
    {
        if (HP <= 0)
        {
            Destroy(Trans.gameObject);
        }
    }
}