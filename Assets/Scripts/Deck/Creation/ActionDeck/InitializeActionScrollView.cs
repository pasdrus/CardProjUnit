using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InitializeActionScrollView : MonoBehaviour {

    public GameObject ScrollView;

    public GameObject ActionCard;

    public ActionDeck currentDeck;

    public ActionCardDataBase myActionDataBase;

	// Use this for initialization
	void Start () {

        ScrollRect myViewport = ScrollView.GetComponent<ScrollRect>();
        Transform myContent = myViewport.content;

        int nbCards = myActionDataBase.dataAsArray.Length;
       
        for(int i = 0; i < nbCards; i++)
        {
            GameObject myCardCollection = Instantiate(ActionCard);

            DisplayActionCard theDisplayCard = myCardCollection.GetComponent<DisplayActionCard>();
            theDisplayCard.card = myActionDataBase.dataAsArray[i];

            OnClickAddActionDeck clickScript = myCardCollection.GetComponent<OnClickAddActionDeck>();
            clickScript.myDeck = currentDeck;
            clickScript.myCard = myActionDataBase.dataAsArray[i];

            myCardCollection.transform.SetParent(myContent);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
