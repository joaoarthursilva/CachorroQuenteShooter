using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoxinhaBehavior : Enemy
{
    public GameObject player;
    public int moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void FixedUpdate()
    {
        float playerPos = player.transform.position.x;
        var targetPos = new Vector2(playerPos, transform.position.y);
        transform.position = Vector2.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
    }


}
