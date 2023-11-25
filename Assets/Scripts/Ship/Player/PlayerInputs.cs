using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputs : MonoBehaviour
{
    private bool _moveShip;
    private float _x;

    public bool MoveShip => _moveShip;
    public float X { get => _x; set => _x = value; }

    public delegate void LeftMouseButtonPressEventHandler();
    public delegate void RightMouseButtonPressEventHandler();

    public event LeftMouseButtonPressEventHandler OnLeftMouseButtonPressed;
    public event RightMouseButtonPressEventHandler OnRightMouseButtonPressed;

    private void Update()
    {
        _moveShip = Input.GetAxisRaw("Vertical") > 0;

        _x = Input.GetAxisRaw("Horizontal");

        bool leftMouseButton = Input.GetMouseButtonDown(0);
        bool rightMouseButton = Input.GetMouseButtonDown(1);

        if (leftMouseButton)
        {
            OnLeftMouseButtonPressed?.Invoke();
        }

        if (rightMouseButton)
        {
            OnRightMouseButtonPressed?.Invoke();
        }
    }

}
