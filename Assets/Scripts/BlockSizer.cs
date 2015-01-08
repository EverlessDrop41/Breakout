using UnityEngine;
using System.Collections;

public class BlockSizer : MonoBehaviour {
	//TODO: IMPLEMENT THIS SCRIPT
	public int PercentageWidth = 25;

	void Start () {
		//Validate Percentage
		if (PercentageWidth > 100)
			Debug.LogError (string.Format("{0} is to large to be a percentage.",PercentageWidth));
		else if (PercentageWidth < 0)
			Debug.LogError (string.Format("{0} is to small to be a percentage.",PercentageWidth));
	}

	void Update () {
	
	}

	void Resize(int width){

	}
}
