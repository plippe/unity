using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour
{
	public GameObject playerExplosion;
	public GameObject enemyExplosion;

	public GameController gameController;
	public int scoreValue;

	void Start() {
		GameObject instance = GameObject.FindGameObjectWithTag("GameController");
		if(instance != null) 
			gameController = instance.GetComponent<GameController>();
	}

	void OnTriggerEnter (Collider other)
	{	
		switch (other.tag) {
		case "Boundary": 
			return;
			break;
		case "Player":
			Instantiate (playerExplosion, transform.position, transform.rotation);
			break;
		default:
			Instantiate (enemyExplosion, transform.position, transform.rotation);
			gameController.addScore (scoreValue);
			break;
		}

		Destroy (gameObject);
		Destroy (other.gameObject);
	}
}
