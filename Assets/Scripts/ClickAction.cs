using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickAction : MonoBehaviour, IPointerDownHandler
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Cliqué "+ gameObject.transform.parent.name);


        //Debug.Log(gameObject.GetComponent<CardDisplay1>());

        //Debug.Log(eventData.pointerPress.GetComponent<CardDisplay1>());

        int Cardstamina = int.Parse(gameObject.GetComponent<CardDisplay1>().staminaText.text);
        int PlayerStamina = Player.GetPlayerStamina();
        int PlayerAction = Player.GetPlayerAction();

        //Debug.Log(Cardstamina + " -- " + PlayerStamina );

        if (gameObject.transform.parent.name == "DropZoneAction" && Player.GetPlayerStamina()>0 && PlayerStamina >= Cardstamina && PlayerAction>0)
        {
            //Effectue l'action et applique les dégats pour l'instant seulement des cartes attaques
            CardDisplay1 carte = gameObject.GetComponent<CardDisplay1>();
            Debug.Log(carte.multAttackText.text);
            int attaque = int.Parse(carte.multAttackText.text);
            int stamina = int.Parse(carte.staminaText.text);
            Enemy.ReceiveDamage(attaque);
            Player.SpendStamina(stamina);
            Player.SpendAction();
        }
        
    }
}
