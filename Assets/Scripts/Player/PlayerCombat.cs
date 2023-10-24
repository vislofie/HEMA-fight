using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public StanceInfo.CombatStance Stance { get; private set; }

    [SerializeField]
    private CollisionDetector _swordHitbox;
    private PlayerInput _input;

    private void Awake()
    {
        _input = GetComponent<PlayerInput>();

        Stance = StanceInfo.CombatStance.Langort;
        _input.OnStanceChange += ChangeStance;
    }

    private void ChangeStance()
    {
        float angle = Vector2.SignedAngle(Vector2.up, new Vector2(transform.position.x, transform.position.y) - _input.WorldMousePos);

        Stance = StanceInfo.Instance.GetStanceByAngle(angle);
    }
}
