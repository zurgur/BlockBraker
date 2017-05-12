using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {
	public AudioClip crak;
	private int maxHits;
	public Sprite[] hitSprits;
	private int timesHit;
	private LevelManeger levelMan;
	private int numberOfbrakes;
	public static int numberOfBricks = 0;
	private bool isBreakable;
	public GameObject smoke;
	// Use this for initialization
	void Start () {
		timesHit = 0;
		levelMan = GameObject.FindObjectOfType<LevelManeger>();
		maxHits = hitSprits.Length + 1;
		
		//keep track of brackable brikcs
		isBreakable = (this.tag == "Breakable");
		if(isBreakable){
			numberOfBricks++;
		}
	}
	
	
	void OnCollisionEnter2D(Collision2D col){
		if(isBreakable){
			handleHits();
		}
	}
	void handleHits(){
		timesHit++;
		AudioSource.PlayClipAtPoint(crak,transform.position);
		if(timesHit>= maxHits){
			numberOfBricks--;
			GameObject some = Instantiate(smoke, gameObject.transform.position, Quaternion.identity) as GameObject;
			some.particleSystem.startColor = gameObject.GetComponent<SpriteRenderer>().color;
			
			levelMan.BrickDestroyd();
			Destroy(gameObject);
			
		}else{
			LoadSprites();
		}
	}
	
	//TODO remuve this once we can actualy win
	void simulateWin(){
		levelMan.LoadNextLevel();
	}
	void LoadSprites(){
		int spriteIndet = timesHit - 1;
		if(hitSprits[spriteIndet]){
			this.GetComponent<SpriteRenderer>().sprite = hitSprits[spriteIndet];
		}else{
			Debug.LogError("Brick sprite missing");
		}
	}
}
