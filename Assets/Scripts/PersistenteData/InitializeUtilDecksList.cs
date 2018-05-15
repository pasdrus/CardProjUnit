using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class InitializeUtilDecksList : MonoBehaviour {

    public DecksList myDecksList;
    public UtilDeck myDeck;
    public UtilCardDataBase myDataBase;

    public InputField nameDeck;

    public GameObject itemTemplate;
    public GameObject itemTemplate2;
    public GameObject content;

    private int i = 0;

    public void Start()
    {
        ReadDecksList();
    }
    // Update is called once per frame
    void Update()
    {

        List<string> myUtilDecks = myDecksList.myUtilDecks;
        if (i < myUtilDecks.Count)
        {


            GameObject copy = Instantiate(itemTemplate);
            GameObject copydel = Instantiate(itemTemplate2);

            //On copy itemTemplate qui est un bouton

            //on transform le content pour y ajouter le bouton  // copy.transform.parent = content.transform; Vielle Version

            copy.transform.SetParent(content.transform);
            copydel.transform.SetParent(content.transform);

            string s = myUtilDecks[i];
            copy.GetComponentInChildren<Text>().text = s;
            int copyIndex = i;

            copydel.GetComponent<Button>().onClick.AddListener(

                () =>
                {
                    string path = Application.persistentDataPath + "/" + myUtilDecks[copyIndex] + ".json";

                    // On retire l'élement de la liste
                    myUtilDecks.Remove(myUtilDecks[copyIndex]);
                    // On supprime le fichier ayant pour nom liste.deckls[copyIndex]
                    File.Delete(path);
                    //On détruit tous les boutons dans content puis on fait recommencer i à 0 pour qu'il recharge la liste avec les nouveaux id;
                    foreach (Transform child in content.transform)
                    {
                        GameObject.Destroy(child.gameObject);
                    }
                    i = 0;


                    // sauvegarde

                    string[] fis;

                    fis = new string[myUtilDecks.Count];

                    int j = 0;
                    foreach (string str in myUtilDecks)
                    {
                        fis[j] = str;
                        j++;

                    }


                    string fi = JsonHelper.ToJson(fis, true);
                    path = Application.persistentDataPath + "/dataUtilDecks.json";
                    System.IO.File.WriteAllText(path, fi);


                }

                );




            copy.GetComponent<Button>().onClick.AddListener(

                 () =>
                 {

                     Debug.Log("i = " + copyIndex);
                     string d = myUtilDecks[copyIndex];

                     copy.GetComponentInChildren<Text>().text = d;
                     nameDeck.text = d.Replace("_Util", "");

                     string path = Application.persistentDataPath + "/" + d + ".json";
                     // string path = Application.persistentDataPath + "/deck.json";
                     //On lit tout le fichier json
                     string contents = System.IO.File.ReadAllText(path);

                     //On recupère les objets dans le fichier .json à l'aide de la classe JsonHelper et on les stocks dans un Array de Card
                     string[] card = JsonHelper.FromJson<string>(contents);

                     for (int i = 0; i < card.Length; i++)
                     {
                         UtilCardData c = myDataBase.Get(card[i]);
                         Debug.Log(c.name);
                         myDeck.UtilCardsList.Add(c);

                     }
                 }
                 );
            i++;
        }

    }

    public void ReadDecksList()
    {
        string path = Application.persistentDataPath + "/dataUtilDecks.json";
        if (System.IO.File.Exists(path))
        {

            string contents = System.IO.File.ReadAllText(path);
            string[] fis = JsonHelper.FromJson<string>(contents);
            Debug.Log(contents);
            for (int i = 0; i < fis.Length; i++)
            {

                string s = fis[i]; Debug.Log(s);
                myDecksList.myUtilDecks.Add(s);
            }
        }
        else { };
    }
}
