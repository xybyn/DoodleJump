using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using static UnityEngine.GraphicsBuffer;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerInputController : MonoBehaviour
{
    [SerializeField]
    private float _horizontalMoveSpeed = 100.0f;

    [SerializeField]
    private float _verticalMoveSpeed = 10.0f;

    [SerializeField]
    private GameBorders _gameBorders = null;

    [Inject] private IInput _input = null;

    private Rigidbody2D _rb;


    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        float value = _input.GetHorizontalRaw();
        _rb.velocity = new Vector2(_horizontalMoveSpeed * value, _rb.velocity.y);
        if (_gameBorders != null)
        {
            if (_gameBorders.IntersectsLeftBorder(_rb.transform) && Vector2.Dot(_rb.velocity, Vector2.left) > 0 )
            {
                _rb.transform.position = new Vector2(_gameBorders.RightBorderPosition.x, _rb.position.y);
            }
            else if (_gameBorders.IntersectsRightBorder(_rb.transform) && Vector2.Dot(_rb.velocity, Vector2.right) > 0)
            {
                _rb.transform.position = new Vector2(_gameBorders.LeftBorderPosition.x, _rb.position.y);
            }
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //_rb.AddForce(Vector2.up * 500);
        _rb.velocity = new Vector2(_rb.velocity.x, _verticalMoveSpeed);
    }
    private void OnDrawGizmos()
    {
        if (_rb == null)
            return;
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, new Vector2(transform.position.x, transform.position.y) +  _rb.velocity);
    }
}
