using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StanceInfo : MonoBehaviour
{
    private static StanceInfo _instance;
    public static StanceInfo Instance
    {
        get
        {
            if (_instance == null)
                _instance = FindObjectOfType<StanceInfo>();
            return _instance;
        }
    }

    public enum CombatStance { Tag, Langort, Pflug }

    [SerializeField]
    private StanceParameters[] _stanceParameters;

    public CombatStance GetStanceByAngle(float angle)
    {
        CombatStance stance;

        if (angle < -90)
        {
            angle += 360;
        }

        foreach (var stanceParam in _stanceParameters)
        {
            if (angle >= stanceParam.AngleStart && angle <= stanceParam.AngleEnd)
            {
                stance = stanceParam.StanceType;
                return stance;
            }
        }

        throw new System.Exception("Cannot find a stance by given angle " + angle + "! Check ScriptableObject info and input angle!");
    }
}
