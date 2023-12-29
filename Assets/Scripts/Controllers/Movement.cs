using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private CharacterController _characterController;

    private Vector2 _movemnetDirection = Vector2.zero;
    private Rigidbody2D _rigidbody;
    private SpriteRenderer _mainSprite;

    private float _acceleration = 1f;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _mainSprite = GetComponentInChildren<SpriteRenderer>();
    }

    private void Start()
    {
        _characterController.OnMoveEvent += Move;
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            _acceleration = 2f;
        }
        else
        {
            _acceleration = 1f;
        }
        ApplyMovement(_movemnetDirection);
    }

    private void Move(Vector2 direction)
    {
        _movemnetDirection = direction;
        if (_movemnetDirection.x != 0)
        {
            _mainSprite.flipX = _movemnetDirection.x > 0 ? false : true;
        }
    }

    private void ApplyMovement(Vector2 direction)
    {
        direction = direction * 5 * _acceleration;
        _rigidbody.velocity = direction;
    }
}
