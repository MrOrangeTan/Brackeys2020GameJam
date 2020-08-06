using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerStats : MonoBehaviour
{
    public playerClass classForPlayer;

    private void Awake()
    {
        classForPlayer = new playerClass();
    }
}
