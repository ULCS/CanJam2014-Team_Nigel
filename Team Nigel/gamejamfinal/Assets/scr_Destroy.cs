using UnityEngine;
using System.Collections;

public class scr_Destroy : MonoBehaviour {
	int Timer;
	int Timer2;
	public GameObject Building_Base;

	GameObject MyBase;
	int GO;
	int once = 1;
	int i = 0;
	int ii = 0;
	// Use this for initialization
	void Start () {
		int Timer = 60;
		int GO = 0;
		Timer2 = 300;

	}
	
	// Update is called once per frame
	void Update () {
		if (Timer > -1){
			Timer--;
		}
		if (Timer < 0 && Timer > -2){
			GO = 1;
			}
		print(GO);

		Timer2--;
		if (Timer2 < 0){
			foreach(Rigidbody r in GetComponentsInChildren<Rigidbody>())
			{
				r.constraints = RigidbodyConstraints.None;
				
			}
			
			Instantiate(Building_Base, transform.position,transform.rotation);
			Timer2 = 50000;
		}
		}

	//void OnParticleCollision(Collision other){
		//if (GO == 1){
		//	foreach(Rigidbody r in GetComponentsInChildren<Rigidbody>())
		//	{
		//		r.constraints = RigidbodyConstraints.None;
		//		
			//}
			
			//Instantiate(Building_Base, transform.position,transform.rotation);
			//GO = -3;
			//Timer = -5;
		//}
	//}

   public void UnfreezeWall(){
		if (once ==1){

		foreach(Rigidbody r in GetComponentsInChildren<Rigidbody>())
		{
			r.constraints = RigidbodyConstraints.None;
			
		}
			once = 0;
		Instantiate(Building_Base, transform.position,transform.rotation);
		}
	}
	
void OnTriggerEnter(Collider other){
	if(other.collider.name == "Arrow(Clone)"){
		//GameObject myParent = transform.parent.gameObject;
		if (GO == 1){
			foreach(Rigidbody r in GetComponentsInChildren<Rigidbody>())
			{
				r.constraints = RigidbodyConstraints.None;
				
			}
			
			Instantiate(Building_Base, transform.position,transform.rotation);
			GO = -3;
			Timer = -5;
		}
	}
	
		if(other.collider.name == "BigArrow(Clone)"){
			//GameObject myParent = transform.parent.gameObject;
			if (GO == 1){
				foreach(Rigidbody r in GetComponentsInChildren<Rigidbody>())
				{
					r.constraints = RigidbodyConstraints.None;

				}
				Instantiate(Building_Base, transform.position,transform.rotation);
				GO = -3;
				Timer = -5;
			}
		}
}
}
