using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMoveable
{
    public int Speed { get; set; }
    public Rigidbody2D Rb { get; }
    public void Move();
    public void Stop();
}
