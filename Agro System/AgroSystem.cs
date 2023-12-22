using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

[RequireComponent(typeof(SphereCollider))]
public class AgroSystem : MonoBehaviour
{
    [SerializeField] private bool _drawGizmos = false;
    [SerializeField] [Range(1.0f, 100.0f)] private float _agroRange = 5.0f;
    private SphereCollider _sphereCollider;
    private List<Transform> _transforms = new List<Transform>();

    public float AgroRange
    {
        get { return _agroRange; }
        set { _agroRange = value; _sphereCollider.radius = _agroRange; }
    }

    private void Awake()
    {
        _sphereCollider = GetComponent<SphereCollider>();
    }

    private void Start()
    {
        _sphereCollider.radius = _agroRange;
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.TryGetComponent(out MonoBehaviour monoBehaviour))
            if (monoBehaviour.GetType().IsDefined(typeof(AgroableAttribute), false))
                AddTransform(other.gameObject.transform);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent(out MonoBehaviour monoBehaviour))
            if (monoBehaviour.GetType().IsDefined(typeof(AgroableAttribute), false))
                RemoveTransform(other.gameObject.transform);
    }

    public void AddTransform(Transform transform)
    {
        if (transform != null && !_transforms.Contains(transform))
            _transforms.Add(transform);
    }

    public void RemoveTransform(Transform transform)
    {
        if (transform != null && _transforms.Contains(transform))
            _transforms.Remove(transform);
    }

    public Transform GetFirstTransform() => _transforms != null && _transforms.Count > 0 ? _transforms[0] : null;

    public List<Transform> GetMultipleTransform(int amount)
    {
        List<Transform> returnList = new List<Transform>();
        for (int i = 0; i < Mathf.Min(amount, _transforms.Count); i++)
            returnList.Add(_transforms[i]);
        return returnList;
    }

    private void OnDrawGizmos() 
    {
        if (_drawGizmos)
            Gizmos.DrawWireSphere(transform.position, _agroRange);
    }
}