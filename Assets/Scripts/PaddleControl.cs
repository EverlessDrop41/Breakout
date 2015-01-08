using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(AudioSource))]
public class PaddleControl : MonoBehaviour {

	public float speed;
	public bool LockY = true;

	private float AxisInput;
	private float YPos;

	void Start() {
		if (LockY) {
			YPos = this.transform.position.y;
			InvokeRepeating("YPosLock",0,0.1F);
		}
	}

	void Update () {
		AxisInput = Input.GetAxis("Horizontal");
		this.gameObject.rigidbody2D.velocity = new Vector2(AxisInput * speed,0); 
	}

	void YPosLock() {
		this.transform.position = new Vector3(this.transform.position.x,YPos,this.transform.position.z);
	}
}
