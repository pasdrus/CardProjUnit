using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class addObjectTolist : MonoBehaviour {


    public GameObject itemTemplate;
    public GameObject content;
    public deck _currentCard;
    int i = 0;

  //  public void AddButton_click()
  //  {


        public void Update() { 

        if (i < _currentCard.deckliste.Count)
        {
            //On copy itemTemplate qui est un bouton
            var copy = Instantiate(itemTemplate);
            //on transform le content pour y ajouter le bouton
            copy.transform.parent = content.transform;
            // on ajoute chaque item de la liste
            //  for(int i = 0; i < _currentCard.deckliste.Count; i++)
            // {
            Card1 c = _currentCard.deckliste[i];
            copy.GetComponentInChildren<Text>().text = c.name;
           // copy.GetComponentInChildren<Image>().sprite = c.artwork;
            i++;
        }
    
            
    }


}
