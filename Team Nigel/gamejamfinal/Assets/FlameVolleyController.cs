using UnityEngine;
using System.Collections;

public class FlameVolleyController : MonoBehaviour {

    Vector3 VolleyToGround;

    public GameObject FlameVolley;

    int Level = 1;

    int[] NoOfBalls = { 3, 5, 7, 10 };
    float[] AreaOfEffect = { 5, 6, 7, 10 };

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetButtonDown("B"))
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward + -transform.up, out hit))
            {
                VolleyToGround = hit.point;
                Fire();
            }
        }
	}

    // FIRE MAH LAZAR
    void Fire()
    {
        for (int i = 0; i < NoOfBalls[Level-1]; i++)
        {
            GameObject thisFireBall = (GameObject)GameObject.Instantiate(FlameVolley);

            Vector3 myTarget = new Vector3(VolleyToGround.x + Random.Range(-AreaOfEffect[Level-1],AreaOfEffect[Level-1]),
                                           VolleyToGround.y,
                                           VolleyToGround.z + Random.Range(-AreaOfEffect[Level-1],AreaOfEffect[Level-1]));

           
            thisFireBall.transform.position = transform.position;
            thisFireBall.transform.rotation = Quaternion.LookRotation(transform.position - myTarget);
        }
    }
}
