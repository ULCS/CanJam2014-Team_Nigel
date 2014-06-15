using UnityEngine;
using System.Collections;

public class ArrowScript : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		rigidbody.AddForce(transform.forward * -20000);
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
}
