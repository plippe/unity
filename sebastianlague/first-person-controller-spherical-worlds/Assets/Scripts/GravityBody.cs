using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Rigidbody))]
public class GravityBody : MonoBehaviour {

	public GravityAttractor planet;

	void Awake() {
		rigidbody.useGravity = false;
		rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
	}

	void FixedUpdate() {
		planet.Attract(transform);
	}
}
