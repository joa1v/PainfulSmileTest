using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAreaGizmos : MonoBehaviour
{
    [SerializeField] private Color _gizmosColor = Color.red;
    [SerializeField] private SpawnArea _spawnArea;

    private void OnDrawGizmosSelected()
    {
        if (!_spawnArea)
            return;

        Vector2 max = _spawnArea.GetMaxLimits();
        Vector2 min = _spawnArea.GetMinLimits();

        Gizmos.color = _gizmosColor;

        Gizmos.DrawLine(new Vector3(min.x, max.y, 0), new Vector3(max.x, max.y, 0));
        Gizmos.DrawLine(new Vector3(max.x, max.y, 0), new Vector3(max.x, min.y, 0));
        Gizmos.DrawLine(new Vector3(max.x, min.y, 0), new Vector3(min.x, min.y, 0));
        Gizmos.DrawLine(new Vector3(min.x, min.y, 0), new Vector3(min.x, max.y, 0));
    }
}
