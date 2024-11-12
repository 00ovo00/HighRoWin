using UnityEngine;

public class ParticleController : MonoBehaviour
{
    private ParticleSystem glowEffect;

    private void Awake()
    {
        glowEffect = GetComponent<ParticleSystem>();
    }
    
    private void Start()
    {
        if (glowEffect != null) glowEffect.Stop();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && glowEffect != null)
        {
            glowEffect.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && glowEffect != null)
        {
            glowEffect.Stop();
        }
    }
}