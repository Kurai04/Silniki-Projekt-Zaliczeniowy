using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atak : MonoBehaviour
{
    [SerializeField] private float offsetX = 3f;
    [SerializeField] private float offsetY = 3f;
    [SerializeField] private float dystans = 1f;
    [SerializeField] private LayerMask gracz;
    [SerializeField] private Animator animator;

    private Vector2 pozycja_koncowa;

    private void Update()
    {
         pozycja_koncowa = new Vector2(transform.position.x - offsetX, transform.position.y-offsetY);
        Atak_Postaci();
    }
    private void Atak_Postaci()
    {
        var raycast = Physics2D.Raycast(transform.position+ new Vector3(0f,-offsetY), pozycja_koncowa, dystans, gracz);
        if(raycast.collider!=null && raycast.collider.tag=="Player")
        {
            animator.SetBool("atak", true);            
        }
        else 
        {
            animator.SetBool("atak", false);
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawLine(transform.position + new Vector3(0f, -offsetY), pozycja_koncowa);
    }
}
