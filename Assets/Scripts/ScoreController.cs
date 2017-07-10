using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ScoreController : MonoBehaviour 
{
	private float Score = 0.0f;
	private int MinDifficultyLevel = 1;
	private int MaxDifficultyLevel = 10;
	private int ScoreToNexeLevel = 10;
	private bool isDead = false;


	public Text ScoreText;
	public DeathMenu deathMenu;

	// Use this for initialization
	void Start () 
	{
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (isDead)
			return;
		
		if (Score >= ScoreToNexeLevel) 
			LevelUp ();
		
		Score += Time.deltaTime * MinDifficultyLevel;
		ScoreText.text = ((int)Score).ToString ();	
	}

	void LevelUp()
	{
		if (MinDifficultyLevel == MaxDifficultyLevel)
			return;
		
		ScoreToNexeLevel *= 2;
		MinDifficultyLevel++;

		GetComponent<PlayerMovement>().SetSpeed (MinDifficultyLevel);

	}

	public void OnDeath()
	{
		isDead = true;
		PlayerPrefs.SetFloat ("High Score", Score);
		deathMenu.ToggleEndMenu (Score); 
	}
}
