using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class adddeck : MonoBehaviour
{

    public GameObject itemTemplate;
    public GameObject itemTemplate2;
    public GameObject content;
    public listedecks liste;
    public deck _currentCard;
    public RecupName recup;
    public Booldontdestroy allow;




    int i = 0;

    public void Update()
    {

        if (i < liste.deckls.Count)
        {


            GameObject copy = Instantiate(itemTemplate);
            GameObject copydel = Instantiate(itemTemplate2);

            //On copy itemTemplate qui est un bouton

            //on transform le content pour y ajouter le bouton  // copy.transform.parent = content.transform; Vielle Version

            copy.transform.SetParent(content.transform);
            copydel.transform.SetParent(content.transform);

            string s = liste.deckls[i];
            copy.GetComponentInChildren<Text>().text = s;
            int copyIndex = i;
            copydel.GetComponent<Button>().onClick.AddListener(

                () =>
                {
                    Debug.Log("aaai = " + copyIndex);
                    
                    string path = Application.persistentDataPath + "/" + liste.deckls[copyIndex] + ".json";
                    
                    // On retire l'élement de la liste
                    liste.deckls.Remove(liste.deckls[copyIndex]);
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

                    fis = new string[liste.deckls.Count];

                    int j = 0;
                    foreach (String str in liste.deckls)
                    {
                        fis[j] = str;
                        j++;

                    }

                    
                    string fi = JsonHelper.ToJson(fis, true);
                    path = Application.persistentDataPath + "/xxdeckxx.json";
                    System.IO.File.WriteAllText(path, fi);


                }

                );

            


            copy.GetComponent<Button>().onClick.AddListener(

                 () =>
                 {
                     
                     Debug.Log("i = " + copyIndex);
                     string d = liste.deckls[copyIndex];
                     
                     Debug.Log(d);
                     copy.GetComponentInChildren<Text>().text = d;
                  
                    recup.namefile = d;
 
                     string path = Application.persistentDataPath + "/" + d + ".json";
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



                     veriftransfer();


                 }
                 );
            i++;
        }
    }

    public void veriftransfer()
    {
        if (_currentCard.deckliste.Count == 0) { allow.create = false; }
        else
        {
            DontDestroyOnLoad(_currentCard);
            DontDestroyOnLoad(recup);
            allow.create = true;
        }
        DontDestroyOnLoad(allow);
        SceneManager.LoadScene(3, LoadSceneMode.Single);
    }

}