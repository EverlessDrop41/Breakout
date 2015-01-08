using UnityEngine;
using System.Collections;
using System.Threading;

[RequireComponent(typeof(Rigidbody2D),typeof(AudioSource))]
public class BallBehaviour : MonoBehaviour {

	public float MaxVelocity;
	public int StuckAmountMax = 60;

	private Rigidbody2D RB;
	private AudioSource speaker;

	float PrevY;
	float CurrentY;
	int StuckCounter;

	void Start () {
		RB = this.gameObject.rigidbody2D;
		speaker = this.gameObject.audio;
		RB.AddForce(Vector2.up,ForceMode2D.Impulse);
	}

	void FixedUpdate () {
		RB.velocity = Vector2.ClampMagnitude(RB.velocity,MaxVelocity);

		CurrentY = this.gameObject.transform.position.y;
		if (CurrentY == PrevY){
			StuckCounter++;
		}
		else {
			StuckCounter = 0;
		}
		if (StuckCounter > StuckAmountMax){
			RB.AddForce(Vector2.up,ForceMode2D.Impulse);
		}
		PrevY = CurrentY; 
	}

	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.tag == "Block") {
			coll.gameObject.SendMessage("TakeDamage");
			speaker.Play();
		}
	}
}
