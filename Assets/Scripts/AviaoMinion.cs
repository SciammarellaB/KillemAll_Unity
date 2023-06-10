using UnityEngine;
using System.Collections;

public class AviaoMinion : MonoBehaviour {

	float explosionTime;
	public GameObject explosao;
	public GameObject explosaoSound;
	public GameObject pivot;
	public Rigidbody rB;
	bool isAlive;
	GameObject player;
	Arma armaScript;
	public float distanceFactor;

	void Start () 
	{
		player = GameObject.FindGameObjectWithTag("Player");
		armaScript = player.GetComponent<Arma>();
		isAlive = true;
		pivot = GameObject.FindGameObjectWithTag("pivot");
		gameObject.transform.LookAt(pivot.transform.position);
	}

	void Update () 
	{
		distanceFactor = Vector3.Distance(player.transform.position,gameObject.transform.position) / 100;

		if(Vector3.Distance(gameObject.transform.position,pivot.transform.position) > 200)
		{
			Destroy(gameObject);
			Debug.Log("EnemyClear");
		}

		if(isAlive == true)
		{
			gameObject.transform.Translate(-Vector3.back/4 * Time.timeScale);
			rB.useGravity = false;
		}

		if(isAlive == false)
		{
			gameObject.transform.Translate(-Vector3.back/3 * Time.timeScale);
			rB.useGravity = true;
		}
	}

	void OnCollisionEnter(Collision c)
	{
		if(c.gameObject.tag == "tiro")
		{
			Instantiate(explosao,transform.position,transform.rotation);
			Instantiate(explosaoSound,transform.position,transform.rotation);
			armaScript.pointsInt += 100 * distanceFactor;
			isAlive = false;
		}

		if(c.gameObject.tag == "ground")
		{
			Instantiate(explosao,transform.position,transform.rotation);
			Instantiate(explosaoSound,transform.position,transform.rotation);
			Destroy(gameObject);
		}
	}
}
