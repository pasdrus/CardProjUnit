using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewActionCard", menuName = "CreateCard/ActionCard")]
public class ActionCardData : CardData {

    // Type of the card
    [SerializeField]
    private Action typeOfAction = Action.ATTACK;
    public Action TypeOfAction { get { return typeOfAction; } }

    // the multiplier of elementary damage's weapon
    [SerializeField]
    private double multElem;
    public double MultElem { get { return multElem; } }

    // the multiplier of attack damage's weapon
    [SerializeField]
    private double multAttack;
    public double MultAttack { get { return multAttack; } }

    // number of turn during the player can't play the card
    [SerializeField]
    private int coolDown;
    public double Cooldown { get { return coolDown; } }
}
