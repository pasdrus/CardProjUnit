using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InitializeUtilScrollView : MonoBehaviour {

    public GameObject ScrollView;

    public GameObject UtilCard;

    public UtilDeck currentDeck;

    public UtilCardDataBase myUtilDataBase;

    // Use this for initialization
    void Start()
    {

        ScrollRect myViewport = ScrollView.GetComponent<ScrollRect>();
        Transform myContent = myViewport.content;

        int nbCards = myUtilDataBase.dataAsArray.Length;

        for (int i = 0; i < nbCards; i++)
        {
            GameObject myCardCollection = Instantiate(UtilCard);

            DisplayUtilCard theDisplayCard = myCardCollection.GetComponent<DisplayUtilCard>();
            theDisplayCard.card = myUtilDataBase.dataAsArray[i];

            OnClickAddUtilDeck clickScript = myCardCollection.GetComponent<OnClickAddUtilDeck>();
            clickScript.myDeck = currentDeck;
            clickScript.myCard = myUtilDataBase.dataAsArray[i];

            myCardCollection.transform.SetParent(myContent);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
