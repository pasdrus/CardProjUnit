using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewActionCard", menuName = "Cards/ActionCard")]
public class myActionCard : myLab_Card{

    // Type of the card
    [SerializeField]
    private Action typeOfAction = Action.ATTACK;
    public Action TypeOfAction { get; private set; }

    // the multiplier of elementary damage's weapon
    [SerializeField]
    public double MultElem { get; private set; }

    // the multiplier of attack damage's weapon
    [SerializeField]
    public double MultAttack { get; private set; }

    // number of turn during the player can't play the card
    [SerializeField]
    public int NbTurn { get; private set; }
}
