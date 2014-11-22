using UnityEngine;
using System.Collections;

public class GuiManager : MonoBehaviour {
	
	public GUIText gameOverText, instructionsText, runnerText, timeText;
	
	private bool running;
	private float runningFor;
	
	void Start () {
		GameEventManager.GameStart += GameStart;
		GameEventManager.GameOver += GameOver;
		gameOverText.enabled = false;
		timeText.enabled = false;
		running = false;
	}
	
	void Update () {
		if(running) {
			runningFor += Time.deltaTime;
			timeText.text = ((int)runningFor).ToString();		
		} else {
			if(Input.GetKeyDown(KeyCode.Space)){
				GameEventManager.TriggerGameStart();
			}
			
			if(Input.GetKeyDown(KeyCode.Escape)){
				Debug.Log("Quit called");
				Application.Quit();
			}
		}
	}
	
	private void GameStart () {
		gameOverText.enabled = false;
		instructionsText.enabled = false;
		runnerText.enabled = false;
		timeText.enabled = true;
		running = true;
		runningFor = 0;		
	}
	
	private void GameOver () {
		gameOverText.enabled = true;
		instructionsText.enabled = true;		
		running = false;
	}
}
