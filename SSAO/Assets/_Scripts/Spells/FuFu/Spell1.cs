using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell1 : MonoBehaviour {

	private float cost = 60f;
	
	void Awake () {
		
		GetComponentInParent<PlayerStatus>().mana -= cost;
	}
	
}
