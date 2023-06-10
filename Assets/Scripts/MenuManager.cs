using UnityEngine;
using System.Collections;

public class MenuManager : MonoBehaviour {

	public void StartGame(string start)
	{
		Application.LoadLevel("Arma");
	}

	public void ExitGame(string exit)
	{
		Application.Quit();
	}
}
