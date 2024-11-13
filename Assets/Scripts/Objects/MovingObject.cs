using System;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
    [SerializeField] private float speed;
    private float _direction;

    public void Initialize(float movementDirection)
    {
        // 이동 방향과 속력 초기화
        speed = 5.0f;
        _direction = movementDirection;
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector3.right * _direction * speed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Player entered");
            GameManager.Instance.GameOver();
            SoundManager.Instance.PlayCollsionSFX();
        }
    }
}