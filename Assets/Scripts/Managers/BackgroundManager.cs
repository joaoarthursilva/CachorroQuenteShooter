using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    private float _length, _startPos;
    public Camera cam;
    public float effect;
    void Start()
    {
        _startPos = transform.position.x;
        _length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void FixedUpdate()
    {
        float dist = (cam.transform.position.x * effect);

        transform.position = new Vector3(_startPos + dist, 0, transform.position.z);
    }
}