//using UnityEngine;
//using System.Collections;
//
//public class characterMovement : MonoBehaviour {
//
//    float speed;
//	float jumpForce;
//	public GameObject magic;
//	public EnemyProg eProg;
//	int minionAttack;
//	int bossAttack;
//	public int characterLife;
//	public int characterMana;
//	public int manaUsage;
//	float manaRecoverTime;
//	bool characterIsAlive;
//	public FallDeath fDeath;
//	public BossScript bProg;
//	bool isMoving;
//	    
//
//	public int Run
//	{
//		get { return GetComponent<Animator> ().GetInteger("Run");}
//		set { GetComponent<Animator> ().SetInteger("RunPar",value);}
//	}
//
//	public int Attack
//	{
//		get { return GetComponent<Animator> ().GetInteger("Attack");}
//		set { GetComponent<Animator> ().SetInteger("AttackPar",value);}
//	}
//
//	public int Jump
//	{
//		get { return GetComponent<Animator> ().GetInteger("Jump");}
//		set { GetComponent<Animator> ().SetInteger("JumpPar",value);}
//	}
//	 
//
//
//	void Start () 
//	{
//		speed = 0.1f;
//		jumpForce = 500;
//		minionAttack = 10;
//		bossAttack = 20;
//		characterLife = 100;
//		characterMana = 100;
//		manaUsage = 20;
//	}
//	
//
//	void Update () 
//
//	{
//
//
//		if(transform.position.y < 0)
//		{
//			gameObject.collider.isTrigger = true;
//		}
//
//		if(fDeath.deathFalling == true)
//		{
//			characterLife = 0;
//		}
//
//		if(characterLife > 0)
//		{
//			characterIsAlive = true;
//		}
//
//		if(characterLife <= 0)
//		{
//			Application.LoadLevel("Menu");
//		}
//
//		if(characterIsAlive == true)
//		{
//			ManaRecover();
//
//		if(characterMana > 100)
//		{
//			characterMana = 100;
//		}
//
//		magic.transform.position = transform.position;
//		magic.transform.localEulerAngles = transform.localEulerAngles;
//
//			if(Input.GetKeyDown(KeyCode.Z) && characterMana >= manaUsage && isMoving == false)
//		{
//			Attack = 1;
//			Instantiate(magic);
//			characterMana -= manaUsage;
//
//
//		}
//		else
//		{
//			Attack = 0;
//		}
//
//		if (Input.GetKey(KeyCode.RightArrow)) 
//		{
//			transform.eulerAngles = new Vector2 (0,0);
//			transform.Translate(speed, 0, 0);
//			Run = 1;
//				isMoving = true;
//		}
//
//		else if (Input.GetKey(KeyCode.LeftArrow)) 
//		{
//			transform.eulerAngles = new Vector2 (0,180);
//            transform.Translate(speed, 0, 0);
//			Run = 1;
//				isMoving = true;
//		}
//		else
//		{
//			Run = 0;
//				isMoving = false;
//		}
//
//		if(Input.GetKeyDown(KeyCode.Space))
//		{
//			rigidbody.AddForce(0,jumpForce,0);
//			Jump = 1;
//		}
//
//		else
//		{
//			Jump = 0;
//		}
//
//		if(eProg.attacking == true)
//		{
//			characterLife -= minionAttack;
//		}
//
//			if (bProg.bossAttacking == true)
//			{
//				characterLife -= bossAttack;
//			}
//
//
//		Debug.Log(characterLife);
//		}
//	}
//
//	private void ManaRecover()
//	{
//		manaRecoverTime += 1 * Time.deltaTime;
//
//		if(manaRecoverTime > 5 && characterMana < 100)
//		{
//			manaRecoverTime = 0;
//			characterMana += 5;
//		}
//	}
//}
