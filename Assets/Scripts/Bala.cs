using UnityEngine;
using System.Collections;

public class Bala : MonoBehaviour {

	public GameObject explosao;
	public GameObject explosaoSound;

	void Update ()
	{
		transform.Translate(0,2.5f,0);
		Destroy(gameObject,5);
	}
	void OnCollisionEnter(Collision c)
	{
		if(c.gameObject.tag == "ground")
		{
			Instantiate(explosao,transform.position,transform.rotation);
			Instantiate(explosaoSound,transform.position,transform.rotation);
			Destroy(gameObject);

			if(c.gameObject.tag== "nave")
			{
				Destroy(gameObject);
				Debug.Log("Acertou");
			}
		}
	}
}
