using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New StanceParams", menuName = "ScriptableObjects/Character Parameters/Stance Parameters", order = 1)]
public class StanceParameters : ScriptableObject
{
    [SerializeField]
    private StanceInfo.CombatStance _stanceType;
    [SerializeField]
    private float _angleStart;
    [SerializeField]
    private float _angleEnd;

    public StanceInfo.CombatStance StanceType => _stanceType;
    public float AngleStart => _angleStart;
    public float AngleEnd => _angleEnd;
}
