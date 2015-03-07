using UnityEngine;
using System.Collections;

public class BreakoutBlock : MonoBehaviour {
	///<summary>
	/// 	The different types of beakout block available
	/// </summary>
	public enum blockType {
		weak,
		medium,
		hard,
		superHard
	};
	
	public blockType Type;
	private int maxHealth;

	private int currentHealth;

	void Start () {
		switch (Type) {
			case blockType.weak:
				maxHealth = 1;
				break;
			case blockType.medium:
				maxHealth = 2;
				break;
			case blockType.hard:
				maxHealth = 3;
				break;
			case blockType.superHard:
				maxHealth = 4;
				break;
			default:
				Debug.LogError("The type of block is not defined");
				break;
		}
		currentHealth = maxHealth;
	}

	void TakeDamage(){
		currentHealth--;
	}

	void Update () {
		if (currentHealth <= 0){
            ScoreManager sm = GameObject.FindObjectOfType<ScoreManager>();
            sm.SendMessage("BlockDestroyed");
			Destroy(this.gameObject);
		}
	}
}
