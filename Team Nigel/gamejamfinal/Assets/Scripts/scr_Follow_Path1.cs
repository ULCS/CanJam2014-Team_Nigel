using UnityEngine;
using System.Collections;

public class scr_Follow_Path1 : MonoBehaviour {
	int speed = 5;
	int rand;
	int full;
	GameObject Node;
	Vector3 NodePos;
	int Timer = 30;
	// Use this for initialization
	void Start () {
		Node = GameObject.Find("Node1");
		rand = Random.Range (0,2);
	}
	
	// Update is called once per frame
	void Update () {
		NodePos = Node.transform.position;
		transform.LookAt(NodePos);
		transform.position += transform.forward * speed * Time.deltaTime;

			
	}
	void OnParticleCollision(GameObject other){
		
		Debug.Log("WALLL");
	}


void OnTriggerEnter(Collider other){
	if (other.collider.name == "Node_Home"){ 
			if (full ==1){
				Node = GameObject.Find("Node1");
				full = 0;
				scr_Stats.Gold +=100;
			}
			else{
				Node = GameObject.Find("Node1");
			}
			
		}

	if (other.collider.name == "Node1"){ 
			if (full ==1){
				Node = GameObject.Find("Node_Home");
			}
			else{
			Node = GameObject.Find("Node2");
			}

		}
	if (other.collider.name == "Node2") {
			if (full ==1){
				Node = GameObject.Find("Node1");
			}
			else{
			if (rand ==0)
				Node = GameObject.Find("Node3");
			if (rand ==1)
				Node = GameObject.Find("Node5");
			}
		}
	
	
	if (other.collider.name == "Node3") {
		if (full == 1){
			Node = GameObject.Find("Node2");
		}
		else{
				Node = GameObject.Find("Node4");
			}
	}
	if (other.collider.name == "Node4") {
			full = 1;
				Node = GameObject.Find("Node3");
			}
	

	if (other.collider.name == "Node5") {
		if (full == 1){
			Node = GameObject.Find("Node2");
		}
		else
		{
			Node = GameObject.Find("Node6");
		}
	}
	if (other.collider.name == "Node6") {
		full = 1;
		Node = GameObject.Find("Node5");
	}

}
}
