using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterEnemyGizmos : MonoBehaviour
{
    [SerializeField] private Color _gizmosColor = Color.magenta;
    [SerializeField] private ShooterEnemy _shooterEnemy;

    private void OnDrawGizmosSelected()
    {
        if (!_shooterEnemy)
            return;

        float radius = _shooterEnemy.DistanceToShoot;
        Gizmos.color = _gizmosColor;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
