using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class Arma : MonoBehaviour {


	//  A arma está funcionando direito, não precisa gastar tempo alterando qualquer coisa dela




	public Text points;
	public Text recarregar;
	public Text recarregando;
	public float pointsInt;
	GameObject cover;
	GameObject gunsObj;
	GameObject tiro1;
	GameObject tiro2;
	public GameObject tiro;
	float count;
	public AudioSource aSource;
	public AudioSource aSource2;
	public Text ammo;
	int ammoInt;
	float reloadCooldown;
	bool noAmmo;
	bool reloading;
	public GameObject canonMesh;

	public int Shoot
	{
		get { return canonMesh.GetComponent<Animator> ().GetInteger("Tiro");}
		set { canonMesh.GetComponent<Animator> ().SetInteger("Tiro",value);}
	}

	void Start ()
	{
		cover = GameObject.FindWithTag("cover");
		gunsObj = GameObject.FindWithTag("guns");
		tiro1 = GameObject.FindWithTag("1");
		tiro2 = GameObject.FindWithTag("2");
		ammoInt = 20;
		noAmmo = false;
		reloading = false;
		recarregando.gameObject.SetActive(false);
		recarregar.gameObject.SetActive(false);
	}
	

	void Update ()
	{
		pointsInt = Mathf.Round(pointsInt);
		points.text = pointsInt.ToString();
		Movement2();
		Ammo();
	}


//	void Movement()
//	{
//
//		Debug.Log(gunsObj.transform.localRotation.x);
//
//		if(Input.GetKey(KeyCode.LeftArrow))
//		{
//			cover.transform.Rotate(0,0,-0.8f* Time.timeScale);
//		}
//
//		if(Input.GetKey(KeyCode.RightArrow))
//		{
//			cover.transform.Rotate(0,0,0.8f* Time.timeScale);
//		}
//		if(Input.GetKey(KeyCode.UpArrow))
//		{	
//			if(gunsObj.transform.localRotation.x < 0.95f)
//			{
//				gunsObj.transform.Rotate(1* Time.timeScale,0,0);
//			}
//		}
//		if(Input.GetKey(KeyCode.DownArrow))
//		{
//			if(gunsObj.transform.localRotation.x > 0.6f)
//			{
//				gunsObj.transform.Rotate(-1* Time.timeScale,0,0);
//			}
//		}
//	}

	void Movement2()
	{

		Debug.Log(gunsObj.transform.localRotation.x);

		cover.transform.Rotate(0,0, CrossPlatformInputManager.GetAxis("Horizontal") * Time.timeScale);
		
		if(CrossPlatformInputManager.GetAxis("Vertical") > 0 && gunsObj.transform.localRotation.x < 0.95f)
			{
				gunsObj.transform.Rotate(CrossPlatformInputManager.GetAxis("Vertical") * Time.timeScale,0,0);
			}

		if(CrossPlatformInputManager.GetAxis("Vertical") < 0 && gunsObj.transform.localRotation.x > 0.6f)
			{
				gunsObj.transform.Rotate(CrossPlatformInputManager.GetAxis("Vertical") * Time.timeScale,0,0);
			}
		
	}

	void Ammo()
	{
		ammo.text = ammoInt.ToString() + "/20";


		if(CrossPlatformInputManager.GetButtonDown("Jump") && ammoInt > 0 && Time.timeScale > 0 && reloading == false)
		{
			Instantiate(tiro,tiro1.transform.position,tiro1.transform.rotation);
			Instantiate(tiro,tiro2.transform.position,tiro2.transform.rotation);
			aSource.Play();
			ammoInt -= 2;
			Shoot = 1;
		}

		else 
		{
			Shoot = 0;
		}


		if(ammoInt == 0 || Input.GetKeyDown(KeyCode.R))
		{
			noAmmo = true;
			reloading = true;
			recarregando.gameObject.SetActive(true);
			Debug.Log("Reloading");
			if(aSource2.isPlaying == false)
			{
				aSource2.Play();
			}

				
		}

		if(noAmmo == true)
		{
			reloadCooldown += Time.deltaTime;
		}

		if(reloadCooldown > 5)
		{
			ammoInt = 20;
			noAmmo = false;
			reloading = false;
			reloadCooldown = 0;
			recarregando.gameObject.SetActive(false);
			ammo.color = Color.white;
			aSource2.Stop();
		}

		if(ammoInt <= 4 && reloading == false)
		{
			ammo.color = Color.red;

			if(reloading == false)
			{
				recarregar.gameObject.SetActive(true);
			}
		}

		else
		{
			recarregar.gameObject.SetActive(false);
		}


	}
}
