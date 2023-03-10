using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    private Rigidbody2D _rigidbody2D;
    private Vector2 _moveDirection;
    private Vector2 _mousePosition;
    private Animator _animator;
    public Weapon weapon;
    
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        _moveDirection.x = Input.GetAxisRaw("Horizontal");
        _moveDirection.y = Input.GetAxisRaw("Vertical");
        _mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _moveDirection.Normalize();

        if (Input.GetButton("Fire1"))
        {
            Shoot();
        }
    }

    private void FixedUpdate()
    {
        RotateToMousePosition();
        Move(); 
    }

    public void RotateToMousePosition()
    {
        Vector2 lookToMousePos = _mousePosition - _rigidbody2D.position;
        transform.right = new Vector2(lookToMousePos.x, lookToMousePos.y);
    }

    public void Move()
    { 
        if (_moveDirection != Vector2.zero)
        {
            _animator.SetBool("Move", true);
        }
        else
        {
            _animator.SetBool("Move", false);
        }
        _rigidbody2D.MovePosition(_rigidbody2D.position + _moveDirection * moveSpeed * Time.fixedDeltaTime);
    }

    public void Shoot()
    {
        weapon.Shoot();
    }
}