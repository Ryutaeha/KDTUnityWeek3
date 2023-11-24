using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class AimRotation : MonoBehaviour
{

    float flipX;
    private PlayerController _controller;

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
        if (direction.x > 0) transform.localScale = new Vector3(-flipX, transform.localScale.y, transform.localScale.z);
        else if(direction.x < 0) transform.localScale = new Vector3(flipX, transform.localScale.y, transform.localScale.z);
        /*
            if (Mathf.Abs(rotZ) > 90f) player.localScale = new Vector3(player.localScale.x * -1, player.localScale.y, player.localScale.z) ;
            else player.localScale = new Vector3(player.localScale.x * -1, player.localScale.y, player.localScale.z) ;
         */
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
