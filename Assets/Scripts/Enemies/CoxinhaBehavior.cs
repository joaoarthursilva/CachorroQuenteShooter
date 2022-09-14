using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CoxinhaBehavior : Enemy
{
    public GameObject player;
    public int moveSpeed;

    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.TryGetComponent(out PlayerHealth _playerHealth))
            _playerHealth.TakeDamage(enemyDamage);
    }
    
    // Update is called once per frame
    void FixedUpdate()
    {
        float playerPos = player.transform.position.x;
        Vector3 enemyPos = transform.position;
        Vector2 targetPos = new Vector2(playerPos, enemyPos.y);
        // transform.position = Vector2.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
        
        
        Vector2 position = Vector2.MoveTowards(enemyPos, targetPos, moveSpeed * Time.fixedDeltaTime);
        rb.MovePosition(position);
        
    }


}
