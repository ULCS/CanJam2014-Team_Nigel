using UnityEngine;
using System.Collections;

public class scr_Debris_CleanUp : MonoBehaviour {
	int Timer = 800;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Timer--;
		if (Timer <= 0){
			Destroy (gameObject);

		}
	}

//	void OnParticleCollision(Collision other)
//	{
//		rigidbody.AddForce(new Vector3(10.0f, 10.0f, 10.0f));
//	}
}
