using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
	private Padle padle;
	private bool hasStarted = false;
	private Vector3 padleToBall;
	// Use this for initialization
	void Start () {
	padle = GameObject.FindObjectOfType<Padle>();
		padleToBall = this.transform.position - padle.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if(!hasStarted){
			this.transform.position = padle.transform.position + padleToBall;
			if (Input.GetMouseButton(0)){
				hasStarted = true;
				this.rigidbody2D.velocity = new Vector2 (2f,10f);
			}
		
		}
	}
	void OnCollisionEnter2D(){
		Vector2 tweak = new Vector2(Random.Range(0f,0.2f),Random.Range(0f,0.2f));
		if(hasStarted){
			audio.Play();
		}
		rigidbody2D.velocity += tweak;
	}
}
