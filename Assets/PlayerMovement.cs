using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float _speed= 0.25f;
    private float _rotSpeed= 80f;
    private float _gravity= 8f;
    private float _rot= 0;
    private Vector3 _moveDir = Vector3.zero;

    private CharacterController _controller;
    private Animator _animator;
    void Start()
    {
        _controller = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();
    }

    
    void Update()
    {
        if (_controller.isGrounded)
        {
            if (Input.GetKey(KeyCode.W))
            {
                _moveDir = new Vector3(0, 0, 1);
                _moveDir = _moveDir * _speed;
                _animator.SetBool("isWalk",true);
                transform.TransformDirection(_moveDir);
                
                if (Input.GetKey(KeyCode.LeftShift) )
                {
                    _animator.SetBool("isRun",true);
                }
                else
                {
                    _animator.SetBool("isRun",false);
                }
                
            }
            else
            {
                _moveDir = new Vector3(0, 0, 0);
                _animator.SetBool("isWalk",false);
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            _animator.SetBool("isAttack",true);
        }
        else
        {
            _animator.SetBool("isAttack", false);
        }

        if (Input.GetKey(KeyCode.C))
        {
            _animator.SetBool("isCrouch", true);
        }
        else
        {
            _animator.SetBool("isCrouch", false);
        }
            
           

        _rot += Input.GetAxis("Horizontal") * _rotSpeed * Time.deltaTime;
        transform.eulerAngles = new Vector3(0, _rot, 0);

        _moveDir.y -= _gravity * Time.deltaTime;
        _controller.Move(_moveDir * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pole"))
        {
            _animator.SetBool("isDead",true);
        }
    }
}
