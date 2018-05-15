using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveActionDeck : MonoBehaviour {

    public ActionDeck myDeck;
    public DecksList myDecksList;

    public GameObject myDeckTemplate;

    public InputField nameFichier;

    public void SaveActionData()
    {
        //si la deck liste ne contient pas 15 cartes, on ne peut pas la sauvegarder.
        if (myDeck.ActionCardsList.Count != 15)
        {
            Debug.Log("Il manque des cartes");
        }
        else
        {
            int i = 0;
            
            string NameFichier = nameFichier.text.Replace(" ", "") + "_Action";

            //Sauvegarde dans C:\Users\Admin Flo\AppData\LocalLow\DefaultCompany\CardGame3D ! Pour chez moi.
            // string path = Application.persistentDataPath + "/deck.json";
            string path = Application.persistentDataPath + "/" + NameFichier + ".json";
            Debug.Log(path);
            // On déclare un tableau de Card de la taille de la deckListe.
            string[] testjson = new string[myDeck.ActionCardsList.Count];

            // pour chaque carte dans la liste on ajoute la carte dans l'array de card
            foreach (ActionCardData c in myDeck.ActionCardsList)
            {
                testjson[i] = c.Id;
                i++;
            }

            // Conversion pour le format json à l'aide de la classe JsonHelper.
            string cardsToJson = JsonHelper.ToJson(testjson, true);

            string[] fis;

            fis = new string[myDecksList.myActionDecks.Count + 1];

            int j = 0;
            foreach (String s in myDecksList.myActionDecks)
            {
                fis[j] = s;
                j++;

            }
            

            // si le fichier du deck existe déjà on écrit les nouvelles cartes dedans, sinon on écrit les cartes dans le fichier et on l'ajoute à la liste des decks.
            if (System.IO.File.Exists(path))
            {
                System.IO.File.WriteAllText(path, cardsToJson);
            }
            else
            {
                System.IO.File.WriteAllText(path, cardsToJson);
                if (!myDecksList.myActionDecks.Contains(NameFichier))
                {
                    fis[myDecksList.myActionDecks.Count] = NameFichier;
                    myDecksList.myActionDecks.Add(NameFichier);
                }
                string fi = JsonHelper.ToJson(fis, true);
                path = Application.persistentDataPath + "/dataActionDecks.json";
                System.IO.File.WriteAllText(path, fi);
            }

            ResetActionDeck();
        }

    }

    public void ResetActionDeck()
    {
        myDeck.ActionCardsList.Clear();
        nameFichier.text = "";
        foreach (Transform go in myDeckTemplate.transform)
        {
            GameObject.Destroy(go.gameObject);
        }
    }
}
