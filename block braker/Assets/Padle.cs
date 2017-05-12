using UnityEngine;
using System.Collections;

public class Padle : MonoBehaviour {
	public bool autoPlay = false;
	private Ball ball;
	// Use this for initialization
	void Start () {
		ball = GameObject.FindObjectOfType<Ball>();
		
	}
	
	// Update is called once per frame
	void Update () {
		if(!autoPlay){
			MoveWithMouse();
		}else{
			MoveWithBall();
		}	
	}
	
	void MoveWithMouse(){
		float xPos = (Input.mousePosition.x / Screen.width) * 16;
		xPos = Mathf.Clamp(xPos,0.5f,15.5f);
		Vector3 x = new Vector3(xPos, 0.5f, 0f);
		this.transform.position = x;	
	}
	void MoveWithBall(){
		Vector3 xPos = ball.transform.position;
		xPos.x = Mathf.Clamp(xPos.x,0.5f,15.5f);
		Vector3 x = new Vector3(xPos.x, 0.5f, 0f);
		this.transform.position = x;
	}
	
}
