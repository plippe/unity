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
		rigidbody.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionZ;
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
			rigidbody.AddForce(velocity, ForceMode.VelocityChange);
			touchingPlatform = false;
			
			boosts = Mathf.Max (boosts - 1, 0);
		}
		
		
		if(transform.localPosition.y < gameOverY){
			GameEventManager.TriggerGameOver();
		}
	}
	
	void FixedUpdate () {
		if(touchingPlatform){
			rigidbody.AddForce(acceleration, 0f, 0f, ForceMode.Acceleration);
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
		renderer.enabled = true;
		rigidbody.isKinematic = false;
		enabled = true;
		boosts = 0;
	}
	
	private void GameOver () {
		renderer.enabled = false;
		rigidbody.isKinematic = true;
		enabled = false;
	}	
}