using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class Enemy : MonoBehaviour {


    public Text EnemyHealthText;
    public Text EnemyStaminaText;
    public Text EnemyActionText;
    static float EnemyHealth;
    static int EnemyStamina;
    static int EnemyAction;
    public int MaxHealth;
    public int MaxStamina;
    public int MaxAction;
    private bool PlayerTurn1;
    private Dictionary<string,int> ListePriorite = new Dictionary<string,int>();

    //Texte pour montrer ce que le monstre fait
    public Text EnemyTurnText;

    private float timer = 0; // begins at this value
    private float timerMax = 2; // event occurs at this value

    // Use this for initialization
    void Start()
    {
        EnemyHealth = MaxHealth;
        EnemyStamina = MaxStamina;
        EnemyAction = MaxAction;

        ListePriorite.Add("Tuer", 100);
        ListePriorite.Add("Soigner", 50);
        ListePriorite.Add("Destruction", 30);
        var myList = ListePriorite.ToList();
        myList.Sort((pair1, pair2) => pair1.Value.CompareTo(pair2.Value));
        int max = myList.Count() - 1;
    }

    static public int GetEnemyStamina()
    {
        return EnemyStamina;
    }

    static public float GetEnemyHealth()
    {
        return EnemyHealth;
    }

    static public int GetEnemyAction()
    {
        return EnemyAction;
    }

    // Update is called once per frame
    void Update () {

        GameObject PlayerTurn = GameObject.Find("Game");
        Game Turnplayer = PlayerTurn.GetComponent<Game>();
        PlayerTurn1 = Turnplayer.PlayerTurn;


        EnemyHealthText.text = "Santé \n" + EnemyHealth.ToString() + "\n  ---- \n" + MaxHealth;
        EnemyStaminaText.text = "Endurance \n" + EnemyStamina.ToString() + "\n  ---- \n" + MaxStamina;
        EnemyActionText.text = "Action \n" + EnemyAction.ToString() + " / " + MaxAction;

            //Ici on a l'ordre des priorités
            if (RecupNombreCarte() == 3)
            {
            ListePriorite["Destruction"] = 1200;
            }
            else
            {
            ListePriorite["Destruction"] = 30;
            }

            if (EnemyHealth < 60)
            {
            ListePriorite["Soigner"] = 1100;
            }
            else
            {
            ListePriorite["Soigner"] = 50;
            }

            if (Player.GetPlayerHealth() < 60)
            {
            ListePriorite["Tuer"] = 1000;
            }
            else
            {
            ListePriorite["Tuer"] = 100;
            }

        if (PlayerTurn1 == false)
        {
            var myList = ListePriorite.ToList();
            myList.Sort((pair1, pair2) => pair1.Value.CompareTo(pair2.Value));

                if (EnemyAction > 0)
            {
                myList = ListePriorite.ToList();
                myList.Sort((pair1, pair2) => pair1.Value.CompareTo(pair2.Value));
                int max = myList.Count() - 1;

                string action = myList[max].Key;
                //Debug.Log(action);
                //Debug.Log(ListePriorite["Destruction"]);
                if (action == "Tuer")
                {
                    Attaque();
                }else if(action == "Soigner")
                {
                    RecupHealth();
                }
                else if(action == "Destruction")
                {
                    DestroyCard();
                }
            }
        }
    }
    

   

    IEnumerator ShowMessage(string message, float delay)
        {

        EnemyTurnText.text = message;
        EnemyTurnText.enabled = true;
            yield return new WaitForSeconds(delay);
        EnemyTurnText.enabled = false;
        }

     public void RecupHealth()
    {
        

        timer += Time.deltaTime;

        if (timer >= timerMax)
        {   EnemyHealth = EnemyHealth + 30;
            SpendAction();
            StartCoroutine(ShowMessage("Le monstre a récupéré 30 points de vie", 0.5f));
            timer = 0;
            //Debug.Log("timerMax reached !");
        }

    }

    public void Attaque()
    {
        
        
        timer += Time.deltaTime;
        
        if (timer >= timerMax)
        {
            Player.SetPlayerHealth(-10);
        SpendAction();
        StartCoroutine(ShowMessage("Le monstre vous a attaqué", 0.5f));
            timer = 0;
            //Debug.Log("timerMax reached !");
        }

    }

    public void DestroyCard()
    {
        timer += Time.deltaTime;

        if (timer >= timerMax)
        {   GameObject[] ListeCartes = GameObject.FindGameObjectsWithTag("CarteAction");
            List<GameObject> ListeRandom = new List<GameObject>();
            //Random random = new Random();
            for (int i = 0; i < ListeCartes.Length; i++)
            {
            if (ListeCartes[i].transform.parent.name == "DropZoneAction")
            {
                ListeRandom.Add(ListeCartes[i]);
            }
            //Debug.Log("Non Trouvé");
            }
            int destru = Random.Range(0,ListeRandom.Count);
            Destroy(ListeRandom.ElementAt(destru));
            SpendAction();
            
            StartCoroutine(ShowMessage("Le monstre a détruit une de vos cartes", 0.5f));
            timer = 0;
            //Debug.Log("timerMax reached !");
        }
    }

    public int RecupNombreCarte()
    {
        GameObject[] ListeCartesAction = GameObject.FindGameObjectsWithTag("CarteAction");
        List<GameObject> ListeAction = new List<GameObject>();
        for (int i = 0; i < ListeCartesAction.Length; i++)
        {
            if (ListeCartesAction[i].transform.parent.name == "DropZoneAction")
            {
                ListeAction.Add(ListeCartesAction[i]);
                
            }
            
        }
        return ListeAction.Count;
    }

    static public void ReceiveDamage(float Damage)
    {
        EnemyHealth = EnemyHealth - Damage;
    }

    static public void SpendStamina(int Stamina)
    {

    }


    static public void SpendAction()
    {
        EnemyAction = EnemyAction - 1;
    }

    static public void RecupAction()
    {
        EnemyAction = 3;
    }

}
