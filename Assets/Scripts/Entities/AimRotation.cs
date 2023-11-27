using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;

public class AimRotation : MonoBehaviour
{

    float flipX;
    private PlayerController _controller;
    [SerializeField] private Canvas nameTag;

    private void Awake()
    {
        flipX = transform.localScale.x;
        _controller = GetComponent<PlayerController>();
    }

    // Start is called before the first frame update
    void Start()
    {
        _controller.OnLookEvent += OnAim;
    }

    void OnAim(Vector2 newAimDirection)
    {
        RotationAim(newAimDirection);
    }
    void RotationAim(Vector2 direction)
    {
        //Debug.Log(direction.x);

        float rotZ = MathF.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        if (direction.x > 0)
        {
            transform.localScale = new Vector3(-flipX, transform.localScale.y, transform.localScale.z);
            nameTag.transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (direction.x < 0)
        {
            transform.localScale = new Vector3(flipX, transform.localScale.y, transform.localScale.z);
            nameTag.transform.localScale = new Vector3(1, 1, 1);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
    public void AimSet(bool move)
    {
        if (move) _controller.OnLookEvent += OnAim;
        else _controller.OnLookEvent -= OnAim;
    }
}
