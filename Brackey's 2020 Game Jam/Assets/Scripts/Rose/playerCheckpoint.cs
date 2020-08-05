using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCheckpoint : MonoBehaviour
{
    private gameMaster gm;

    // Start is called before the first frame update
    void Awake()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<gameMaster>();
        transform.position = gm.lastCheckpointPos;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.position = gm.lastCheckpointPos;
        }
    }
}
