using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary {
	public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour {
	public float speed;
	public float tilt;
	public Boundary boundary;
	public GameObject shot;
	public Transform spawn;
	public float fireRate;

	float nextFire = 0;

	void FixedUpdate() {
		float horizontal = Input.GetAxis("Horizontal");
		float vertical = Input.GetAxis("Vertical");
		
		Vector3 velocity = new Vector3(horizontal, 0, vertical) * speed;
		GetComponent<Rigidbody>().velocity = velocity;
		
		GetComponent<Rigidbody>().position = new Vector3(
			Mathf.Clamp(GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax), 
			0, 
			Mathf.Clamp(GetComponent<Rigidbody>().position.z, boundary.zMin, boundary.zMax)
		);
		
		GetComponent<Rigidbody>().rotation = Quaternion.Euler(0, 0, GetComponent<Rigidbody>().velocity.x * -tilt);
	}

	void Update() {
		if(Input.GetButton("Jump")&& Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			Instantiate(shot, spawn.position, spawn.rotation);
		}
	}
}
