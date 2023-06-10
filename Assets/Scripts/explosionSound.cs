using UnityEngine;
using System.Collections;

public class explosionSound : MonoBehaviour {


	void Start () 
	{
	
	}
	

	void Update ()
	{
		Destroy(gameObject,5);
	}
}
