using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipProjScript : MonoBehaviour
{

    public float speed;
    public Rigidbody2D myrb;

    void Start()
    {
        myrb.velocity = transform.right * speed;

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Alien")
        {
            Destroy(gameObject);
        }

    }

    void Update()
    {
        if (transform.position.x > 9)
        {
            Destroy(gameObject);
        }
    }
}
