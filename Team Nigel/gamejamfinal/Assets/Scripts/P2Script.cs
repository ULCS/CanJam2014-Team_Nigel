using UnityEngine;
using System.Collections;

public class P2Script : MonoBehaviour 
{
	public int health = 100;

	public float speed = 10.0F;
	public float rotationSpeed = 100.0F;

	float WeaponDelay;
	float ReloadTime = 0.5f;

	public GameObject ArrowFab;
	public GameObject BigArrowFab;

	GameObject P2Camera;
	GameObject P2Aimer;

	bool inBallista;
	GameObject targetBallista;
	
	Quaternion CamOriginRot;
	Vector3 CamOriginPos;

	// Use this for initialization
	void Start() 
	{
		P2Camera = GameObject.Find("P2Camera");
		P2Aimer = GameObject.Find("P2Aim");
		inBallista = false;
		targetBallista = null;
	}
	
	// Update is called once per frame
	void Update () 
	{
		//if (health <= 0)
		//	return;

		if(WeaponDelay > 0.0f)
		{
			WeaponDelay -= ReloadTime;
		}

		if(inBallista == false)
		{

		float translation = Input.GetAxis("P2Vertical") * speed;
		float rotation = Input.GetAxis("P2Horizontal") * rotationSpeed;
		float strafeTranslation = Input.GetAxis ("P2Strafe") * speed * -1;
		float vertRotation = Input.GetAxis ("P2VerticalLook") * rotationSpeed;
		translation *= Time.deltaTime;
		strafeTranslation *= Time.deltaTime;
		rotation *= Time.deltaTime;
		vertRotation *= Time.deltaTime;
		transform.Translate(0, 0, translation);
		transform.Translate(strafeTranslation, 0, 0);
		transform.Rotate(0, rotation, 0);
		P2Camera.transform.RotateAround(transform.position, P2Camera.transform.right, vertRotation);
		if (rotation == 0){
			rigidbody.angularVelocity = new Vector3(0.0f,0.0f,0.0f);
		}

		if(Input.GetButtonDown("P2Repair"))
		{
				RaycastHit hit;
				Vector3 fwd = transform.TransformDirection(Vector3.back);
				if (Physics.Raycast(transform.position, fwd, out hit, 15.0F))
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
						CamOriginPos = P2Camera.transform.position;
						CamOriginRot = P2Camera.transform.rotation;
						P2Camera.transform.position = hit.transform.FindChild("BallistaCam").transform.position;
						P2Camera.transform.rotation = hit.transform.FindChild("BallistaCam").transform.rotation;
						P2Camera.transform.Rotate (Vector3.up, 180);
						P2Camera.transform.parent = hit.transform;
						Debug.Log ("MOUNTING");
					}
					
				}
		}

			if(Input.GetAxis("P2Shoot") < -0.8f)
			{
				if(WeaponDelay <= 0.0f)
				{
					GameObject newArrow = Instantiate(ArrowFab, transform.Find("P2Nozzle").position, Quaternion.identity) as GameObject;
					newArrow.transform.LookAt(P2Aimer.transform.position);
					newArrow.transform.Rotate (Vector3.right, 180.0f);
					WeaponDelay = 60.0f;
				}
			}
		}
		else
		{
			float rotation = Input.GetAxis("P2Horizontal") * rotationSpeed;
			float vertRotation = Input.GetAxis ("P2VerticalLook") * rotationSpeed;
			rotation *= Time.deltaTime;
			vertRotation *= Time.deltaTime;
			
			targetBallista.transform.parent.Rotate(targetBallista.transform.parent.up, rotation);
			targetBallista.transform.Rotate(vertRotation, 0.0f, 0.0f);
			//P3Camera.transform.RotateAround(transform.position, P3Camera.transform.right, vertRotation);
			
			
			if(Input.GetButtonDown("P2Repair"))
			{
				inBallista = false;
				P2Camera.transform.position = CamOriginPos;
				P2Camera.transform.rotation = CamOriginRot;
				P2Camera.transform.parent = transform;
				targetBallista = null;
			}

			if(Input.GetAxis("P2Shoot") < -0.8f)
			{
				if(WeaponDelay <= 0.0f)
				{
					GameObject newArrow = Instantiate(BigArrowFab, targetBallista.transform.FindChild ("BallistaNozzle").transform.position, targetBallista.transform.FindChild ("BallistaNozzle").transform.rotation) as GameObject;
					newArrow.transform.LookAt(P2Aimer.transform.position);
					newArrow.transform.Rotate (Vector3.right, 190.0f);
					WeaponDelay = 120.0f;
				}
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