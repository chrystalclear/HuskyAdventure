using UnityEngine;
using System.Collections;

public class Meter : MonoBehaviour {

	public float time = 200;
	public float maxTime = 200;
	public float timerRate = 1f;
	public Texture2D bgTexture;
	public Texture2D timeBarTexture;
	public int iconWidth = 32;
	public Vector2 timerOffset = new Vector2 (10, 10);

	private Player player;

	// Use this for initialization
	void Start () {
		player = GameObject.FindObjectOfType<Player> ();
	}

	void OnGUI()
	{
		var percent = Mathf.Clamp01 (time / maxTime);

		if (!player) {
			percent = 0;
		}
		DrawMeter (timerOffset.x, timerOffset.y, timeBarTexture, bgTexture, percent);
	}

	void DrawMeter (float x, float y, Texture2D texture, Texture2D background, float percent)
	{
		var bgW = background.width;
		var bgH = background.height;

		GUI.DrawTexture (new Rect (x, y, bgW, bgH), background);

		var nW = ((bgW - iconWidth) * percent) + iconWidth;

		GUI.BeginGroup (new Rect (x, y, nW, bgH));
		GUI.DrawTexture (new Rect (0, 0, bgW, bgH), texture);
		//GUI.contentColor = Color.black;
		GUI.EndGroup();

		GUI.Label(new Rect(x, y+bgH+10f, bgW, bgH), "Dogs Remaining: " + player.numDogsLeft);
	}
	
	// Update is called once per frame
	void Update () {
		if (!player) 
			{return;}
		if (time > 0) {
			time -= Time.deltaTime * timerRate;
		} 
		else {
			player.dead = true;
		}
	}
}
