using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameLevel : MonoBehaviour {

    public string lvlName;
    public Image lvlImg;
    public Text nameText;
	// Use this for initialization
	void Start () {
        nameText.text = lvlName;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
