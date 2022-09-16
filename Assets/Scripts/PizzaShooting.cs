using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaShooting : MonoBehaviour
{
    [SerializeField] private Transform gunPivot;
    [SerializeField] private Transform firePoint;
    [SerializeField] private Transform player;
    public Camera cam;
    private Vector2 _playerRelativePos;
    public GameObject bulletPrefab;
    private GameObject _bullet;
    public float bulletForce = 20f;
    private Rigidbody2D _rb;
    private Vector3 _targetPos;
    private void Start()
    {
        _targetPos = player.position;
    }

    void Update()
    {
        _playerRelativePos = cam.ScreenToWorldPoint(_targetPos);
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        _bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        _rb = _bullet.GetComponent<Rigidbody2D>();
        _rb.AddForce(firePoint.right * bulletForce, ForceMode2D.Impulse);
    }

    private void FixedUpdate()
    {
        var position = gunPivot.position;
        Vector2 lookDir = _playerRelativePos - new Vector2(position.x, position.y);
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        transform.rotation = Quaternion.Euler(0f, 0f, angle + 90);
    }
}