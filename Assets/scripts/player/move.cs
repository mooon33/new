using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    [SerializeField] private float _speedWalk;
    [SerializeField] private float _gravity;
    [SerializeField] private float _jumpPower;
    [SerializeField] private float _speedRun;
    [SerializeField] private float _runTime; // время бега
    [SerializeField] private float _delayTime; // время задержки

    private CharacterController _characterController;
    private Vector3 _walkDirection;
    private Vector3 _velocity;
    private float _speed;
    private float _currentRunTime; // текущее время бега
    private float _currentDelayTime; // текущее время задержки
    private bool _canRun; // флаг, может ли персонаж бежать

    private void Start()
    {
        _speed = _speedWalk;
        _characterController = GetComponent<CharacterController>();
        _canRun = true;
    }

    private void Update()
    {
        Jump(Input.GetKey(KeyCode.Space) && _characterController.isGrounded);
        Run(Input.GetKey(KeyCode.LeftShift));
        Sit(Input.GetKey(KeyCode.LeftControl));
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        _walkDirection = transform.right * x + transform.forward * z;
    }

    private void FixedUpdate()
    {
        Walk(_walkDirection);
        DoGravity(_characterController.isGrounded);
        CheckRunTime();
    }

    private void Walk(Vector3 direction)
    {
        _characterController.Move(direction * _speed * Time.fixedDeltaTime);
    }

    private void DoGravity(bool isGrounded)
    {
        if (isGrounded && _velocity.y < 0)
            _velocity.y = -1f;
        _velocity.y -= _gravity * Time.fixedDeltaTime;
        _characterController.Move(_velocity * Time.fixedDeltaTime);
    }

    private void Jump(bool canJump)
    {
        if (canJump)
            _velocity.y = _jumpPower;
    }

    private void Run(bool canRun)
    {
        if (_canRun)
        {
            _speed = canRun ? _speedRun : _speedWalk;
            if (canRun)
                _currentRunTime += Time.fixedDeltaTime;
        }
    }

    private void Sit(bool canSit)
    {
        _characterController.height = canSit ? 1f : 2f;
    }

    private void CheckRunTime()
    {
        if (_currentRunTime >= _runTime)
        {
            _currentRunTime = 0;
            _ = false;
            _currentDelayTime = 0;
        }
        if (!_canRun)
        {
            _currentDelayTime += Time.fixedDeltaTime;
            if (_currentDelayTime >= _delayTime)
            {
                _canRun = true;
            }
        }
    }
}