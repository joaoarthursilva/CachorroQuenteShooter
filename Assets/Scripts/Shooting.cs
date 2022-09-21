using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Shooting : MonoBehaviour
{
    [FormerlySerializedAs("_gunPivot")] [SerializeField] private Transform gunPivot;
    [FormerlySerializedAs("_firePoint")] [SerializeField] private Transform firePoint;
    public Camera cam;
    private Vector2 _mousePos;
    public GameObject bulletPrefab;
    private GameObject _bullet;
    public float bulletForce = 20f;
    private Rigidbody2D _rb;
    public float fireRate = 0.5F;
    private float _nextFire = 0.0F;

    private void Start()
    {
    }

    private void Update()
    {
        _mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    private void Shoot()
    {
        _bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        _rb = _bullet.GetComponent<Rigidbody2D>();
        _rb.AddForce(firePoint.right * bulletForce, ForceMode2D.Impulse);
    }

    private void FixedUpdate()
    {
        Vector3 position = gunPivot.position;
        Vector2 lookDir = _mousePos - new Vector2(position.x, position.y);
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        transform.rotation = Quaternion.Euler(0f, 0f, angle + 90);
        if (CanShoot())
        {
            _nextFire = Time.time + fireRate;
            Shoot();
        }
    }

    private bool CanShoot()
    {
        return Input.GetButton("Fire1") && Time.time > _nextFire;
    }
}