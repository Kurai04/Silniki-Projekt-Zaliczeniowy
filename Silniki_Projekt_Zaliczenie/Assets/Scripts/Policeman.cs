using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Policeman : MonoBehaviour
{
    [SerializeField] private int health = 100;
    public Transform gp;
    public GameObject bullet;
    public Animator animator;

    private void Start()
    {
        InvokeRepeating("Shot", 0f, 1f);
        
    }
    
    private void Shot()
    {
        animator.SetTrigger("Shoot");
        Invoke("Fire", 0.22f);
        
    }

    private void Fire()
    {
        Instantiate(bullet, gp.position, gp.rotation);
    }

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
