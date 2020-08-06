using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameMaster : MonoBehaviour
{
    [SerializeField] private static gameMaster gmInstance;
    public Vector2 lastCheckpointPos;

    private void Awake()
    {
        //If this variable does not have any reference,
        if (gmInstance == null)
        {
            //then this will be the reference
            gmInstance = this;
            //will not destroy itself while switching scenes
            DontDestroyOnLoad(gmInstance);
        }

        //but if there is already an reference
        else
        {
            //destroy this gameobject to so that it will not be overwritten
            Destroy(gameObject);
        }
    }
}
