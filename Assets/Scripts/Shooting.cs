using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private Transform _gunPivot;
    [SerializeField] private Transform _firePoint;
    public Camera cam;
    private Vector2 _mousePos;
    public GameObject bulletPrefab;
    private GameObject _bullet;
    public float bulletForce = 20f;
    private Rigidbody2D _rb;

    private void Start()
    {
    }

    void Update()
    {
        _mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        _bullet = Instantiate(bulletPrefab, _firePoint.position, _firePoint.rotation);
        _rb = _bullet.GetComponent<Rigidbody2D>();
        _rb.AddForce(_firePoint.right * bulletForce, ForceMode2D.Impulse);
    }

    private void FixedUpdate()
    {
        Vector2 lookDir = _mousePos - new Vector2(_gunPivot.position.x, _gunPivot.position.y);
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        transform.rotation = Quaternion.Euler(0f, 0f, angle + 90);
    }
}