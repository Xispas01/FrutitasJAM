using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golpe : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
 
        {

        if (collision.tag == "enemy") { 

        ITargeteable tmp = collision.gameObject.GetComponent<ITargeteable>();
        tmp.TakeDamage(); }
    }
 }
