using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speedWalk;
    [SerializeField] private float _gravity;
    [SerializeField] private float _jumpPower;
    [SerializeField] private float _speedRun;

    private CharacterController _characterController;
    private Vector3 _walkDirection;
    private Vector3 _velocity;
    private float _speed;
    private bool _canRun = true;
    private float _runTime = 5f;
    private float _delayTime = 5f;

    private void Start()
    {
        _speed = _speedWalk;
        _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Jump(Input.GetKey(KeyCode.Space) && _characterController.isGrounded);
        Sit(Input.GetKey(KeyCode.LeftControl));

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // Получаем направление взгляда камеры
        Vector3 forward = Camera.main.transform.forward;
        Vector3 right = Camera.main.transform.right;

        // Убираем влияние вертикального перемещения
        forward.y = 0;
        right.y = 0;
        forward.Normalize();
        right.Normalize();

        // Рассчитываем направление движения с учетом поворота камеры
        _walkDirection = (forward * z + right * x).normalized;

        // Проверяем, можно ли бежать и нажата ли клавиша Shift
        if (_canRun && Input.GetKey(KeyCode.LeftShift))
        {
            StartCoroutine(RunAndDelay());
        }
    }

    private void FixedUpdate()
    {
        Walk(_walkDirection);
        DoGravity(_characterController.isGrounded);
    }

    private void Walk(Vector3 direction)
    {
        _characterController.Move(direction * _speedWalk * Time.fixedDeltaTime);
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

    private void Sit(bool canSit)
    {
        _characterController.height = canSit ? 1f : 2f;
    }

    private IEnumerator RunAndDelay()
    {
        _canRun = false;
        _speedWalk = _speedRun;
        yield return new WaitForSeconds(_runTime);
        _speedWalk = _speed;
        yield return new WaitForSeconds(_delayTime);
        _canRun = true;
    }
}