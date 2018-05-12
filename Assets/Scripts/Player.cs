using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    public Text PlayerHealthText;
    public Text PlayerStaminaText;
    static public Card1 CarteTest;

    static int PlayerHealth;
    static int PlayerStamina;
    public int MaxHealth;
    public int MaxStamina;
	// Use this for initialization
	void Start () {
        PlayerHealth = MaxHealth;
        PlayerStamina = MaxStamina;
        

        
	}
	
	// Update is called once per frame
	void Update () {
        PlayerHealthText.text = "Santé \n" + PlayerHealth.ToString() + "\n  ---- \n" + MaxHealth;
        PlayerStaminaText.text = "Endurance \n" + PlayerStamina.ToString() + "\n  ---- \n" + MaxStamina;
    }
    
    static public int GetPlayerStamina()
    {
        return PlayerStamina;
    }

    static public int GetPlayerHealth()
    {
        return PlayerHealth;
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

}
