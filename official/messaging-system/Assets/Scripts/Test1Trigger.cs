using UnityEngine;
using System.Collections;

public class Test1Trigger : MonoBehaviour {
	void Update () {
		if (Input.GetKeyDown ("q")) {
			EventManager.TriggerEvent("test");
		}
	}
}
