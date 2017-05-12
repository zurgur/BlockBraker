using UnityEngine;
using System.Collections;

public class LooseCollider : MonoBehaviour {
	void OnTriggerEnter2D(Collider2D sup){
		Brick.numberOfBricks = 0;
		Application.LoadLevel("Lose");
	}

	
	
}
