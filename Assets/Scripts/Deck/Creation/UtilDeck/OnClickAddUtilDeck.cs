using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[System.Serializable]
public class OnClickAddUtilDeck : MonoBehaviour, IPointerDownHandler
{

    public UtilDeck myDeck;
    public UtilCardData myCard;

    // au click on ajout la carte à la liste
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log(myCard.Name + " Was Clicked.");
        //On ne peut pas ajouter + de 15 cartes dans le deck.
        if (myDeck.UtilCardsList.Count < 15 && Verif(myCard) == true)
        {
            myDeck.UtilCardsList.Add(myCard);
            Debug.Log(myDeck.UtilCardsList.Count);
        }
    }

    public bool Verif(UtilCardData c)
    {
        int nb = 0;
        bool test = true;
        foreach (UtilCardData card in myDeck.UtilCardsList)
        {
            if (card.Id == myCard.Id)
            {
                nb++;
            }
        }
        if (nb == 3)
        {
            test = false;
        }
        return test;
    }
}
