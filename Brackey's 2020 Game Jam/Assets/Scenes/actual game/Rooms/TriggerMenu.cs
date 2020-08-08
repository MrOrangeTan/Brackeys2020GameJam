using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerMenu : MonoBehaviour
{
    public GameObject Menu;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            Menu.SetActive(true);
    }
}
