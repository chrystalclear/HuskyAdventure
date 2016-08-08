using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	
	public float speed = 10f;
	public Vector2 maxVelocity = new Vector2(5,5);
	public int numDogsLeft = 11;
	public bool dead = false;

	private PlayerController controller;
	private Animator animator;

	// Use this for initialization
	void Start () {
		controller = GetComponent<PlayerController> ();
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!dead) {
			var forceX = 0f;
			var forceY = 0f;
	
			var absVelX = Mathf.Abs (rigidbody2D.velocity.x);
			var absVelY = Mathf.Abs (rigidbody2D.velocity.y);

			if (controller.moving.x != 0) {
				if (absVelX < maxVelocity.x) {
					forceX = speed * controller.moving.x;
					animator.SetInteger ("AnimState", 1);
				} else {
					animator.SetInteger ("AnimState", 0);
				}
				transform.localScale = new Vector3 (forceX > 0 ? 3.5f : -3.5f, 3.5f, 1);
			} else if (controller.moving.y != 0) {
				if (absVelY < maxVelocity.y) {
					forceY = speed * controller.moving.y;
					animator.SetInteger ("AnimState", forceY > 0 ? 2 : 3);
				} else {
					animator.SetInteger ("AnimState", 0);
				}
			} else {
				animator.SetInteger ("AnimState", 0);
			}
			rigidbody2D.AddForce (new Vector2 (forceX, forceY));
		}
		else {
			animator.SetInteger ("AnimState", -1);
		}
	
	}
}
