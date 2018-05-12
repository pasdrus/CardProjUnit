using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour {

    //Classe qui règle un tour de jeu
    public Text timer;
    public Text turn;
    public Text turnText;
    float t = 120;
    static public bool PlayerTurn;
    public Button EndTurnButton;
	// Use this for initialization
	void Start () {
        StartCoroutine(ShowMessage("Tour du joueur", 2));
        PlayerTurn = true;
        turnText.text = "";
        EndTurnButton.onClick.AddListener(EndTurn);
    }
	
	// Update is called once per frame
	void Update () {
        t -= Time.deltaTime;
        int m = (int)t / 60;
        int s = (int)t / 2;
        timer.text = "Temps restant \n" + m.ToString() + " : " + s.ToString();
        
        if(PlayerTurn == true)
        {
            turn.text = "Tour du joueur";
            
        }
        else
        {
            turn.text = "Tour du monstre";
        }

        if (t == 0)
        {
            EndTurn();
        }
    }

    IEnumerator ShowMessage(string message,float delay)
    {
       
        turnText.text = message;
        turnText.enabled = true;
        yield return new WaitForSeconds(delay);
        turnText.enabled = false;
    }

    void EndTurn()
    {
        if(PlayerTurn == true)
        {
            StartCoroutine(ShowMessage("Tour du monstre", 2));
            PlayerTurn = false;
        }
        else
        {
            Player.RecupAction();
            Player.RecupStamina();
            StartCoroutine(ShowMessage("Tour du joueur", 2));
            
            PlayerTurn = true;
            
        }
        
        t = 120;
    }
}
