using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public deck _currentCard;

        public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }


    public void ListeDeck()
    {

            SceneManager.LoadScene(2);

    }

    public void ListeDeck2()
    {
        if (_currentCard.deckliste.Count < 15) { }
        else
        {
        SceneManager.LoadScene(2);
        }
    }

   public void Deck()
    {
        SceneManager.LoadScene(3);
    }

    public void BackDeck()
    {
        SceneManager.LoadScene(0);
    }



}
