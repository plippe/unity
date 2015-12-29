using UnityEngine;

[RequireComponent (typeof(Rigidbody))]
public class Runner : MonoBehaviour {
		
	public float acceleration;
	public Vector3 jumpVelocity;
	public Vector3 boostVelocity;
	public float gameOverY;
	
	private Vector3 startPosition;
	private bool touchingPlatform;
	private static int boosts;
	
	void Awake() {
		GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionZ;
	}	
	
	void Start () {
		GameEventManager.GameStart += GameStart;
		GameEventManager.GameOver += GameOver;
		
		startPosition = transform.localPosition;
		GameOver();
	}
	
	void Update () {
		if(touchingPlatform && Input.GetButtonDown("Jump")){
			Vector3 velocity = (boosts > 0)? boostVelocity : jumpVelocity;
			GetComponent<Rigidbody>().AddForce(velocity, ForceMode.VelocityChange);
			touchingPlatform = false;
			
			boosts = Mathf.Max (boosts - 1, 0);
		}
		
		
		if(transform.localPosition.y < gameOverY){
			GameEventManager.TriggerGameOver();
		}
	}
	
	void FixedUpdate () {
		if(touchingPlatform){
			GetComponent<Rigidbody>().AddForce(acceleration, 0f, 0f, ForceMode.Acceleration);
		}
	}
	
	void OnCollisionEnter () {
		touchingPlatform = true;
	}
	
	void OnCollisionExit () {
		touchingPlatform = false;
	}	
	
	public void AddBoost() {
		boosts += 1;
	}
	
	private void GameStart () {
		transform.localPosition = startPosition;
		GetComponent<Renderer>().enabled = true;
		GetComponent<Rigidbody>().isKinematic = false;
		enabled = true;
		boosts = 0;
	}
	
	private void GameOver () {
		GetComponent<Renderer>().enabled = false;
		GetComponent<Rigidbody>().isKinematic = true;
		enabled = false;
	}	
}