using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightHovering : MonoBehaviour {
    
    
	// Use this for initialization
	void Start () {
        Image myLight = GetComponent<Image>();
        myLight.enabled = false;

    }
	
	// Update is called once per frame
	void Update () {
        Image myLight = GetComponent<Image>();
        int Cardstamina = int.Parse(gameObject.GetComponentInParent<DisplayActionCard>().staminaText.text);
        float PlayerStamina = Player.GetPlayerStamina();
        
        if (gameObject.transform.parent.parent.name == "DropZoneAction" && Player.GetPlayerStamina() > 0 && PlayerStamina >= Cardstamina)
        {
            myLight.enabled = true;
        }
        else
        {
            myLight.enabled = false;
        }
        
    }
}
