using UnityEngine;
using System.Collections;

public class scr_Spawn_Workers : MonoBehaviour {
	public GameObject Worker;
	int Timer;

	// Use this for initialization
	void Start () {
		Timer = 0;
	}
	
	// Update is called once per frame
	void Update () {
		Timer--;
	if (Timer < 0){
			Timer = 100;
			Instantiate(Worker);
		}
	}
}
