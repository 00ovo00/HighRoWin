using UnityEngine;

public class MovingObject : MonoBehaviour
{ 
    private float speed;
    private float _direction;

    public void Initialize(float movementDirection, float objectSpeed)
    {
        // 이동 방향과 속력 초기화
        _direction = movementDirection;
        speed = objectSpeed;
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