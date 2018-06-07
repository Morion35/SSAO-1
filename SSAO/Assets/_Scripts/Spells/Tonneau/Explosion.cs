using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour
{
    private float damage = 40f;

    private GameObject[] players;
    private GameObject[] enemies;

    private void Awake()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        enemies = GameObject.FindGameObjectsWithTag("enemy");

        foreach (GameObject enemy in enemies)
        {
            if (enemy != null && (enemy.transform.position - transform.position).magnitude <= 2f)
            {
                enemy.GetComponent<enemyMovement>().HP -= damage;
            }
        }
        foreach (GameObject player in players)
        {
            if ((player.transform.position - transform.position).magnitude <= 2f)
            {
                player.GetComponent<PlayerStatus>().HP -= (damage - (damage*player.GetComponent<PlayerStatus>().armor/100));
            }
        }
    }
    
    
}