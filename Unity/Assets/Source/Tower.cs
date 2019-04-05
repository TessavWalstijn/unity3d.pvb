﻿using System.Collections.Generic;
using UnityEngine;

public abstract class Tower : MonoBehaviour
{

    [Header("Targeting")]
    
        [SerializeField]
   protected float _damage;
   [SerializeField]
    protected float _tickSpeed;
    [SerializeField]
    protected float _minimalShootAngle;
    [SerializeField]
    protected float targetRadius;
    [SerializeField]
    protected float rotationSpeed;
    [SerializeField]
    private LayerMask _layer;

    private bool _hasTarget;
    protected List<GameObject> targetsInRange;

    protected abstract void _OnTargetEnter();
    protected abstract bool _OnTargetStay();
    protected abstract void _OnTargetExit();

    protected virtual void Start()
    {
        targetsInRange = new List<GameObject>();
    }

    protected virtual void Update()
    {
        var cols = Physics.OverlapSphere(transform.position, targetRadius, _layer);
        targetsInRange.Clear();

        foreach (var col in cols)
        {
            targetsInRange.Add(col.gameObject);
        }

        if (!_hasTarget)
        {
            if (targetsInRange.Count <= 0) return;
            _OnTargetEnter();
            _hasTarget = true;
            print("Has Target");
        }
        else
        {
            if (!_OnTargetStay())
            {
                _OnTargetExit();
                _hasTarget = false;
                print("Lost target");
            }
        }
    }

    private void _OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, targetRadius);
    }
}