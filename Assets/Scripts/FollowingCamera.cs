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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition = new Vector3(transform.position.x, _targetTransform.position.y - _verticalOffset, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetPosition, _interpolationSpeed * Time.deltaTime);
    }
}
