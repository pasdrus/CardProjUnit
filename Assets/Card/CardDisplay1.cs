using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]
public class CardDisplay1 : MonoBehaviour
{

    public Card1 card;

    public Text nameText;
    public Text descriptionText;

    public Image artworkImage;

    public Text staminaText;
    public Text multAttackText;
    public Text multElemText;
    public Text nbTurnText;
    public Text nbDesText;

    // Use this for initialization
    void Start()
    {
        nameText.text = card.name;
        descriptionText.text = card.description;

        artworkImage.sprite = card.artwork;

        staminaText.text = card.StaminaCost.ToString();
        multAttackText.text = card.multAttack.ToString();
        multElemText.text = card.multElem.ToString();
        nbTurnText.text = card.nbTurn.ToString();
        nbDesText.text = card.nbDes.ToString();
    }

}
