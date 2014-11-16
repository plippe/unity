using UnityEngine;
using System.Collections;

public class GravityAttractor : MonoBehaviour {

	public float force = -10f;

	public void Attract(Transform body) {
		Vector3 targetDirection = (body.position - transform.position).normalized;
		Vector3 bodyUp = body.up;

		body.rotation = Quaternion.FromToRotation(bodyUp, targetDirection) * body.rotation;
		body.rigidbody.AddForce(targetDirection * force);
	}

}
