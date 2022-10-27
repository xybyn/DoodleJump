using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;
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

    public UnityEvent OnPlayerDied = new UnityEvent();
    public UnityEvent<float> OnNewHeightReached = new UnityEvent<float>();

    private Vector3 _cachedPosition;
    private float _startHeight = 0.0f;
    private float _maxHeight = 0.0f;
    public void Restart()
    {
        gameObject.SetActive(true);
        transform.position = _cachedPosition;
        _maxHeight = 0.0f;
    }
    private void Start()
    {
        _cachedPosition = transform.position;
        _rb = GetComponent<Rigidbody2D>();
        _startHeight = _rb.transform.position.y;
        Restart();
    }
    private void  Update()
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
            else if (_gameBorders.IntersectsLowerBorder(_rb.transform))
            {
                gameObject.SetActive(false);
                OnPlayerDied.Invoke();
            }
        }

        if(_rb.position.y > _maxHeight)
        {
            _maxHeight = _rb.position.y;
            OnNewHeightReached.Invoke(_maxHeight-_startHeight);
        }


    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        //_rb.AddForce(Vector2.up * 500);
        if(Vector2.Dot(_rb.velocity, Vector2.up) <= 0)
            _rb.velocity = new Vector2(_rb.velocity.x, _verticalMoveSpeed);
    }
}
