using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoxinhaGraphics : MonoBehaviour
{
    private Transform _coxinhaTransform;
    public Transform player;

    private void Start()
    {
        _coxinhaTransform = gameObject.GetComponent<Transform>();
    }

    private void Update()
    {
        transform.localScale = player.position.x > _coxinhaTransform.position.x
            ? new Vector3(-1.262974f, 1.438251f, 1f)
            : new Vector3(1.262974f, 1.438251f, 1f);
    }
}