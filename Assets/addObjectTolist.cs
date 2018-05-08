using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class addObjectTolist : MonoBehaviour
{


    public GameObject itemTemplate;
    public GameObject content;
    public deck _currentCard;
    int i = 0;


        public void Update() {
       
        if (i < _currentCard.deckliste.Count)
        {
 

            GameObject copy = Instantiate(itemTemplate);
            //On copy itemTemplate qui est un bouton

            //on transform le content pour y ajouter le bouton  // copy.transform.parent = content.transform; Vielle Version
            
            copy.transform.SetParent(content.transform);

            Card1 c = _currentCard.deckliste[i];
            copy.GetComponentInChildren<Text>().text = c.name;

            copy.GetComponentInChildren<Image>().sprite= c.artwork;
            int copyIndex = i;
            copy.GetComponent<Button>().onClick.AddListener(

                () =>
                {
                    Debug.Log("i = " + copyIndex);
                    Card1 d = _currentCard.deckliste[copyIndex];
                    _currentCard.deckliste.Remove(d);
                    Destroy(copy);

                    //On detruit tous les boutons puis on recommence la liste à 0 pour faire basculer les id.
                    foreach(Transform child in content.transform)
                    {
                        GameObject.Destroy(child.gameObject);
                    }
                   i = 0;
                }
                );
            i++;
        }
 }



}
