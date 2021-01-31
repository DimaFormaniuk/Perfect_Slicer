using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using BzKovSoft.ObjectSlicerSamples;

public class Slicer : MonoBehaviour
{
    [SerializeField] private GameObject _blade;
    [SerializeField] private float _duration;
    [SerializeField] private float _durationDizziness;
    [SerializeField] private float _offsetY;

    private BzKnife _knife;
    private KnifeBlade _knifeBlade;
    private float tempTime;

    private void Awake()
    {
        _knife = _blade.GetComponentInChildren<BzKnife>();
        _knifeBlade = _blade.GetComponentInChildren<KnifeBlade>();
        tempTime = 0f;
    }

    private void Update()
    {
        tempTime += Time.deltaTime;
        if (Input.GetMouseButton(0))
        {
            if (tempTime > _duration)
            {
                Slice();
                tempTime = 0f;
            }
        }
    }

    private void Slice()
    {
        _knife.BeginNewSlice();

        _blade.transform.DOMoveY(_blade.transform.position.y - _offsetY, _duration / 2f).SetLoops(2, LoopType.Yoyo);
    }

    private void OnEnable()
    {
        _knifeBlade.OnDizziness += OnDizziness;
    }

    private void OnDisable()
    {
        _knifeBlade.OnDizziness -= OnDizziness;

    }

    private void OnDizziness()
    {
        tempTime = -_durationDizziness;
    }
}
