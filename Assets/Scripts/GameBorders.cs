using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameBorders : MonoBehaviour
{
    [SerializeField]
    private Transform _leftBorder = null;

    [SerializeField]
    private Transform _rightBorder = null;

    public Vector2 LeftBorderPosition => _leftBorder.position;
    public Vector2 RightBorderPosition => _rightBorder.position;

    public bool IntersectsRightBorder(Transform transform)
    {
        if (transform == null)
            return false;

        return transform.position.x >= _rightBorder.position.x;
    }
    public bool IntersectsLeftBorder(Transform transform)
    {
        if (transform == null)
            return false;

        return transform.position.x <= _leftBorder.position.x;
    }
}
