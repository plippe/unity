#pragma strict

var respawnTime: float;
var teleportInterval: float;
var explosion: GameObject;

var points: int = 100;

private var lastTeleport: float = 0;

function Start () {
	Teleport();
}

function Update () {
	lastTeleport += Time.deltaTime;
	if(lastTeleport > teleportInterval) {
		Respawn();
		Teleport();
		
		lastTeleport = -respawnTime;
	}
}

function Respawn() {
	GetComponent.<Renderer>().enabled = false;
	yield WaitForSeconds(respawnTime);
	GetComponent.<Renderer>().enabled = true;
}

function Destroy() {
	var explosionInstance: GameObject = Instantiate(explosion, transform.position, transform.rotation);
	GameObject.Destroy(explosionInstance, 3);
	
	GetComponent.<Renderer>().material.color = Color(Random.Range(0.0,1.0),Random.Range(0.0,1.0),Random.Range(0.0,1.0));
	
	Teleport();
}

function Teleport() {
	var position: Vector3 = new Vector3(Random.Range(-5, 5), Random.Range(-5, 5), 0);
	transform.position = position;
	
	lastTeleport = 0;
}