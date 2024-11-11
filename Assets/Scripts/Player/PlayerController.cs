using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float moveDistance = 1f;
    public float moveSpeed = 5f;
    private Vector3 targetPosition;
    private bool shouldMove = false;

    private void Awake()
    {
        targetPosition = transform.position;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            Vector2 input = context.ReadValue<Vector2>();
            Vector3 direction = new Vector3(input.x, 0, input.y).normalized;

            if (direction != Vector3.zero)
            {
                targetPosition = transform.position + direction * moveDistance;
                shouldMove = true;

                if (input == Vector2.up) // W 
                {
                    transform.rotation = Quaternion.Euler(0, 0, 0);
                    DataManager.Instance.RowCount++;
                    return;
                }
                if (input == Vector2.left) // A
                {
                    transform.rotation = Quaternion.Euler(0, -90, 0);
                    return;
                }
                else  // D
                {
                    transform.rotation = Quaternion.Euler(0, 90, 0);
                    return;
                }
            }
        }
    }

    private void FixedUpdate()
    {
        if (shouldMove)
        {
            Vector3 newPosition = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.fixedDeltaTime);
            transform.position = newPosition;

            if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
            {
                transform.position = targetPosition;
                shouldMove = false;
            }
        }
    }
}
