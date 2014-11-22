using UnityEngine;

public class Booster : MonoBehaviour {
	
	public Runner runner;
	
	public Vector3 offset, rotationVelocity;
	public float recycleOffset, spawnChance;
	
	
	void Start () {
		GameEventManager.GameOver += GameOver;
		GameOver();
	}
	
	void Update () {
		if(transform.localPosition.x + recycleOffset < runner.transform.position.x){
			gameObject.SetActive(false);
			return;
		}
		
		transform.Rotate(rotationVelocity * Time.deltaTime);
	}
	
	public void SpawnIfAvailable (Vector3 position) {
		if(gameObject.activeSelf || spawnChance <= Random.Range(0f, 100f)) { return; }
		
		transform.localPosition = position + offset;
		gameObject.SetActive(true);
	}
	
	void OnTriggerEnter () {
		runner.AddBoost();
		gameObject.SetActive(false);
	}
		
	private void GameOver () {
		gameObject.SetActive(false);
	}
}