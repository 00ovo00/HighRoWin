using UnityEngine;

public class AnimationController : MonoBehaviour
{
    protected Animator Animator;
    protected PlayerController Controller;

    protected virtual void Awake()
    {
        Animator = GetComponentInChildren<Animator>();
        Controller = GetComponent<PlayerController>();
    }
}