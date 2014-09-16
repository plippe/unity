using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public int playerSpeed = 500;
		
	void movePlayer() {
		float horizontal = Input.GetAxis("Horizontal");		
		Vector3 force = new Vector3(horizontal, 0, 0);
		
		rigidbody.velocity = force * playerSpeed * Time.deltaTime;		
	}
			
	void FixedUpdate() {
		movePlayer();
	}
}
