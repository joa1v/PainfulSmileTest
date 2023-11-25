using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsManager : MonoBehaviour
{
    public static int Points;

    public static void AddPoint()
    {
        Points++;
    }

    public static void ResetPoints()
    {
        Points = 0;
    }
}
