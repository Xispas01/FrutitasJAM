using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golpe : MonoBehaviour
{
    public Rigidbody2D rb;
    public PlayerMovementSwapkey go;
    ITargeteable tmp;

    private void Start()
    {
        go = GetComponentInParent<PlayerMovementSwapkey>();

    }
    private void OnTriggerEnter2D(Collider2D collision)
        
        {
        
        rb = collision.GetComponent<Rigidbody2D>();
        if (collision.tag == "enemy") {
            
            if (go.MA)
            {
                rb.AddForce(go.fuerza * Vector2.up);
            }
            else if (go.MB) {
                rb.AddForce(go.fuerza * Vector2.down);
            }
            else if (go.MD) {
                rb.AddForce(go.fuerza * Vector2.right);
            }
            else if (go.MI) {
                rb.AddForce(go.fuerza * Vector2.left);
            }
            tmp= collision.gameObject.GetComponent<ITargeteable>();
            tmp.TakeDamage();

        }
    }
 }
