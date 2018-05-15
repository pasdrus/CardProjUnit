using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour {

    //Classe qui règle un tour de jeu
    public Text timer;
    public Text turn;
    public Text turnText;
    float t = 120;
    public bool PlayerTurn = true;
    public Button EndTurnButton;
    private int i = 0;
    private float timer1 = 0; // begins at this value
    private float timerMax = 2; // event occurs at this value
    // Use this for initialization
    void Start () {
        EndTurnButton.onClick.AddListener(EndTurn);
            
        //StartCoroutine(ShowMessage("Tour du joueur", 2));
        turnText.text = "";
        
    }
	
	// Update is called once per frame
	void Update () {

        if(Player.GetPlayerHealth()<=0 || Enemy.GetEnemyHealth() <= 0)
        {
            if(Player.GetPlayerHealth() <= 0)
            {
                StartCoroutine(ShowMessage("Vous avez perdu", 2));
            }
            else
            {
                StartCoroutine(ShowMessage("Vous avez gagné", 2));
            }
            EndGame();
        }



        t -= Time.deltaTime;
        int m = (int)t / 60;
        int s = (int)t / 2;
        timer.text = "Temps restant \n" + m.ToString() + " : " + s.ToString();
        
        if(PlayerTurn == true)
        {

            turn.text = "Tour du joueur";
            EndTurnButton.gameObject.SetActive(true);

        }
        else
        {

            turn.text = "Tour du monstre";
            EndTurnButton.gameObject.SetActive(false);
            //Desactivation du bouton endTurn

        }

        if (t == 0)
        {
            EndTurn();
        }

        if (Enemy.GetEnemyAction() == 0)
        {

            EnemyEndTurn();
            
        }
    }

    IEnumerator ShowMessage(string message,float delay)
    {
       
        turnText.text = message;
        turnText.enabled = true;
        yield return new WaitForSeconds(delay);
        turnText.enabled = false;
    }
    public void EnemyEndTurn()
    {
        timer1 += Time.deltaTime;

            if (timer1 >= timerMax)
            {
                EndTurn();
                timer1 = 0;
            }

    }

    public void EndGame()
    {
        timer1 += Time.deltaTime;

        if (timer1 >= timerMax)
        {
            timer1 = 0;
            SceneManager.LoadScene(0);
        }
    }

    public void EndTurn()
    {
        if(PlayerTurn == true)
        {
            Player.RecupAction();
            Player.RecupStamina();
            StartCoroutine(ShowMessage("Tour du monstre", 2));
            PlayerTurn = false;
        }
        else
        {
            
            Enemy.RecupAction();
            StartCoroutine(ShowMessage("Tour du joueur", 2));
            PlayerTurn = true;
        }
        
        t = 120;
    }
}
