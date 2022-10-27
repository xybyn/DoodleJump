using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class FollowingCamera : MonoBehaviour
{
    [SerializeField]
    private Transform _targetTransform;

    [SerializeField]
    private float _interpolationSpeed = 4f;

    [SerializeField]
    private float _verticalOffset = 4f;

    private float _maxHeight = 0.0f;

    private Vector3 _cachedPosition;
    // Start is called before the first frame update
    void Start()
    {
        _cachedPosition = transform.position;
        Restart();
    }

    public void Restart()
    {
        _maxHeight = _cachedPosition.y - _verticalOffset;
        transform.position = _cachedPosition;
    }

    // Update is called once per frame

    void Update()
    {
        if (_targetTransform == null)
            return;
        _maxHeight = Mathf.Max(_targetTransform.position.y - _verticalOffset, _maxHeight);
        Vector3 targetPosition = new Vector3(transform.position.x, _maxHeight, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetPosition, _interpolationSpeed * Time.deltaTime);
    }
}
