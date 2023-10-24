using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator _animator;
    private PlayerInput _input;

    private StanceInfo.CombatStance _lastStance;

    private bool _hitHappened = false;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _input = GetComponent<PlayerInput>();

        _input.OnHit += Hit;
        _input.OnStanceChange += ChangeStance;

        _lastStance = StanceInfo.CombatStance.Langort;
    }

    private void Update()
    {
        _animator.SetFloat("HorizontalSpeed", _input.Horizontal);
    }

    private void Hit()
    {
        ResetTriggers();

        _animator.SetTrigger("Attack");
        _hitHappened = true;
    }

    private void ChangeStance()
    {
        float angle = Vector2.SignedAngle(Vector2.up, new Vector2(transform.position.x, transform.position.y) - _input.WorldMousePos);
        var stance = StanceInfo.Instance.GetStanceByAngle(angle);

        if (stance == _lastStance && !_hitHappened)
            return;

        ResetTriggers();

        _lastStance = stance;
        switch (stance)
        {
            case StanceInfo.CombatStance.Tag:
                _animator.SetTrigger("Tag");
                break;
            case StanceInfo.CombatStance.Langort:
                _animator.SetTrigger("Langort");
                break;
            case StanceInfo.CombatStance.Pflug:
                _animator.SetTrigger("Pflug");
                break;
            default:
                throw new System.Exception("Stance is not considered in animation! Please check switch-case statements");
        }

        _hitHappened = true;
    }

    private void ResetTriggers()
    {
        _animator.ResetTrigger("Tag");
        _animator.ResetTrigger("Langort");
        _animator.ResetTrigger("Pflug");

        _animator.ResetTrigger("Attack");
    }


}
