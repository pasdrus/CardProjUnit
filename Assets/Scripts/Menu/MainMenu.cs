using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public void PlayGame()
    {
        SceneManager.LoadScene(4);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Deck()
    {
        SceneManager.LoadScene(3);
    }

    public void BackDeck()
    {
        SceneManager.LoadScene(0);
    }

    public void lancerPartie()
    {
        string ActionDeck = PlayerPrefs.GetString("ActionDeck", "");
        string UtilDeck = PlayerPrefs.GetString("UtilDeck", "");

        if (ActionDeck != "" && UtilDeck != "")
        {
            SceneManager.LoadScene(2);
        }
    }

    public void ReturnMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
