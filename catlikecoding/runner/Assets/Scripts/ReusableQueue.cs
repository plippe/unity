using UnityEngine;
using System.Collections.Generic;

public abstract class ReusableQueue : MonoBehaviour {
	
	public Transform mainObject;
	
	public Transform prefab;
	
	public int numberOfObjects;
	public float recycleOffset;
	public Vector3 startPosition;
	public Vector3 minSize, maxSize;
	
	protected Vector3 nextPosition;
	private Queue<Transform> objectQueue;
	
	void Start () {
		GameEventManager.GameStart += GameStart;
		GameEventManager.GameOver += GameOver;
		
		Vector3 offScreen = new Vector3(0f, 0f, -100f);
		objectQueue = new Queue<Transform>(numberOfObjects);
		for(int i = 0; i < numberOfObjects; i++){
			objectQueue.Enqueue(Instantiate(prefab, offScreen, Quaternion.identity) as Transform);
		}
		
		
		GameOver();
	}
	
	private void GameStart () {
		nextPosition = startPosition;
		for(int i = 0; i < numberOfObjects; i++){
			Recycle();
		}
		enabled = true;
	}
	
	private void GameOver () {
		enabled = false;
	}
	
	void Update () {
		if(objectQueue.Peek().localPosition.x + recycleOffset < mainObject.position.x){
			Recycle();
		}
	}
	
	private void Recycle () {
		Transform o = objectQueue.Dequeue();	
		BeforeRecycle(o);
		Recycle(o);
		AfterRecycle(o);
		objectQueue.Enqueue(o);
	}
	
	private void Recycle (Transform o) {
		Vector3 scale = new Vector3(
			Random.Range(minSize.x, maxSize.x),
			Random.Range(minSize.y, maxSize.y),
			Random.Range(minSize.z, maxSize.z));
		
		Vector3 position = nextPosition;
		position.x += scale.x * 0.5f;
		position.y += scale.y * 0.5f;
		
		o.localScale = scale;
		o.localPosition = position;
	}
	
	protected virtual void BeforeRecycle(Transform o) { }
	protected virtual void AfterRecycle(Transform o) { }
}