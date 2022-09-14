using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatataBossBehavior : Enemy
{
    public GameObject refrigerante;
    public Vector3 refriUpPosition;
    public Vector3 refriDownPosition;
    public float refriMoveSpeed=3f;
    void Start()
    {
    }

    private void FixedUpdate()
    {
        // LevantaRefrigerante();
    }

    private void LevantaRefrigerante()
    {
        Vector3 refriPos = refrigerante.transform.position;
        refrigerante.transform.position =
            Vector3.MoveTowards(refriPos, refriUpPosition, refriMoveSpeed * Time.fixedDeltaTime);
    }

    private void AbaixaRefrigerante()
    {
        refrigerante.transform.position =
            Vector3.MoveTowards(refrigerante.transform.position, refriDownPosition, 0.1f);
    }
}