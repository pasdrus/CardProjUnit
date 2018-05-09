using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class adddeck : MonoBehaviour
{


    public GameObject itemTemplate;
    public GameObject content;
    public listedecks liste;
    public deck _currentCard;





    int i = 0;

    public void Update()
    {

        if (i < liste.deckls.Count)
        {

            
            GameObject copy = Instantiate(itemTemplate);
            //On copy itemTemplate qui est un bouton

            //on transform le content pour y ajouter le bouton  // copy.transform.parent = content.transform; Vielle Version

            copy.transform.SetParent(content.transform);
            
            string s = liste.deckls[i];
            copy.GetComponentInChildren<Text>().text = s;


            int copyIndex = i;
            copy.GetComponent<Button>().onClick.AddListener(

                 () =>
                 {
                     
                     
                    // 
                     Debug.Log("i = " + copyIndex);
                     string d = liste.deckls[copyIndex];
         
                     Debug.Log(d);
                     copy.GetComponentInChildren<Text>().text = d;
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

                     //on sauvegarde la liste et on la charge avec la scene des decks
                  DontDestroyOnLoad(_currentCard);
                    SceneManager.LoadScene(3,LoadSceneMode.Single);

                 }
                 );
            i++;
        }
    }

}