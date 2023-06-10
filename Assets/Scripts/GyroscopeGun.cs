using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GyroscopeGun : MonoBehaviour {

	public float X;
	public float Y;
	public float Z;
	public float X2;
	public float Y2;
	public float Z2;
	public Text points;
	public int pointsInt;
	GameObject cover;
	GameObject gunsObj;
	GameObject tiro1;
	GameObject tiro2;
	public GameObject tiro;
	float count;
	AudioSource aSource;
	public Text ammo;
	int ammoInt;
	float reloadCooldown;
	bool noAmmo;

	void Start ()
	{
		Input.gyro.enabled = true;
		cover = GameObject.FindWithTag("cover");
		gunsObj = GameObject.FindWithTag("guns");
		tiro1 = GameObject.FindWithTag("1");
		tiro2 = GameObject.FindWithTag("2");
		aSource = gameObject.GetComponent<AudioSource>();
		ammoInt = 20;
	}
	

	void Update ()
	{
		GetGyro();
		Movement();
		Ammo();
		Reload();
	}

	void GetGyro()
	{

		X = Input.gyro.rotationRateUnbiased.x;
		Y = Input.gyro.rotationRateUnbiased.y;
		Z = Input.gyro.rotationRateUnbiased.z;
		//X = Mathf.Round(X);
		//Y = Mathf.Round(Y);
		//Z = Mathf.Round(Z);
	}

	void Movement()
	{
		cover.transform.Rotate(0,0,-Y * Time.timeScale);
		gunsObj.transform.Rotate(X * Time.timeScale,0,0);
	}

	public void Fire(string fire)
	{
		if(ammoInt > 0 && Time.timeScale > 0)
		{
			Instantiate(tiro,tiro1.transform.position,tiro1.transform.rotation);
			Instantiate(tiro,tiro2.transform.position,tiro2.transform.rotation);
			aSource.Play();
			ammoInt -= 2;
		}
	}

	void Reload()
	{
		if(ammoInt == 0)
		{
			noAmmo = true;
		}

		if(noAmmo == true)
		{
			reloadCooldown += Time.deltaTime;
		}

		if(reloadCooldown > 5)
		{
			ammoInt = 20;
			noAmmo = false;
			reloadCooldown = 0;
		}
	}

	void Ammo()
	{
		ammo.text = ammoInt.ToString() + "/20";

		if(ammoInt <= 4)
		{
			ammo.color = Color.red;
		}

		else
		{
			ammo.color = Color.white;
		}
	}
}
