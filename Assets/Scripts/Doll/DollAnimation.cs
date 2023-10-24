using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DollAnimation : MonoBehaviour
{
    private CollisionDetector _collisionDetector;
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();

        _collisionDetector = GetComponent<CollisionDetector>();
        _collisionDetector.OnCollision += GotHit;
    }

    private void GotHit(Collision2D collision)
    {
        _animator.SetTrigger("GotHit");
    }


}
