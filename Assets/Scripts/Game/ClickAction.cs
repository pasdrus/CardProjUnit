using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickAction : MonoBehaviour, IPointerDownHandler
{
    private bool PlayerTurn1;
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
         GameObject PlayerTurn = GameObject.Find("Game");
        Game Turnplayer = PlayerTurn.GetComponent<Game>();
        PlayerTurn1 = Turnplayer.PlayerTurn;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //Debug.Log("Cliqué "+ gameObject.transform.parent.name);


        if(gameObject.GetComponent<DisplayUtilCard>()==null)
        {
        //Debug.Log(eventData.pointerPress.GetComponent<CardDisplay1>());
        int Cardstamina = int.Parse(gameObject.GetComponent<DisplayActionCard>().staminaText.text);
        float PlayerStamina = Player.GetPlayerStamina();
        int PlayerAction = Player.GetPlayerAction();
        //Effectue l'action et applique les dégats pour l'instant seulement des cartes attaques
            DisplayActionCard carte = gameObject.GetComponent<DisplayActionCard>();
        //Debug.Log(Cardstamina + " -- " + PlayerStamina );

        if (gameObject.transform.parent.name == "DropZoneAction" && Player.GetPlayerStamina() > 0 && PlayerStamina >= Cardstamina && PlayerAction > 0 && PlayerTurn1==true)
        {
            
            //Debug.Log(carte.multAttackText.text);
            float attaqueBrut = float.Parse(carte.multAttackText.text);
            //float attaque = attaqueBrut * ArmeBrut;
            float attaque = attaqueBrut * 10;
            float attaqueElem = float.Parse(carte.multElemText.text);
            //float attaque1 = attaqueElem * ArmeElem;
            float attaque1 = attaqueElem * 10;
            float dmg = attaque + attaque1; 
            int stamina = int.Parse(carte.staminaText.text);
            int NbUtilisation = int.Parse(carte.nbTurnText.text);
            NbUtilisation = NbUtilisation - 1;
            if (NbUtilisation == 0)
            {
                Destroy(gameObject);
            }
            carte.nbTurnText.text = NbUtilisation.ToString();
            Enemy.ReceiveDamage(dmg);
            Player.SpendStamina(stamina);
            Player.SpendAction();
        }
        }
        else
        {
            //Debug.Log(eventData.pointerPress.GetComponent<CardDisplay1>());
            
            int PlayerAction = Player.GetPlayerAction();
            
            //Effectue l'action et applique les dégats pour l'instant seulement des cartes attaques
            DisplayUtilCard carte = gameObject.GetComponent<DisplayUtilCard>();
            //Debug.Log(Cardstamina + " -- " + PlayerStamina );

            if (gameObject.transform.parent.name == "DropZoneUtilitaire" && PlayerAction > 0 && PlayerTurn1 == true)

            {string CardTitle = gameObject.GetComponent<DisplayUtilCard>().nameText.text;
            int CardUse = int.Parse(gameObject.GetComponent<DisplayUtilCard>().nbUseText.text);
            Debug.Log(CardUse);
                CardUse = CardUse - 1;
                if (CardUse == 0)
                {
                    Destroy(gameObject);
                }
                carte.nbUseText.text = CardUse.ToString();
                Debug.Log(CardTitle);
                Utilitaire(CardTitle);
                Player.SpendAction();
            }
        }
    }

    public void Utilitaire(string NomCarte)
    {
        if (NomCarte == "Potion de vitalité")
        {
            Player.SetPlayerHealth(30);
        }

        if (NomCarte == "Potion de vitalité sup.")
        {
            Player.SetPlayerHealth(80);
        }

        if (NomCarte == "Potion de Stamina")
        {
            Player.SetPlayerStamina(30);
        }

        if (NomCarte == "Potion de métal")
        {
            Player.SetPlayerHealth(30);
        }

        if (NomCarte == "Elixir de rage")
        {
            Debug.Log("rien pour l'instant");
        }

        if (NomCarte == "Bombe Moyenne")
        {
            Enemy.ReceiveDamage(30);
        }

    }
}
