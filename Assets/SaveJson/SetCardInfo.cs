using UnityEngine;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;
using UnityEngine.UI;
using System.Collections.Generic;

public class SetCardInfo : MonoBehaviour
{


    //private deck _currentCard;
    public deck _currentCard;
    public listedecks listed;
    String namefichier;



    void Start()
    {
        ReadDataDeckliste();
    }





   public void SaveData()
    {
        //si la deck liste ne contient pas 15 cartes, on ne peut pas la sauvegarder.
        if (_currentCard.deckliste.Count != 10)
        {
            Debug.Log("il manque des cartes");
        }
        else
        { 
            int i = 0;
            //Sauvegarde dans C:\Users\Admin Flo\AppData\LocalLow\DefaultCompany\CardGame3D ! Pour chez moi.
            // string path = Application.persistentDataPath + "/deck.json";
            string path = Application.persistentDataPath + "/" + namefichier + ".json";
            _currentCard = GetComponent<deck>();

            // On déclare un tableau de Card de la taille de la deckListe.
            Card1[] testjson = new Card1[_currentCard.deckliste.Count];
            // pour chaque carte dans la liste on ajoute la carte dans l'array de card
            foreach (Card1 c in _currentCard.deckliste)
            {
                testjson[i] = c;
                i++;
            }

            // Conversion pour le format json à l'aide de la classe JsonHelper.
            string cardsToJson = JsonHelper.ToJson(testjson, true);
            Debug.Log(cardsToJson);
            // on ecrit dans le fichier
            //System.IO.File.WriteAllText(path, cardsToJson);
            // quand on sauvegarde le deck , on l'ajoute au fichier xxdeckxx.json 
            string[] fis;

                fis = new string[listed.deckls.Count+1];

                int j = 0;
                foreach (String s in listed.deckls)
                {
                    fis[j] = s;
                    j++;

                }

                // si le fichier du deck existe déjà on écrit les nouvelles cartes dedans, sinon on écrit les cartes dans le fichier et on l'ajoute à la liste des decks.
            if (System.IO.File.Exists(path))
            {
                System.IO.File.WriteAllText(path, cardsToJson); }
            else
            {

                System.IO.File.WriteAllText(path, cardsToJson);
                fis[listed.deckls.Count] = namefichier;
                string fi = JsonHelper.ToJson(fis, true);
                path = Application.persistentDataPath + "/xxdeckxx.json";
                System.IO.File.WriteAllText(path, fi);
            }

            

        }
    }

    public void ReadData(string test)
    {
       string path = Application.persistentDataPath + "/" + test + ".json";
            // string path = Application.persistentDataPath + "/deck.json";
            //On lit tout le fichier json
            string contents = System.IO.File.ReadAllText(path);

            //On recupère les objets dans le fichier .json à l'aide de la classe JsonHelper et on les stocks dans un Array de Card
            Card1[] card = JsonHelper.FromJson<Card1>(contents);

            for (int i = 0; i < card.Length; i++)
            {
                Card1 c = card[i];
                Debug.Log(c.name);
                _currentCard.deckliste.Add(c);

            }
        
      
    }


    public void ReadDataDeckliste()
    {
        string path = Application.persistentDataPath + "/xxdeckxx.json";
        if (System.IO.File.Exists(path))
        {

            string contents = System.IO.File.ReadAllText(path);
            String[] fis = JsonHelper.FromJson<String>(contents);
            Debug.Log(contents);
            for (int i = 0; i < fis.Length; i++)
            {

                String s = fis[i]; Debug.Log(s);
                listed.deckls.Add(s);
            }
        }
        else { };
    }

    public void Textchange(string newText)
    {
        namefichier = newText;
    }

}