using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    public Text PlayerHealthText;
    public Text PlayerStaminaText;
    public Text PlayerActionText;

    static float PlayerHealth;
    static float PlayerStamina;
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
        if (PlayerHealth > MaxHealth)
        {
            PlayerHealth = MaxHealth;
        }
        PlayerHealthText.text = "Santé \n" + PlayerHealth.ToString() + "\n  ---- \n" + MaxHealth;
        PlayerStaminaText.text = "Endurance \n" + PlayerStamina.ToString() + "\n  ---- \n" + MaxStamina;
        PlayerActionText.text = "Action \n" + PlayerAction.ToString() + " / " + MaxAction;
    }
    

    static public float GetPlayerStamina()
    {
        return PlayerStamina;
    }

    static public void SetPlayerStamina(float PlayerStamina1)
    {
        PlayerStamina = PlayerStamina1 + PlayerStamina;
    }

    static public float GetPlayerHealth()
    {
        return PlayerHealth;
    }

    static public void SetPlayerHealth(float PlayerHealth1)
    {
        PlayerHealth = PlayerHealth1 + PlayerHealth;
    }

    static public int GetPlayerAction()
    {
        return PlayerAction;
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
        if (PlayerStamina < 10)
        {
            PlayerStamina = PlayerStamina + 2;
        }
    }

}
