using UnityEngine;
using System.Collections;

public class LevelManeger : MonoBehaviour {

	public void LoadLevel(string name){
		Brick.numberOfBricks = 0;
		Application.LoadLevel(name);
		
	}
	public void exitRequest(){
		Application.Quit();
	
	}
	public void LoadNextLevel(){
		Brick.numberOfBricks = 0;
		Application.LoadLevel(Application.loadedLevel +1);
	}
	public void BrickDestroyd(){
		if(Brick.numberOfBricks <= 0){
			LoadNextLevel();
		}
	}
}
