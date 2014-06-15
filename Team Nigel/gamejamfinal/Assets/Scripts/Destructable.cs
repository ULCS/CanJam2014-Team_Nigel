using UnityEngine;
using System.Collections;

public class Destructable : MonoBehaviour {
	public GameObject Wall_Broken;
	public float HouseHealth;
	int Once = 1;
	GameObject myBroken;
	bool BrokenIsSet = false;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnParticleCollision(GameObject other){
		
		Debug.Log("MAMAMAMAM");
		HouseHealth -=10;
		gameObject.GetComponent<Flash>().DoFlash();
		if (HouseHealth <= 0){
			//Destroy(other.collider.gameObject);
			Vector3 SpawnPos = transform.position;
			SpawnPos.y -= 1.4f;
			Destroy(GetComponent<BoxCollider>());
			Destroy(GetComponent<CapsuleCollider>());
			Destroy(gameObject);
			Instantiate(Wall_Broken, SpawnPos,transform.rotation);

			
		}
	}
	
	void OnParticleCollision(Collision other){
		
		Debug.Log("LOLOLOLOL");
		HouseHealth -=10;
		gameObject.GetComponent<Flash>().DoFlash();
		if (HouseHealth <= 0){
			//Destroy(other.collider.gameObject);
			Vector3 SpawnPos = transform.position;
			SpawnPos.y -= 1.4f;
			Destroy(GetComponent<BoxCollider>());
			Destroy(GetComponent<CapsuleCollider>());
			Destroy(gameObject);
			Instantiate(Wall_Broken, SpawnPos,transform.rotation);

			
		}
	}
	
	

	void OnCollisionEnter(Collision other){
		if(other.collider.name == "Arrow(Clone)"){

			HouseHealth -=10;
			if (HouseHealth <= 0){
				Destroy(other.collider.gameObject);
			Vector3 SpawnPos = transform.position;
			SpawnPos.y -= 1.4f;
				Destroy(GetComponent<BoxCollider>());
				Destroy(GetComponent<CapsuleCollider>());
			Destroy(gameObject);
			Instantiate(Wall_Broken, SpawnPos,transform.rotation);
			
			}



		}
		if(other.collider.name == "BigArrow(Clone)"){
		
			HouseHealth -=100;
			if (HouseHealth <= 0){
				Destroy(other.collider.gameObject);
				Vector3 SpawnPos = transform.position;
				SpawnPos.y -= 1.4f;
				Destroy(GetComponent<BoxCollider>());
				Destroy(GetComponent<CapsuleCollider>());
				Destroy(gameObject);
				Instantiate(Wall_Broken, SpawnPos,transform.rotation);}
			
			
			
		}

	}
}
