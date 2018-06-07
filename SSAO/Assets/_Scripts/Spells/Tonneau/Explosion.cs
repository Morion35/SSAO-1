using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour
{
    private float damage = 40f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("enemy"))
        {
            other.GetComponent<enemyMovement>().HP -= damage;
        }
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerStatus>().HP -= damage - damage * other.GetComponent<PlayerStatus>().armor / 100;
        }  
    }
}