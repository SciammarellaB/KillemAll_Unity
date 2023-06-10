using UnityEngine;
using System.Collections;

public class Avioes : MonoBehaviour {

	public GameObject explosao;
	public GameObject explosaoSound;
	public GameObject pivot;
	GameObject player;
	public float distanceFactor;
	Arma armaScript;

	void Start ()
	{
		player = GameObject.FindGameObjectWithTag("Player");
		armaScript = player.GetComponent<Arma>();
		pivot = GameObject.FindGameObjectWithTag("pivot");
		gameObject.transform.LookAt(pivot.transform.position);

	}
	

	void Update ()
	{
		transform.Translate(-Vector3.back/3 * Time.timeScale);

		distanceFactor = Vector3.Distance(player.transform.position,gameObject.transform.position) / 100;

		if(Vector3.Distance(gameObject.transform.position,pivot.transform.position) > 200)
		{
			Destroy(gameObject);
			Debug.Log("EnemyClear");
		}
	}

	void OnCollisionEnter(Collision c)
	{
		if(c.gameObject.tag == "tiro")
		{
			Instantiate(explosao,transform.position,transform.rotation);
			Instantiate(explosaoSound,transform.position,transform.rotation);
			Destroy(gameObject);
			armaScript.pointsInt += 100 * distanceFactor;
		}
	}
}
