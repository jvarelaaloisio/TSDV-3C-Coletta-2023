using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health_Rocks : MonoBehaviour
{
    [SerializeField] private float health;
    [SerializeField] private float Maxhealth;
    [SerializeField] private bool isAlive;

    private void Start()
    {
        health = Maxhealth;
        isAlive = true;
    }
    private void Update()
    {
        if (health <= 0)
        {
            isAlive = false;
        }

        if (!isAlive)
        {
            Destroy(gameObject);
        }
    }
    public void GetDamage(float damage)
    {
        health -= damage;
    }

    public float GetHealth()
    {
        return health;
    }

    public bool IsAlive()
    {
        return isAlive;
    }

    public float GetMaxHealth()
    {
        return Maxhealth;
    }
}
