using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPositionTracker : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;
    public Vector3 PlayerPos => _playerTransform.position;
    public static PlayerPositionTracker Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
    }
}
