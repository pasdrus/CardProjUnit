using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {


    public Text EnemyHealthText;
    public Text EnemyStaminaText;
    static int EnemyHealth;
    static int EnemyStamina;
    public int MaxHealth;
    public int MaxStamina;
    // Use this for initialization
    void Start()
    {
        EnemyHealth = MaxHealth;
        EnemyStamina = MaxStamina;
        
    }


    // Update is called once per frame
    void Update () {
        EnemyHealthText.text = "Santé \n" + EnemyHealth.ToString() + "\n  ---- \n" + MaxHealth;
        EnemyStaminaText.text = "Endurance \n" + EnemyStamina.ToString() + "\n  ---- \n" + MaxStamina;
    }

    static public void ReceiveDamage(int Damage)
    {
        EnemyHealth = EnemyHealth - Damage;
    }

    static public void SpendStamina(int Stamina)
    {

    }
}
