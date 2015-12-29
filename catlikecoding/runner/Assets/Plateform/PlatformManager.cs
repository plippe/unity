using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class PlatformOption {
	public PhysicMaterial physicMaterial;
	public Material material;
}

public class PlatformManager : ReusableQueue {
	
	public PlatformOption[] options;

	public Vector3 minGap, maxGap;
	public float minY, maxY;
	
	public Booster booster;
		
	override protected void AfterRecycle(Transform o) { 
		UpdateOption(o);
		UpdateNextPosition(o);
		
		booster.SpawnIfAvailable(o.position);
	}
	
	void UpdateOption(Transform o) {
		int optionIndex = Random.Range(0, options.Length);
		PlatformOption option = options[optionIndex];
		o.GetComponent<Renderer>().material = option.material;
		o.GetComponent<Collider>().material = option.physicMaterial;
	}
	
	void UpdateNextPosition(Transform o) {
		nextPosition += new Vector3(
			Random.Range(minGap.x, maxGap.x) + o.localScale.x,
			Random.Range(minGap.y, maxGap.y),
			Random.Range(minGap.z, maxGap.z));
		
		if(nextPosition.y < minY){ nextPosition.y = minY + maxGap.y; }
		else if(nextPosition.y > maxY){	nextPosition.y = maxY - maxGap.y; }
	}
}