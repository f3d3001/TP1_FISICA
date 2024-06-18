using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoExplosivo : MonoBehaviour
{
    public float radioExplosion;
    public float fuerzaExplosion;
    public LayerMask impacto;

    void OnCollisionEnter2D(Collision2D collision)
    {
        Explode();
    }

    void Explode()
    {
        Collider2D[] objects = Physics2D.OverlapCircleAll(transform.position, radioExplosion, impacto);
        foreach (Collider2D obj in objects)
        {
            Rigidbody2D rb = obj.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                Vector2 direction = rb.transform.position - transform.position;
                rb.AddForce(direction.normalized * fuerzaExplosion, ForceMode2D.Impulse);
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radioExplosion);
    }
}