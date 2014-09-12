using UnityEngine;
using System.Collections;

public class Rotador : MonoBehaviour {
	
	void Update () {
		Vector3 rotate = new Vector3(15, 30, 45);
		transform.Rotate(rotate * Time.deltaTime);
	}
}
