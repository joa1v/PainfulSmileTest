using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ScreenEdgeColliders : MonoBehaviour
{
    [SerializeField] private EdgeCollider2D _collider;
    private void Awake()
    {
        AddColliders();
    }

    private void AddColliders()
    {
        Camera cam = Camera.main;

        Vector2 bottomLeft = cam.ScreenToWorldPoint(new Vector3(0, 0, cam.nearClipPlane));
        Vector2 topLeft = cam.ScreenToWorldPoint(new Vector3(0, cam.pixelHeight, cam.nearClipPlane));
        Vector2 topRight = cam.ScreenToWorldPoint(new Vector3(cam.pixelWidth, cam.pixelHeight, cam.nearClipPlane));
        Vector2 bottomRight = cam.ScreenToWorldPoint(new Vector3(cam.pixelWidth, 0, cam.nearClipPlane));

        var edgePoints = new[] { bottomLeft, topLeft, topRight, bottomRight, bottomLeft };
        _collider.points = edgePoints;
    }
}