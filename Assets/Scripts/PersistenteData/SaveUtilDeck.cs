using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveUtilDeck : MonoBehaviour {

    public UtilDeck myDeck;
    public DecksList myDecksList;

    public GameObject myDeckTemplate;

    public InputField nameFichier;

    // Use this for initialization
    void Start()
    {
        //Mdr tu me vois ?
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SaveUtilData()
    {
        //si la deck liste ne contient pas 15 cartes, on ne peut pas la sauvegarder.
        if (myDeck.UtilCardsList.Count != 15)
        {
            Debug.Log("Il manque des cartes");
        }
        else
        {
            int i = 0;

            string NameFichier = nameFichier.text.Replace(" ", "") + "_Util";

            //Sauvegarde dans C:\Users\Admin Flo\AppData\LocalLow\DefaultCompany\CardGame3D ! Pour chez moi.
            // string path = Application.persistentDataPath + "/deck.json";
            string path = Application.persistentDataPath + "/" + NameFichier + ".json";

            // On déclare un tableau de Card de la taille de la deckListe.
            string[] testjson = new string[myDeck.UtilCardsList.Count];

            // pour chaque carte dans la liste on ajoute la carte dans l'array de card
            foreach (UtilCardData c in myDeck.UtilCardsList)
            {
                testjson[i] = c.Id;
                i++;
            }

            // Conversion pour le format json à l'aide de la classe JsonHelper.
            string cardsToJson = JsonHelper.ToJson(testjson, true);

            string[] fis;

            fis = new string[myDecksList.myUtilDecks.Count + 1];

            int j = 0;
            foreach (String s in myDecksList.myUtilDecks)
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
                if (!myDecksList.myUtilDecks.Contains(NameFichier))
                {
                    fis[myDecksList.myUtilDecks.Count] = NameFichier;
                    myDecksList.myUtilDecks.Add(NameFichier);
                }
                string fi = JsonHelper.ToJson(fis, true);
                path = Application.persistentDataPath + "/dataUtilDecks.json";
                System.IO.File.WriteAllText(path, fi);
            }

            ResetUtilDeck();
        }

    }

    public void ResetUtilDeck()
    {
        myDeck.UtilCardsList.Clear();
        nameFichier.text = "";
        foreach (Transform go in myDeckTemplate.transform)
        {
            GameObject.Destroy(go.gameObject);
        }
    }
}
