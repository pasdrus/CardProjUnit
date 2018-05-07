using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewCard", menuName = "Cards")]
public class myLab_Card : ScriptableObject {

    // Unique Card id
    [SerializeField]
    private string id;
    public string Id { get { return id; } }

    // Card's name
    [SerializeField]
    private string _name;
    public string Name { get { return _name; } }

    // Description of the card
    [SerializeField]
    private string description;
    public string Description { get { return description; } }

    // Artwork of th card
    [SerializeField]
    private Sprite artwork;
    public Sprite Artwork { get { return artwork; } }

    // Stamina cost of the card, price have to pay to play it
    [SerializeField]
    private int staminaCost;
    public int StaminaCost { get { return staminaCost; } }

    // Number of uses of the card
    [SerializeField]
    private int nbUse;
    public int NbUse
    {
        get
        {
            return nbUse;
        }

        set
        {
            nbUse = value;
        }
    }

    //  Define the type of the card
    public enum Action { ATTACK, UTILITARY, HAND };
}
