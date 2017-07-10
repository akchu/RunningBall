using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class DeathMenu : MonoBehaviour 
{
	public Text Text;

	// Use this for initialization
	void Start () 
	{
		gameObject.SetActive (false);
	}

	// Update is called once per frame
	void Update () 
	{

	}

	public void ToggleEndMenu(float Score)
	{
		gameObject.SetActive (true);
		Text.text = ((int)Score).ToString ();
	}

	public void Restart()
	{

		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);

	}

	public void ToMenu()
	{

		SceneManager.LoadScene ("Menu");
	}

}
