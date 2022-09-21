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
    public float shootDelay = 2f;
    private float _shootDelayCounter;
    
    private void Start()
    {        
    }

    private void Update()
    {
        _mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    private void Shoot()
    {
        _bullet = Instantiate(bulletPrefab, _firePoint.position, _firePoint.rotation);
        _rb = _bullet.GetComponent<Rigidbody2D>();
        _rb.AddForce(_firePoint.right * bulletForce, ForceMode2D.Impulse);
    }

    private void FixedUpdate()
    {
        Vector3 position = _gunPivot.position;
        Vector2 lookDir = _mousePos - new Vector2(position.x, position.y);
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        transform.rotation = Quaternion.Euler(0f, 0f, angle + 90);
        // Debug.Log(_shootDelayCounter);
        if (canShoot())
        {
                Shoot();
                // _shootDelayCounter = shootDelay;
        }
        if(_shootDelayCounter>0f)
            _shootDelayCounter -= Time.deltaTime;
    }

    private bool canShoot()
    {
        return Input.GetButton("Fire1"); //&& _shootDelayCounter>0f;
    }
}