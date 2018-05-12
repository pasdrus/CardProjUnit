using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    public Text PlayerHealthText;
    public Text PlayerStaminaText;
    public Text PlayerActionText;
    static public Card1 CarteTest;

    static int PlayerHealth;
    static int PlayerStamina;
    static int PlayerAction;
    public int MaxHealth;
    public int MaxStamina;
    public int MaxAction;
	// Use this for initialization
	void Start () {
        PlayerHealth = MaxHealth;
        PlayerStamina = MaxStamina;
        PlayerAction = MaxAction;

        
	}
	
	// Update is called once per frame
	void Update () {
        PlayerHealthText.text = "Santé \n" + PlayerHealth.ToString() + "\n  ---- \n" + MaxHealth;
        PlayerStaminaText.text = "Endurance \n" + PlayerStamina.ToString() + "\n  ---- \n" + MaxStamina;
        PlayerActionText.text = "Action \n" + PlayerAction.ToString() + " / " + MaxAction;
    }
    

    static public int GetPlayerStamina()
    {
        return PlayerStamina;
    }

    static public int GetPlayerHealth()
    {
        return PlayerHealth;
    }

    static public int GetPlayerAction()
    {
        return PlayerAction;
    }

    static public void DealDamage(int Damage)
    {
        
    }

    static public void ReceiveDamage(int Damage)
    {

    }

    static public void SpendStamina(int Stamina)
    {
        PlayerStamina = PlayerStamina - Stamina;
    }

    static public void SpendAction()
    {
        PlayerAction = PlayerAction - 1;
    }

    static public void RecupAction()
    {
        PlayerAction = 3;
    }

    static public void RecupStamina()
    {
        if (PlayerStamina <= 10)
        {
            PlayerStamina = PlayerStamina + 2;
        }
    }

}
