using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class affichedeck : MonoBehaviour {

    private GameObject deckl;
    public deck _currentCard;
    public deck test;


	// Use this for initialization
	void Start () {

        deckl = GameObject.Find("deckl").gameObject;
        _currentCard = deckl.GetComponent<deck>();
        foreach(Card1 c in _currentCard.deckliste)
        {
            test.deckliste.Add(c);
        }
        Destroy(deckl);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
