using UnityEngine;
using System.Collections;

public class FireBall : MonoBehaviour {

    public Vector3 Direction = Vector3.zero;
    float speed = 20.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += -transform.forward * speed * Time.deltaTime;
	}
}
