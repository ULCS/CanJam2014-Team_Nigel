using UnityEngine;
using System.Collections;

public class PhysicsFlight : MonoBehaviour {

    public GameObject RaggyDraggy;

    Transform leftwingpos;
    Transform rightwingpos;

    Rigidbody LeftWing_RB, RightWing_RB;

    float strength = (55/5) * 2;

	// Use this for initialization
	void Start () {
        foreach (Transform t in GetComponentsInChildren<Transform>())
        {
            if (t.name == "L_Wing")
            {
                leftwingpos = t;
            }

            if (t.name == "R_Wing")
            {
                rightwingpos = t;
            }
        }

        foreach (Transform t in RaggyDraggy.GetComponentsInChildren<Transform>())
        {
            if (t.name == "L_Wing_Mid")
                LeftWing_RB = t.rigidbody;

            if (t.name == "L_Wing_Mid_001")
                RightWing_RB = t.rigidbody;
        }
	}
	
	// Update is called once per frame
	void Update () {

        //Vector3 L_Force = Vector3.zero;
        //if (Input.GetAxis("L_Wing") != 0)
        //    L_Force = ((transform.up +transform.forward) * strength) * Input.GetAxis("L_Wing");

        //Vector3 R_Force = Vector3.zero;
        //if (Input.GetAxis("R_Wing") != 0)
        //    R_Force = ((transform.up + transform.forward) * strength) * Input.GetAxis("R_Wing");

        //rigidbody.AddForceAtPosition(L_Force, leftwingpos.position, ForceMode.Force);
        //LeftWing_RB.AddForceAtPosition(L_Force*5, leftwingpos.position, ForceMode.Force);
        //rigidbody.AddForceAtPosition(R_Force, rightwingpos.position, ForceMode.Force);
        //RightWing_RB.AddForceAtPosition(R_Force*5, rightwingpos.position, ForceMode.Force);
        ////rigidbody.AddForce((transform.forward) * strength * 3);

        ////Debug.Log(L_Force + " " + R_Force);
        //Debug.Log(L_Force + " " + R_Force);

        
	}
}
