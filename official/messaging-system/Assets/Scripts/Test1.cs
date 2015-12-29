using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class Test1 : MonoBehaviour {

	private UnityAction someListener;

	void Awake() {
		someListener = new UnityAction (SomeFunction);
	}

	void OnEnable() {
		EventManager.StartListening ("test", someListener);
	}

	void OnDisable() {
		EventManager.StopListening ("test", someListener);
	}

	void SomeFunction() {
		Debug.Log ("Was Called");
	}
}
