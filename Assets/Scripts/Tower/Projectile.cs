using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int damage;
    public float speed;
    public Vector2 direction;
    private Rigidbody2D rb;
    public TowerController Parent;
    // Start is called before the first frame update
    void Start()
    {
        Parent = GetComponentInParent<TowerController>();
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = direction * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
