using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddCardUtilDeck : MonoBehaviour {

    public GameObject myTemplate;
    public GameObject myContent;

    public Text myNumberCards;

    public UtilDeck myUtilDeck;
    int i = 0;


    public void Update()
    {
        if (i > myUtilDeck.UtilCardsList.Count)
        {
            i = 0;
        }

        if (i < myUtilDeck.UtilCardsList.Count)
        {
            GameObject copy = Instantiate(myTemplate);
            //On copy itemTemplate qui est un bouton

            //on transform le content pour y ajouter le bouton  // copy.transform.parent = content.transform; Vielle Version

            copy.transform.SetParent(myContent.transform);

            UtilCardData c = myUtilDeck.UtilCardsList[i];
            copy.GetComponentInChildren<Text>().text = c.Name;

            copy.GetComponentInChildren<Image>().sprite = c.Artwork;
            int copyIndex = i;
            copy.GetComponent<Button>().onClick.AddListener(

                () =>
                {
                    Debug.Log("i = " + copyIndex);
                    UtilCardData d = myUtilDeck.UtilCardsList[copyIndex];
                    myUtilDeck.UtilCardsList.Remove(d);
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
        myNumberCards.text = myUtilDeck.UtilCardsList.Count + "/15";
    }
}
