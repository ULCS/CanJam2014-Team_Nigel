using UnityEngine;
using System.Collections;

public class ButtonGUI : MonoBehaviour {

    public Texture Buttons, FlameJet, Smashing;

    Vector2 ButtonPos;

	// Use this for initialization
    void Start()
    {
        ButtonPos = new Vector2(Screen.width - (Buttons.width + FlameJet.width),
                                Screen.height - (Buttons.height + FlameJet.height));
    }

	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI()
    {
        // Draw the Buttons
        GUI.DrawTexture(new Rect(ButtonPos.x,
                        ButtonPos.y,
                        Buttons.width,
                        Buttons.height),
                        Buttons);

        // Now Draw the Abilities + Cooldowns

        // X - (West)
        GUI.DrawTexture(new Rect(ButtonPos.x - FlameJet.width,
                        ButtonPos.y + (FlameJet.height/2),
                        FlameJet.width,
                        FlameJet.height),
                        FlameJet);
        // Y - North
        GUI.DrawTexture(new Rect(ButtonPos.x + (Smashing.width/2),
                        ButtonPos.y - Smashing.height,
                        Smashing.width,
                        Smashing.height),
                        Smashing);
    }
}
