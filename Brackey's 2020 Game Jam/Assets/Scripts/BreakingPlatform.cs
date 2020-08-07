using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakingPlatform : MonoBehaviour
{
    public float timeBeforeBreak;
    public float timeBeforeRespawn;
    public GameObject Platform;

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            StartCoroutine(Break());
        }
    }

    private IEnumerator Break()
    {
        yield return new WaitForSeconds(timeBeforeBreak);
        GetComponent<BoxCollider2D>().isTrigger = true;
        Platform.SetActive(false);
        yield return new WaitForSeconds(timeBeforeRespawn);
        GetComponent<BoxCollider2D>().isTrigger = false;
        Platform.SetActive(true);
    }
}
