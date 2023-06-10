using UnityEngine;
using System.Collections;

public class EnemySpanwner2 : MonoBehaviour {

	public GameObject pivot;
	public GameObject spanwner1;
	public GameObject spanwner2;
	public GameObject[] naves;

	public float timeN;
	public float timeM;


	void Start () 
	{
		
	}
	

	void Update () 
	{
		Pivot();
		SpawnNorms();
		SpawnMin();
	}

	void Pivot()
	{
		pivot.transform.Rotate(Vector3.up);
	}

	void SpawnNorms()
	{
		timeN += Time.deltaTime;

		if(timeN > Random.Range(3,15))
		{
			GameObject.Instantiate(naves[0],spanwner1.transform.position,Quaternion.identity);
			timeN = 0;
		}
	}

	void SpawnMin()
	{
		timeM += Time.deltaTime;

		if(timeM > Random.Range(10,25))
		{
			GameObject.Instantiate(naves[1],spanwner2.transform.position,Quaternion.identity);
			timeM = 0;
		}
	}
}
