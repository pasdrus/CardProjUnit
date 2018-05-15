using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayUtilCard : MonoBehaviour {

    public UtilCardData card;

    public Text nameText;

    public Text descriptionText;

    public Image artworkImage;

    public Text staminaText;

    public Text nbUseText;

    // Use this for initialization
    void Start()
    {
        nameText.text = card.Name;

        descriptionText.text = card.Description;

        artworkImage.sprite = card.Artwork;

        staminaText.text = card.StaminaCost.ToString();

        nbUseText.text = card.NbUse.ToString();
    }
}
