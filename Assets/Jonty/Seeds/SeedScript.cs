using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedScript : MonoBehaviour
{
    public GameObject Plant;
    public bool collided;
    public string SeedName;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Collideable")
        {
            if (GetComponent<Collider2D>().bounds.Intersects(collision.collider.bounds))
                collided = true;
        }
        else
            collided = false;
    }
}


