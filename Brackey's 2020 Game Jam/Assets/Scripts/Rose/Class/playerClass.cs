using UnityEngine;

[System.Serializable]
public class playerClass : MonoBehaviour
{
    public float health = 50f;
    public float mana;
    public float movementSpeed = 50;

    private void Update()
    {
        if (health <= 0)
        {
            goToLastCheckpoint()
        }
    }

    void goToLastCheckpoint()
    {

    }
}
