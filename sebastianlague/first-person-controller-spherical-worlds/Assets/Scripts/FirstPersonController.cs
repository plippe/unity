using UnityEngine;
using System.Collections;

public class FirstPersonController : MonoBehaviour {

	public float mouseSensitivityX = 250f;
	public float mouseSensitivityY = 250f;
	public float moveSpeed = 5f;
	public float jumpForce = 220;

	Transform cameraTransform;
	float verticalLookRotation;

	Vector3 moveAmount;
	Vector3 moveSmoothing;

	void Start () {
		cameraTransform = Camera.main.transform;
	}

	void Update () {
		MoveCamera();
		MovePlayer();
	}

	void FixedUpdate() {
		rigidbody.MovePosition(rigidbody.position + transform.TransformDirection(moveAmount) * Time.fixedDeltaTime);
	}

	void MoveCamera() {		
		transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * Time.deltaTime * mouseSensitivityX);

		verticalLookRotation += Input.GetAxis("Mouse Y") * Time.deltaTime * mouseSensitivityY;
		verticalLookRotation = Mathf.Clamp(verticalLookRotation, -60, 60);
		cameraTransform.localEulerAngles = Vector3.left * verticalLookRotation; 
	}

	void MovePlayer() {
		Vector3 moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"),0,Input.GetAxisRaw("Vertical")).normalized;
		Vector3 targetMoveAmount = moveDirection * moveSpeed;
		moveAmount = Vector3.SmoothDamp(moveAmount, targetMoveAmount, ref moveSmoothing, 0.15f); 
		
		if(Input.GetButtonDown("Jump") && isGrounded()) {
			rigidbody.AddForce(transform.up * jumpForce);
		}
	}

	bool isGrounded() {
		Ray ray = new Ray(transform.position, -transform.up);
		RaycastHit hit;

		if(Physics.Raycast(ray, out hit, 1.1f)) 
			return true;

		return false;
	}
}
