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
    /*    _currentCard = GetComponent<deck>();

        foreach (Card1 c in _currentCard.deckliste)
            Debug.Log("Card id: " + c.id);*/
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            Test();
        }
    }



 /*   void SaveData()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/User.txt");
        // _currentCard = GetComponent<deck>();
        // _currentCard = GameObject.Find("test").GetComponent<deck>();

        //Debug.Log("Total Cards: " + _currentCard.deckliste);
        // foreach (Card c in _currentCard.deckliste) { 
        _currentCard = GetComponent<deck>();
        bf.Serialize(file, _currentCard);
  //  }
        file.Close();
   }
        string path = Application.persistentDataPath + "/deck.json";
        // for (int i = 0; i < deck.Count; i++)
        //  {
        _currentCard = GetComponent<deck>();
        foreach (Card c in _currentCard.deckliste)
        {
            string contents = JsonUtility.ToJson(c);
            System.IO.File.AppendAllText(path, contents);
        }
    }

    void ReadData()
    {
        string path = Application.persistentDataPath + "/deck.json";
        // try
        // {

        if (System.IO.File.Exists(path))
        {
            string contents = System.IO.File.ReadAllText(path);

            _currentCard = JsonUtility.FromJson<deck>(contents);
            CardData cardtest = new CardData();
            cardtest.name = _currentCard.name;
            Debug.Log(cardtest.name);
        }
        else
        {
            Debug.Log("Erreur tmtc");
        }

    }*/

   public void Test()
    {
        _currentCard = GetComponent<deck>();

        foreach (Card1 c in _currentCard.deckliste)
            Debug.Log("Card id: " + c.id);
    }
}