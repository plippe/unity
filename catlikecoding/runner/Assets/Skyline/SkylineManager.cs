using UnityEngine;
using System.Collections.Generic;

public class SkylineManager : ReusableQueue {	
	override protected void AfterRecycle(Transform o) { 
		nextPosition.x += o.localScale.x;
	}
}