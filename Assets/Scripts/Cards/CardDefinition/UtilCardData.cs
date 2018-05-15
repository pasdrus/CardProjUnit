using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewUtilitaryCard", menuName = "CreateCard/UtilCard")]
public class UtilCardData : CardData {

    // Type of the card
    [SerializeField]
    private Action typeOfAction = Action.UTILITARY;
    public Action TypeOfAction { get { return typeOfAction; } }
}
