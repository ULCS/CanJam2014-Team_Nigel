using UnityEngine;
using System.Collections;

public class P3Script : MonoBehaviour 
{
	public int health = 100;
	
	public float speed = 10.0F;
	public float rotationSpeed = 100.0F;
	
	float WeaponDelay;
	float ReloadTime = 1.5f;
	
	public GameObject ArrowFab;
	public GameObject BigArrowFab;


	GameObject P3Camera;
	GameObject P3Aimer;
	
	bool inBallista;
	GameObject targetBallista;
	
	Quaternion CamOriginRot;
	Vector3 CamOriginPos;
	
	// Use this for initialization
	void Start() 
	{
		P3Camera = GameObject.Find("P3Camera");
		P3Aimer = GameObject.Find("P3Aim");
		inBallista = false;
		targetBallista = null;
	}
	
	// Update is called once per frame
	void Update () 
	{
		Debug.Log(health);
		//if (health <= 0)
		//	return;

		if(WeaponDelay > 0.0f)
		{
			WeaponDelay -= ReloadTime;
		}
		
		if(inBallista == false)
		{
			
			float translation = Input.GetAxis("P3Vertical") * speed;
			float rotation = Input.GetAxis("P3Horizontal") * rotationSpeed;
			float strafeTranslation = Input.GetAxis ("P3Strafe") * speed * -1;
			float vertRotation = Input.GetAxis ("P3VerticalLook") * rotationSpeed;
			translation *= Time.deltaTime;
			strafeTranslation *= Time.deltaTime;
			rotation *= Time.deltaTime;
			vertRotation *= Time.deltaTime;
			transform.Translate(0, 0, translation);
			transform.Translate(strafeTranslation, 0, 0);
			transform.Rotate(0, rotation, 0);
			P3Camera.transform.RotateAround(transform.position, P3Camera.transform.right, vertRotation);
			if(rotation == 0)
			{
				rigidbody.angularVelocity = new Vector3(0.0f, 0.0f, 0.0f);
			}
			
			if(Input.GetButtonDown("P3Repair"))
			{
				RaycastHit hit;
				Vector3 fwd = transform.TransformDirection(Vector3.back);
				if (Physics.Raycast(transform.position, fwd, out hit, 10.0F))
				{
					Debug.Log ("HIT SOMETHING");
					if(hit.transform.tag == "TownObject")
					{
						int newRand = Random.Range (15, 100);
						hit.transform.GetComponent<House1Script>().ChangeHealth(newRand);
						Debug.Log ("REPAIRING");
					}
					
					if(hit.transform.tag == "Ballista")
					{
						targetBallista = hit.transform.gameObject;
						inBallista = true;
						CamOriginPos = P3Camera.transform.position;
						CamOriginRot = P3Camera.transform.rotation;
						P3Camera.transform.position = hit.transform.FindChild("BallistaCam").transform.position;
						P3Camera.transform.rotation = hit.transform.FindChild("BallistaCam").transform.rotation;
						P3Camera.transform.Rotate (Vector3.up, 180);
						P3Camera.transform.parent = hit.transform;
						Debug.Log ("MOUNTING");
					}
					
				}
			}
			
			if(Input.GetAxis("P3Shoot") < -0.8f)
			{
				if(WeaponDelay <= 0.0f)
				{
					GameObject newArrow = Instantiate(ArrowFab, transform.Find("P3Nozzle").position, Quaternion.identity) as GameObject;
					newArrow.transform.LookAt(P3Aimer.transform.position);
					newArrow.transform.Rotate (Vector3.right, 180.0f);
					WeaponDelay = 60.0f;
				}
			}
		}
		else
		{
			float rotation = Input.GetAxis("P3Horizontal") * rotationSpeed;
			float vertRotation = Input.GetAxis ("P3VerticalLook") * rotationSpeed;
			rotation *= Time.deltaTime;
			vertRotation *= Time.deltaTime;
			
			targetBallista.transform.parent.Rotate(targetBallista.transform.parent.up, rotation);
			targetBallista.transform.Rotate(vertRotation, 0.0f, 0.0f);
			//P3Camera.transform.RotateAround(transform.position, P3Camera.transform.right, vertRotation);
			
			
			if(Input.GetButtonDown("P3Repair"))
			{
				inBallista = false;
				P3Camera.transform.position = CamOriginPos;
				P3Camera.transform.rotation = CamOriginRot;
				P3Camera.transform.parent = transform;
				targetBallista = null;
			}
		}
		
	}

	void OnCollisionEnter(Collision other)
	{
		if (other.transform.name == "Boulder")
			health -= 15;
		
		if (other.transform.name == "Dragon" || other.transform.name == "Dragon rg")
			health -= 33;
	}
	
	void OnParticleCollision(GameObject other)
	{
		health -= 1;
	}
}