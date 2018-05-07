using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewUtilitaryCard", menuName = "Cards/UtilitaryCard")]
public class myUtilityCard : myLab_Card {

    // Type of the card
    [SerializeField]
    private Action typeOfAction = Action.UTILITARY;
    public Action TypeOfAction { get; private set; }

}
