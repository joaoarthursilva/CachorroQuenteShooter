using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PastelMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public int velocidade;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 forca = new Vector2(-velocidade, 0);
        rb.AddForce(forca);
    }
}
