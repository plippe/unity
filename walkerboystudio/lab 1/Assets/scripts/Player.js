#pragma strict

var score: int = 0;
var playTime: float = 30;

function Start() {
	InvokeRepeating("Countdown", 1, 1);
}

function Update () {
	if(Input.GetMouseButtonDown(0)) {		
		var hit : RaycastHit;
		var ray: Ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		if (Physics.Raycast(ray, hit, 100)) {
			switch(hit.collider.tag) {
				case "Enemy":
					var enemyComponent: Enemy = hit.collider.GetComponent("Enemy");
					enemyComponent.Destroy();
					
					score += enemyComponent.points;
					
					break;
			}
		}
	}
}

function Countdown() {	
	playTime -= 1;
	
	if (playTime <= 0) {
		CancelInvoke("Countdown");
		Application.LoadLevel("win");
	}
}

function OnGUI() {
	GUI.Label(Rect(10, 10, 100, 20), "Time Left: " + playTime);
	GUI.Label(Rect(10, 30, 100, 20), "Score: " + score);
}