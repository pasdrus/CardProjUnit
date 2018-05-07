using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
[CreateAssetMenu(fileName = "New Card1", menuName = "Card1")]
public class Card1 : ScriptableObject
{
    public int id;

    public new string name;
    public string description;

    public Sprite artwork;


    public int StaminaCost;
    public int multAttack;
    public int multElem;
    public int nbTurn;
    public int nbDes;
    public enum Action { ATTACK, UTILITARY, HAND };
    public Action typeOfAction = Action.ATTACK;

}