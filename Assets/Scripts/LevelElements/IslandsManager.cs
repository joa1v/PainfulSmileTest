using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IslandsManager : MonoBehaviour
{
    [SerializeField] private GameObject[] _islandsSets;
    private void Awake()
    {
        EnableRandomIslandSet();
    }
    private void EnableRandomIslandSet()
    {
        int randomId = Random.Range(0, _islandsSets.Length);
        _islandsSets[randomId].SetActive(true);
    }
}
