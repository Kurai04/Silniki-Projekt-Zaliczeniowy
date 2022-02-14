using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Postac_biedota : MonoBehaviour
{
    [SerializeField] private int health = 100;
    // Start is called before the first frame update

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
            Die();
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
