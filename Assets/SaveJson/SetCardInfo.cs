using UnityEngine;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;

public class SetCardInfo : MonoBehaviour
{


    private deck _currentCard;

    void Start()
    {
 
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            SaveData();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            ReadData();
        }
    }



    void SaveData()
    {
        int i = 0;
        string path = Application.persistentDataPath + "/deck.json";
        _currentCard = GetComponent<deck>();

        // On déclare un tableau de Card de la taille de la deckListe.
        Card1[] testjson = new Card1[_currentCard.deckliste.Count];
        // pour chaque carte dans la liste on ajoute la carte dans l'array de card
        foreach (Card1 c in _currentCard.deckliste)
        {
            testjson[i] = c;
            i++;
        }
        string cardsToJson = JsonHelper.ToJson(testjson, true);
        Debug.Log(cardsToJson);
        System.IO.File.AppendAllText(path, cardsToJson);

    }

    void ReadData()
    {
        string path = Application.persistentDataPath + "/deck.json";
        //On lit tout le fichier json
        string contents = System.IO.File.ReadAllText(path);

        //On recupère les objets dans le fichier .json à l'aide de la classe JsonHelper et on les stocks dans un Array de Card
        Card1[] card = JsonHelper.FromJson<Card1>(contents);

        for (int i = 0; i < card.Length; i++)
        {
            Card1 c = card[i];
            Debug.Log(c.name);
        }


    }

}