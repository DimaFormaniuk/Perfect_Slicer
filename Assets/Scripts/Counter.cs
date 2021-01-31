using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private DestroyFood _destroyFood;
    [SerializeField] private int _addValue;
    private int _scoreSum;

    private void Start()
    {
        _scoreSum = 0;
    }

    private void OnEnable()
    {
        _destroyFood.OnCountFood += OnAddValue;
    }

    private void OnDisable()
    {
        _destroyFood.OnCountFood -= OnAddValue;
    }

    private void OnAddValue()
    {
        _scoreSum += _addValue;
        Debug.Log("Score " + _scoreSum);
    }
}
