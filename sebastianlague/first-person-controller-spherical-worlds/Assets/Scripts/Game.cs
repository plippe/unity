using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour {

	void Update () {
		if(Input.GetKey(KeyCode.Escape)) {
			print ("Should exit");
			Application.Quit();
		}
	}
}
