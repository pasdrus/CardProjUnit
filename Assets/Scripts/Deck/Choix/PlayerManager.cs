using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour {

    public Text myActionDeck;
    public Text myUtilDeck;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SavePlayerData()
    {
        PlayerPrefs.SetString("ActionDeck", myActionDeck.text);
        PlayerPrefs.SetString("UtilDeck", myUtilDeck.text);

        if (myActionDeck.text != "" && myActionDeck.text != "")
        {
            SceneManager.LoadScene(1);
        }
    }
}
