using UnityEngine;
using System.Collections;

public class scr_Stats : MonoBehaviour {
	public static int Gold = 100;
	GameObject Goldtext;
	// Use this for initialization
	void Start () 
	{
		Goldtext = GameObject.Find("GoldText");
	}
	
	// Update is called once per frame
	void Update () {
		Goldtext.GetComponent<TextMesh>().text = Gold.ToString();
	}
}
