using UnityEngine;

[System.Serializable]
public class playerClass : MonoBehaviour
{
    public gameMaster gm;

    public float health = 50f;
    public float currentHealth;
    public float mana;
    public float currentMana;

    public float movementSpeed = 50;

    private void Awake()
    {
        currentHealth = health;
        currentMana = mana;
    }

    private void Update()
    {
        if (currentHealth <= 0)
        {
            goToLastCheckpoint();
        }
    }

    void goToLastCheckpoint()
    {
        currentHealth = health;
        transform.position = gm.lastCheckpointPos;
    }
}
