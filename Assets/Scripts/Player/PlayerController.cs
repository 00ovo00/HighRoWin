using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;
    private Vector2 curMovementInput;

    private Rigidbody rigidbody;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Move();        
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        // 키 처음 눌린 상태
        // if (context.phase == InputActionPhase.Started)
        // 계속해서 키 입력되므로 Performed 사용
        // 키 눌린 상태
        if (context.phase == InputActionPhase.Performed)
        {
            curMovementInput = context.ReadValue<Vector2>();
        }
        // 키 눌리지 않은 상태
        else if (context.phase == InputActionPhase.Canceled)
        {
            curMovementInput = Vector2.zero;    // 이동 중지
        }
    }
    
    private void Move()
    {
        Vector3 dir = transform.forward * curMovementInput.y + transform.right * curMovementInput.x;
        dir *= moveSpeed;
        rigidbody.velocity = dir;
    }
}