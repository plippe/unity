using UnityEngine;
using System.Collections;

public class Test1Trigger : MonoBehaviour {
	void Update () {
		if (Input.GetKeyDown ("q")) {
			EventManager.TriggerEvent("test");
		}
		
		if (Input.GetKeyDown ("w")) {
			EventManager.TriggerEvent("Spawn");
		}

		if (Input.GetKeyDown ("e")) {
			EventManager.TriggerEvent("Destroy");
		}
	}
}
