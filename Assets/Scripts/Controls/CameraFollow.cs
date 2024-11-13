using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform player;
    private Vector3 _offset;

    private void Start()
    {
        _offset = transform.position - player.position;
    }

    private void LateUpdate()
    {
        if (player != null)
        {
            transform.position = player.position + _offset;
        }
    }
}