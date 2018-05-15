using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InitializeChoixUtilList : MonoBehaviour {

    public DecksList myDecksList;
    public Text playerDeck;

    public Text currentUtilChoice;

    public GameObject itemTemplate;

    public GameObject content;

    private int i = 0;

    public void Start()
    {
        ReadDecksList();
    }

    public void Update()
    {
         List<string> myUtilDecks = myDecksList.myUtilDecks;

        if (i < myDecksList.myUtilDecks.Count)
        {


            GameObject copy = Instantiate(itemTemplate);

            copy.transform.SetParent(content.transform);

            string s = myUtilDecks[i];
            copy.GetComponentInChildren<Text>().text = s;
            int copyIndex = i;

            copy.GetComponent<Button>().onClick.AddListener(

                 () =>
                 {

                     string d = myUtilDecks[copyIndex];

                     currentUtilChoice.text = d;
                     playerDeck.text = d;
                     copy.GetComponentInChildren<Text>().text = d;
                 }
                 );
            i++;
        }
    }

    public void ReadDecksList()
    {
        myDecksList.myUtilDecks.Clear();

        string path = Application.persistentDataPath + "/dataUtilDecks.json";
        if (System.IO.File.Exists(path))
        {

            string contents = System.IO.File.ReadAllText(path);
            string[] fis = JsonHelper.FromJson<string>(contents);

            for (int i = 0; i < fis.Length; i++)
            {

                string s = fis[i]; Debug.Log(s);
                myDecksList.myUtilDecks.Add(s);
            }
        }
        else { };
    }
}
