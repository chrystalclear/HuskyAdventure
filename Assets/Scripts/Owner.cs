using UnityEngine;
using System.Collections;

public class Owner : MonoBehaviour {

	public Player player;
	private Animator animator;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D target)
	{
		if (target.gameObject.tag == "Player")
		{
			if (player.numDogsLeft == 0)
			{
				animator.SetInteger ("AnimState", 1);
			}
		}
	}
}
