using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {	
	public GameObject player;
	public int speed = 20;

	bool launched;
	void shootBall() {
		launched = true;
		
		Vector3 velocity = new Vector3(0, 1, 0);
		GetComponent<Rigidbody>().velocity = velocity * speed;
	}
	
	void Update() {
		if(!launched) {
			Vector3 position = new Vector3(player.transform.position.x, -5, 0);		
			transform.position = position;
			
			if(Input.GetKey("space")) { shootBall(); }
		}
	}
	
	void Start() {
		launched = false;
	}

	void OnTriggerEnter(Collider c) {
		Start();
	}
	
	void OnCollisionEnter(Collision c) {
		if(c.collider == player.GetComponent<Collider>()) {
			float angle = c.contacts[0].point.x - player.transform.position.x;
			Vector3 velocity = new Vector3(angle * 20, GetComponent<Rigidbody>().velocity.y, 0);
			
			GetComponent<Rigidbody>().velocity = velocity;
		}	
	}
}
