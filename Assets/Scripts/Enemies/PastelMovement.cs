using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PastelMovement : Enemy
{
    private Rigidbody2D rb;
    public int velocidade;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.TryGetComponent(out PlayerHealth _playerHealth))
            _playerHealth.TakeDamage(enemyDamage);
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 forca = new Vector2(-velocidade, 0);
        rb.AddForce(forca);
    }
}