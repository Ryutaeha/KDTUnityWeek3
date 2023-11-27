using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Movement : MonoBehaviour
{

    private PlayerController _controller;
    private Animator _animator;
    private Vector2 _movementDirection = Vector2.zero;
    private Rigidbody2D _rigidbody;

    [SerializeField] private float moveSpeed;

    private void Awake()
    {
        _controller = GetComponent<PlayerController>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        
        _controller.OnMoveEvent += Move;;
    }
     
    private void FixedUpdate()
    {
        ApplyMovoment(_movementDirection);
    }

    internal void Move(Vector2 direction)
    {
        _movementDirection = direction;
    }

    private void ApplyMovoment(Vector2 direction)
    {
        direction = direction * moveSpeed;
        _rigidbody.velocity = direction;

        if (!direction.Equals(Vector2.zero)) _animator.SetFloat("RunState", 0.5f);
        else _animator.SetFloat("RunState", 0.0f);
    }

    public void MoveSet(bool move)
    {
        if (move) _controller.OnMoveEvent += Move;
        else
        {
            Move(Vector2.zero);
            _controller.OnMoveEvent -= Move;
        }
    }
}
