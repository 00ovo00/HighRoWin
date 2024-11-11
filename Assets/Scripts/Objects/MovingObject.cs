using System;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
    public float speed;
    private float direction;

    public void Initialize(float movementDirection)
    {
        // 이동 방향과 속력 초기화
        speed = 5.0f;
        direction = movementDirection;
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector3.right * direction * speed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Player entered");
            GameManager.Instance.GameOver();
        }
    }
}