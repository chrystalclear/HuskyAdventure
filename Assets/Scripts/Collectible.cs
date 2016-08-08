using UnityEngine;
using System.Collections;

public class Collectible : MonoBehaviour {

	public Player player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter2D(Collider2D target)
	{
		if (target.gameObject.tag == "Player")
		{
			player.numDogsLeft -= 1;
			Destroy (gameObject);
		}
	}
}
