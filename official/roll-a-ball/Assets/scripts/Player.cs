using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	int speed = 25;
	
	public GUIText scoreGui;
	int score = 0;
	int maxScore = 4;
	
	public GUIText successGui;
	
	void Start() {
		scoreGui.text = score.ToString();	
	}
	
	void FixedUpdate () {
	
		float horizontal = Input.GetAxis("Horizontal") * speed;
		float vertical = Input.GetAxis("Vertical") * speed;
		
		Vector3 force = new Vector3(horizontal, 0, vertical);
		
		rigidbody.AddForce(force * speed * Time.deltaTime);
	}
	
	void OnTriggerEnter (Collider el) {
		if(el.gameObject.tag == "PickUp") {
			Destroy(el.gameObject);
			UpdateScore();
		}
	}
	
	void UpdateScore () {
		score++;
		scoreGui.text = score.ToString();
		if(score >= maxScore) {
			successGui.text = "You Win";
		}
	}
}
