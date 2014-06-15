using UnityEngine;
using System.Collections;

public class Flash : MonoBehaviour {

    bool isFlashing = false;

    float FlashStart = 0;
    float FlashEnd = 0;
    float FlashMax = 3;
    float FlashSwitch = 0.25f;
    float LastFlash = 0;

    bool FlipFlop = true;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (isFlashing)
        {
            if (Time.time > LastFlash + FlashSwitch)
            {
                LastFlash = Time.time;

                if (FlipFlop)
                {
					renderer.material.color = new Color(1,0,0);
                    foreach (Renderer r in GetComponentsInChildren<Renderer>())
                    {
                        r.material.color = new Color(1, 0, 0);
                    }

                    FlipFlop = !FlipFlop;
                }
                else
                {
					renderer.material.color = new Color(1,1,1);

                    foreach (Renderer r in GetComponentsInChildren<Renderer>())
                    {
                        r.material.color = new Color(1, 1, 1);
                    }

                    FlipFlop = !FlipFlop;
                }
            }

            if (Time.time > FlashEnd)
            {
                isFlashing = false;

                foreach (Renderer r in GetComponentsInChildren<Renderer>())
                {
                    r.material.color = new Color(1, 1, 1);
                }
            }
        }
	}

   public void DoFlash()
    {
        if (isFlashing)
            return;

        isFlashing = true;
        FlashStart = Time.time;
        LastFlash = FlashStart;
        FlashEnd = FlashStart + FlashMax;
    }

	void OnParticleCollision(GameObject o)
	{
		DoFlash();
	}
}
