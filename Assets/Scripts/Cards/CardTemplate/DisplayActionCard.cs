using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayActionCard : MonoBehaviour {

    public ActionCardData card;

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
        nameText.text = card.Name;
        descriptionText.text = card.Description;

        artworkImage.sprite = card.Artwork;

        staminaText.text = card.StaminaCost.ToString();
        multAttackText.text = card.MultAttack.ToString();
        multElemText.text = card.MultElem.ToString();
        nbTurnText.text = card.Cooldown.ToString();
        nbDesText.text = card.NbUse.ToString();
    }
}
