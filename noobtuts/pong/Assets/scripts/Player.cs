using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public KeyCode up;
	public KeyCode down;
	public int speed = 50;
	
	void FixedUpdate () {
		int direction = 0;
		if(Input.GetKey(up) && !Input.GetKey(down)) {
			direction = 1;
		} else if(!Input.GetKey(up) && Input.GetKey(down)) {
			direction = -1;
		}
		
		Vector3 velocity = new Vector3(0, speed * direction * Time.deltaTime, 0);
		rigidbody.velocity = velocity;
	}
}
