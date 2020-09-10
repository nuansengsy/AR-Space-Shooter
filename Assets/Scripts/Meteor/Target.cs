using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float health;

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            DelegatesHandler.SharedInstance.IncreaseScore();
            Destroy(gameObject);
        }
    }

}
