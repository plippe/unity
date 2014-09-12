using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	public Collider p1Goal;
	public Collider p2Goal;
		
	int p1Score = 0;
	int p2Score = 0;
	public GUIText guiScore;
	
	int speed = 300;
	
	// Use this for initialization
	void Start () {
		Reset();
	}
		
	void OnTriggerEnter(Collider el) {
		if(el == p1Goal) { p1Score++; }		
		if(el == p2Goal) { p2Score++; }
		
		if(el == p1Goal || el == p2Goal) {
			UpdateScore();
			Reset();
		}
	}
	
	void Reset() {
		transform.position = new Vector3(0, 0, 0);
		
		int direction = 1;
		if(Random.value > 0.5) { direction = -1; }
		Vector3 velocity = new Vector3(direction, Random.Range(-1f, 1f), 0);
		rigidbody.velocity = velocity * speed * Time.deltaTime;
	}
	
	void UpdateScore() {
		string score = p1Score.ToString() + " : " + p2Score.ToString();
		guiScore.text = score;
	}
}
