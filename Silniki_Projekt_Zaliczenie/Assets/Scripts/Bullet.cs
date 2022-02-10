using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float bulletSpeed;
    [SerializeField] private int bulletDamage;
    private Rigidbody2D rbf;

    private void Start()
    {
        rbf = GetComponent<Rigidbody2D>();
        rbf.velocity = transform.right * bulletSpeed;

    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (!collider.CompareTag("Player"))
            Destroy(gameObject);

        if (collider.CompareTag("Player"))
        {
            Damage dmg = new Damage(bulletDamage);
            collider.SendMessage("TakeDamage", dmg);
        }
        
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject, 1);
    }
}
