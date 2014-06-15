using UnityEngine;
using System.Collections;

public class BigArrowScript : MonoBehaviour 
{	
	// Use this for initialization
	void Start () 
	{
		rigidbody.AddForce(transform.forward * -400000);
	}
}