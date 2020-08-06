using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class manaInteractions : MonoBehaviour
{
    public Text manaText;
    [SerializeField] public playerClass classForPlayer;

    [SerializeField] private float firstAbilityManUsage;
    [SerializeField] private float secondAbilityManUsage;
    [SerializeField] private float thirdAbilityManUsage;

    bool abilityOnePressed;

    private void Awake()
    {
        manaText.text = "Mana: " + classForPlayer.mana;
        abilityOnePressed = false;
    }

    //private void Update()
    //{
    //    if (Input.GetKeyDown (KeyCode.Alpha1))
    //    {
    //        abilityOnePressed = true;
    //    }
    //    abilityOneActive();       
    //}

    //void abilityOneActive()
    //{
    //    if (abilityOnePressed)
    //    {
    //        classForPlayer.currentMana -= firstAbilityManUsage;
    //        manaText.text = "Mana: " + classForPlayer.currentMana;
    //    }
        
    //}
}
