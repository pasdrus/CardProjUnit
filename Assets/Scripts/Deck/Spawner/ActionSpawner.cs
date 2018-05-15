using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionSpawner : MonoBehaviour {

    public GameObject cardPrefab;
    public GameObject handPlayer;

    public Text playerActionDeck;
    public Text numberCardText;

    public ActionDeck currentActionDeck;
    public ActionCardDataBase myDataBase;

    private bool PlayerTurn1;

    public void Start()
    {
        currentActionDeck.ActionCardsList = new List<ActionCardData>();

        playerActionDeck.text = PlayerPrefs.GetString("ActionDeck");
        Debug.Log(playerActionDeck.text);

        string path = Application.persistentDataPath + "/" + playerActionDeck.text + ".json";
        // string path = Application.persistentDataPath + "/deck.json";
        //On lit tout le fichier json
        string contents = System.IO.File.ReadAllText(path);

        //On recupère les objets dans le fichier .json à l'aide de la classe JsonHelper et on les stocks dans un Array de Card
        string[] card = JsonHelper.FromJson<string>(contents);

        for (int i = 0; i < card.Length; i++)
        {
            ActionCardData c = myDataBase.Get(card[i]);
            currentActionDeck.ActionCardsList.Add(c);
        }

        numberCardText.text = "Deck Action : " + currentActionDeck.ActionCardsList.Count.ToString() + " cartes";
    }

    public void Update()
    {
        GameObject PlayerTurn = GameObject.Find("Game");
        Game Turnplayer = PlayerTurn.GetComponent<Game>();
        PlayerTurn1 = Turnplayer.PlayerTurn;
    }

    // This method create a card on the scene during the runtime
    // The card will be initialize with the id took from the deck.
    public void InstantiateActionCard()
    {
        int PlayerAction = Player.GetPlayerAction();
        if (PlayerTurn1 == true && PlayerAction>0)
        {
            int nbCardsDeck = currentActionDeck.ActionCardsList.Count;

            if (nbCardsDeck > 0)
            {
                GameObject newCard = Instantiate(cardPrefab, handPlayer.transform.position, handPlayer.transform.rotation);

                int index = (int)(Random.value * nbCardsDeck);

                ActionCardData myCard = currentActionDeck.ActionCardsList[index];
                currentActionDeck.ActionCardsList.Remove(myCard);

                var script = newCard.GetComponent<DisplayActionCard>();
                script.card = myCard;

                var scriptDrag = newCard.GetComponent<Drag>();
                scriptDrag.typeOfAction = (Drag.Action)myCard.TypeOfAction;
                scriptDrag.parentToReturnTo = handPlayer.transform;

                newCard.transform.SetParent(handPlayer.transform);
                Player.SpendAction();
            }

            numberCardText.text = "Deck Action : " + currentActionDeck.ActionCardsList.Count.ToString() + " cartes";
        }
    }
}
