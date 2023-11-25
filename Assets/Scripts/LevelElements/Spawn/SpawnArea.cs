using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnArea : MonoBehaviour
{
    [Header("X")]
    [SerializeField] private float _minX;
    [SerializeField] private float _maxX;
    [Header("Y")]
    [SerializeField] private float _minY;
    [SerializeField] private float _maxY;

    public Vector2 GetMinLimits()
    {
        return new Vector2(_minX, _minY);
    }

    public Vector2 GetMaxLimits()
    {
        return new Vector2(_maxX, _maxY);
    }
}
