using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public GameObject continueButton;
	public GameObject exitButton;
	bool gamePaused;

	void Start () 
	{
		gamePaused = false;
		Time.timeScale = 1;
		continueButton.SetActive(false);
		exitButton.SetActive(false);
	}
	

	void Update () 
	{
		if(Input.GetKey(KeyCode.Escape))
		{
			gamePaused = true;
		}
		if(gamePaused == true)
		{
			Time.timeScale = 0;
			continueButton.SetActive(true);
			exitButton.SetActive(true);

		}
	}

	public void continueGame(string cont)
	{
		gamePaused = false;
		Time.timeScale = 1;
		continueButton.SetActive(false);
		exitButton.SetActive(false);
	}
	public void exitGame(string exit)
	{
		Application.LoadLevel("Menu");
	}
}
