﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class affichedeck : MonoBehaviour {

    private GameObject deckl;
    private InputField InputFieldname;
    
    public deck _currentCard;
    public deck test;
    public RecupName recup;
    //public testrecup t;

	// Use this for initialization
	void Start () {

        deckl = GameObject.Find("deckl").gameObject;
        
        recup = deckl.GetComponent<RecupName>();
        Debug.Log(recup);
        _currentCard = deckl.GetComponent<deck>();
        foreach(Card1 c in _currentCard.deckliste)
        {
            test.deckliste.Add(c);
        }

        GameObject aaa = GameObject.Find("namedeck");
        InputFieldname = aaa.GetComponent<InputField>();
        InputFieldname.text = recup.namefile;

        Destroy(deckl);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
