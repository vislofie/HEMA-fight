using UnityEngine;
using System;

public class CollisionDetector : MonoBehaviour
{
    [SerializeField]
    private LayerMask _layersToInteractWith;

    public event Action<Collision2D> OnCollision = delegate { };

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((_layersToInteractWith.value & (1 << collision.gameObject.layer)) != 0)
        {
            OnCollision(collision);
        }    
            
    }
}
