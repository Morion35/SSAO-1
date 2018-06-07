using UnityEngine;
using UnityEngine.Networking;

public class EnemySpawner : NetworkBehaviour {

	public GameObject enemyPrefab;

	public override void OnStartServer()
	{
		GameObject enemy = Instantiate(enemyPrefab, transform.position, transform.rotation);
		NetworkServer.Spawn(enemy);
	}
}
