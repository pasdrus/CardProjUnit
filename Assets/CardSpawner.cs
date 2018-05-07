using UnityEngine;

public class CardSpawner : MonoBehaviour {

    [SerializeField]
    private actionCardDataBase DBAC;

    public GameObject cardPrefab;
    public GameObject handPlayer;

    // This method create a card on the scene during the runtime
    // The card will be initialize with the id took from the deck.
	public void InstantiateCard()
    {
        GameObject newCard = Instantiate(cardPrefab,handPlayer.transform.position,handPlayer.transform.rotation);
        myActionCard myCard = DBAC.Get("10");

        var script = newCard.GetComponent<CardDisplay1>();
        script.card = myCard;

        var scriptDrag = newCard.GetComponent<Drag>();
        scriptDrag.typeOfAction = (Drag.Action) myCard.TypeOfAction;

        newCard.transform.SetParent(handPlayer.transform);
    }
}
