using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	public int startDelay;

	public GameObject[] hazards;
	public float hazardDelay;
	public Vector3 spawnValues;

	public GUIText scoreText;
	public GUIText gameOverText;
	int score;

	bool gameOver;

	void Update() {
		gameOver = GameObject.FindGameObjectWithTag("Player") == null;

		if(gameOver) {
			gameOverText.text = "You lost";
			gameOverText.enabled = true;
		}

		if(gameOver && GameObject.FindGameObjectWithTag("Enemy") == null) {
			print ("Quit");
			Application.Quit();
		}
	}

	IEnumerator SpawnWave() {
		yield return new WaitForSeconds(startDelay);
		while(true) {
			Instantiate(
				hazards[Random.Range(0, hazards.Length)], 
				new Vector3(Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z), 
				Quaternion.identity);	
			
			yield return new WaitForSeconds(hazardDelay);

			if(gameOver)
				break;
		}
	}

	void Start () {
		score = 0;
		StartCoroutine(SpawnWave());
	}

	public void addScore(int addedValue) {
		score += addedValue;
		updateScore();
	}

	void updateScore() {
		scoreText.text = "Score: " + score;
	}
}
