using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddCardActionDeck : MonoBehaviour {

    public GameObject myTemplate;
    public GameObject myContent;

    public Text myNumberCards;

    public ActionDeck myActionDeck;
    int i = 0;


    public void Update()
    {
        if(i > myActionDeck.ActionCardsList.Count)
        {
            i = 0;
        }

        if (i < myActionDeck.ActionCardsList.Count)
        {
            
            GameObject copy = Instantiate(myTemplate);
            //On copy itemTemplate qui est un bouton

            //on transform le content pour y ajouter le bouton  // copy.transform.parent = content.transform; Vielle Version

            copy.transform.SetParent(myContent.transform);

            ActionCardData c = myActionDeck.ActionCardsList[i];
            copy.GetComponentInChildren<Text>().text = c.Name;

            copy.GetComponentInChildren<Image>().sprite = c.Artwork;
            int copyIndex = i;
            copy.GetComponent<Button>().onClick.AddListener(

                () =>
                {
                    ActionCardData d = myActionDeck.ActionCardsList[copyIndex];
                    myActionDeck.ActionCardsList.Remove(d);
                    Destroy(copy);

                    //On detruit tous les boutons puis on recommence la liste à 0 pour faire basculer les id.
                    foreach (Transform child in myContent.transform)
                    {
                        GameObject.Destroy(child.gameObject);
                    }
                    i = 0;
                }
                );
            i++;
        }
        myNumberCards.text = myActionDeck.ActionCardsList.Count + "/15";
    }

}
