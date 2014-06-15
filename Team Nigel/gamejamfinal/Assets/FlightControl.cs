using UnityEngine;
using System.Collections;

public class FlightControl : MonoBehaviour
{
    public GameObject RaggyDraggyPrefab;
    public GameObject RaggyDraggy, RaggyTummy;

	public int health = 100;

    Transform[] myTrans;
    Vector3[] myPos;
    Quaternion[] myRot;
    int inc = 0;

    Vector3 Rotation = Vector3.zero;

    bool DiveBombing = false;
    bool DivingBombingWas = false;

    // Use this for initialization
    void Start()
    {
        myTrans = RaggyDraggy.GetComponentsInChildren<Transform>();

        myPos = new Vector3[myTrans.Length];
        myRot = new Quaternion[myTrans.Length];

        for (int i = 0; i < myTrans.Length; i++)
        {
            myPos[i] = rigidbody.gameObject.transform.position;
            myRot[i] = rigidbody.gameObject.transform.rotation;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (DivingBombingWas != DiveBombing)
        {
            foreach (Rigidbody r in RaggyDraggy.GetComponentsInChildren<Rigidbody>())
            {
                r.isKinematic = false;
            }
        }
        //return;

        // MUTHA FUCKIN DIVE BOMB - BITCHES!
        if (Input.GetButtonDown("Y"))
        {
            audio.Play();

            transform.position += new Vector3(0, -1000, 0);

            RaggyDraggy.rigidbody.constraints = RigidbodyConstraints.None;
            RaggyTummy.rigidbody.constraints = RigidbodyConstraints.None;
            RaggyDraggy.rigidbody.useGravity = true;

            DiveBombing = true;            
        }
        DivingBombingWas = DiveBombing;
        if (Input.GetButton("Y") || health <= 0)
            RaggyDraggy.rigidbody.AddForce((Vector3.down) * 100.0f);
        if (Input.GetButtonUp("Y"))
        {
            transform.position = RaggyDraggy.transform.position;
            transform.rotation = Quaternion.identity;

            DiveBombing = false;
            RaggyDraggy.rigidbody.useGravity = false;

            //RaggyDraggy.transform.name = "DESTROY_ME";
            //RaggyDraggy = (GameObject)GameObject.Instantiate(RaggyDraggyPrefab, transform.position, Quaternion.identity);
            //RaggyDraggy.transform.name = "RaggyDraggy";
            inc = 0;
            for (int i = 0; i < myTrans.Length; i++)
            {
                //myTrans[i].position = myPos[i];
                //myTrans[i].rotation = myRot[i];
            }

            foreach (Transform t in RaggyDraggy.GetComponentsInChildren<Transform>())
            {
                if (t.name == "Tummy")
                    RaggyTummy = t.gameObject;
            }

            foreach (CharacterJoint c in RaggyDraggy.GetComponentsInChildren<CharacterJoint>())
            {
                SoftJointLimit myLim1 = c.swing1Limit;
                myLim1.limit = 0;
                c.swing1Limit = myLim1;

                SoftJointLimit myLim2 = c.swing1Limit;
                myLim2.limit = 0;
                c.swing2Limit = myLim2;
            }
            foreach (Rigidbody r in RaggyDraggy.GetComponentsInChildren<Rigidbody>())
            {
                r.isKinematic = true;
            }
            GameObject DELETE = GameObject.Find("DESTROY_ME");
            GameObject.Destroy(DELETE);

            RaggyDraggy.rigidbody.constraints = RigidbodyConstraints.FreezeAll;
            RaggyTummy.rigidbody.constraints = RigidbodyConstraints.FreezeAll;
            RaggyTummy.transform.rotation = Quaternion.identity;
        }

        //Up and Down
        if (Input.GetAxis("Vert") != 0)
        {
            transform.RotateAround(transform.right, Input.GetAxis("Vert") * Time.deltaTime);
        }
        //Left Right
        if (Input.GetAxis("Hori") != 0)
        {
            transform.RotateAround(Vector3.up, Input.GetAxis("Hori") * Time.deltaTime);
        }

        if (Input.GetAxis("Right Trigger") > 0)
        {
            //MOVE FORWARDS - YAH DARLING!
            transform.position -= transform.forward * 10.0f * Time.deltaTime;
        }
        else if (Input.GetAxis("Right Trigger") < 0)
        {
            //MOVE BACKWARDS - YAH DARLING!
            transform.position += transform.forward * 10.0f * Time.deltaTime;
        }

        if (!DiveBombing)
        {
            RaggyDraggy.transform.position = transform.position + (transform.up * 4);
            RaggyDraggy.transform.rotation = transform.rotation;
        }
    }

	void OnCollisionEnter(Collision other)
	{
		if (other.transform.name == "BigArrow(Clone)" || other.transform.name == "Boulder")
			health -= 15;
		if (other.transform.name == "BigArrow(Clone)")
			health -= 5;
	}
}
