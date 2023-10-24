using System;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public float Horizontal { get; private set; }
    public Vector2 WorldMousePos { get; private set; }

    public event Action OnHit = delegate { };
    public event Action OnStanceChange = delegate { };

    private void Update()
    {
        Horizontal = Input.GetAxis("Horizontal");

        WorldMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
            OnHit();

        if (Input.GetKeyDown(KeyCode.C))
            OnStanceChange();
    }
}
