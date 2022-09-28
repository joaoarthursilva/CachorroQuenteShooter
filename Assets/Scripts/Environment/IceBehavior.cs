using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class IceBehavior : MonoBehaviour
{
    public float timeToMelt;
    public GameObject geloSprite;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.gameObject.CompareTag("Player")) return;
        //começa a destruir
        //comeca animacao
        Debug.Log("entrou");
    }
}