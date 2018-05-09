using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[System.Serializable]
public class click : MonoBehaviour, IPointerDownHandler
{

    public deck deckl;
    public Card1 c;

    // au click on ajout la carte à la liste
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log(c.name + " Was Clicked.");
        //On ne peut pas ajouter + de 15 cartes dans le deck.
        if (deckl.deckliste.Count < 10 && Verif(c)==true)
        {
            deckl.deckliste.Add(c);
        }
    }

    public bool Verif(Card1 c)
    {
        int nb = 0;
        bool test = true;
        foreach (Card1 card in deckl.deckliste)
        {
            if (card.id == c.id)
            {
                nb++;
            }
        }
        if (nb == 2)
        {
            test = false;
        }
        return test;
    }
}
