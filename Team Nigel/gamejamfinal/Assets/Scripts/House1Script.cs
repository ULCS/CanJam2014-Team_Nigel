using UnityEngine;
using System.Collections;

public class House1Script : MonoBehaviour {

	int HouseHealth;
	int Destroyed = 1;
	public GameObject Building ;
	GameObject myBuilding;
	

	// Use this for initialization
	void Start () 
	{
		HouseHealth = 0;
	}
	
	// Update is called once per frame
	void Update () 
	{	


		if (HouseHealth >= 1000){
				Instantiate(Building, transform.position ,transform.rotation);

			Destroy (gameObject);

		}
	}

	public int GetHealth()
	{
		return HouseHealth;
	}

	public void ChangeHealth(int HMod)
	{
		HouseHealth += HMod;
		Debug.Log (HouseHealth);
	}

}
