using UnityEngine;
using System.Collections;

public class OpenSesame : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
void OnCollisionEnter(Collision other){
		if(other.transform.name != "Boulder"){
			rigidbody.isKinematic = false;
		}

	}

}

