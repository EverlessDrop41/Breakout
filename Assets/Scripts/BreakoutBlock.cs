using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SpriteRenderer))]
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
    private SpriteRenderer SprRend;

	private int currentHealth;

	void Start () {

        SprRend = GetComponent<SpriteRenderer>();

		switch (Type) {
			case blockType.weak:
				maxHealth = 1;
                SprRend.sprite = BlockColourManager.Weak;
				break;
			case blockType.medium:
				maxHealth = 2;
                SprRend.sprite = BlockColourManager.Medium;
				break;
			case blockType.hard:
				maxHealth = 3;
                SprRend.sprite = BlockColourManager.Hard;
				break;
			case blockType.superHard:
				maxHealth = 4;
                SprRend.sprite = BlockColourManager.SuperHard;
				break;
			default:
				Debug.LogError("The type of block is not defined");
				break;
		}
		currentHealth = maxHealth;
	}

	void TakeDamage(){
		currentHealth--;

        switch (currentHealth)
        {
            case 3:
                SprRend.sprite = BlockColourManager.Hard;
                break;
            case 2:
                SprRend.sprite = BlockColourManager.Medium;
                break;
            case 1:
                SprRend.sprite = BlockColourManager.Weak;
                break;
        }
	}

	void Update () {
		if (currentHealth <= 0){
            ScoreManager sm = GameObject.FindObjectOfType<ScoreManager>();
            sm.SendMessage("BlockDestroyed");
			Destroy(this.gameObject);
		}
	}
}
