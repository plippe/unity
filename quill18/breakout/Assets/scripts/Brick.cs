using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {
	void OnCollisionEnter(Collision c) {
		Destroy(gameObject);
	}
}
