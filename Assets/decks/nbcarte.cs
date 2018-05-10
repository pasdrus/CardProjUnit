using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class nbcarte : MonoBehaviour {

    public deck _currentCard;
    public Text myText;


    public void Update()
    {
        changeNumber();
    }

    public void changeNumber()
    {
        myText.text = _currentCard.deckliste.Count  + "/15";
    }


}
