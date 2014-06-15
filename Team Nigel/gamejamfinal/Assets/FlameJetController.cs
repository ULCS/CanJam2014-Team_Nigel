using UnityEngine;
using System.Collections;

public class FlameJetController : MonoBehaviour {

	// Use this for initialization
	void Start () {
        foreach (ParticleSystem p in GetComponentsInChildren<ParticleSystem>())
        {
            p.enableEmission = false;
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("X"))
        {
            foreach (ParticleSystem p in GetComponentsInChildren<ParticleSystem>())
            {
                p.enableEmission = true;
            }
        }
        if (Input.GetButtonUp("X"))
        {
            foreach (ParticleSystem p in GetComponentsInChildren<ParticleSystem>())
            {
                p.enableEmission = false;
            }
        }
	}
}
