using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwipeControls : MonoBehaviour
{
    [SerializeField] private Vector2 _startTouchPos; //First Touch Pos
    [SerializeField] private Vector2 _lastTouchPos; //Last Touch Pos

    [SerializeField] private float _swipeRange; //Min dist for a swipe

    //Player
    [SerializeField] private Transform _player;
    public float _playerSpeed;
    [SerializeField] private float _currentSpeed;
    [SerializeField] private float _maxSpeed;
    public Rigidbody2D _rb;
    [SerializeField] private Vector2 _desiredScale;
    [SerializeField] private Vector3 _currentSize;
    [SerializeField] private Vector3 _maxSize;

    // Start is called before the first frame update
    void Start()
    {
        _swipeRange = Screen.height * 15 / 100;

    }

    // Update is called once per frame
    void Update()
    {
        _currentSize = _player.transform.localScale;
        _currentSpeed = _playerSpeed;
        Swipe();

        if (_player.transform.localScale.x >= _maxSize.x)
        {
            _player.transform.localScale = _maxSize;
        }

        if (_currentSpeed >= _maxSpeed)
        {
            _playerSpeed = _maxSpeed;
        }
        
    }

    //Swipe Controls for the doughball
    private void Swipe()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                _startTouchPos = touch.position;
                _lastTouchPos = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                _lastTouchPos = touch.position;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                _lastTouchPos = touch.position;
                if (Mathf.Abs(_lastTouchPos.x - _startTouchPos.x) > _swipeRange || Mathf.Abs(_lastTouchPos.y - _startTouchPos.y) > _swipeRange)
                {
                    if (Mathf.Abs(_lastTouchPos.x - _startTouchPos.x) > Mathf.Abs(_lastTouchPos.y - _startTouchPos.y))
                    {
                        if (_lastTouchPos.x > _startTouchPos.x)
                        {
                            //Right Swipe
                            _rb.velocity = new Vector2(1f, 0f) * _playerSpeed;
                        }
                        else
                        {
                            //Left Swipe
                            _rb.velocity = new Vector2(-1f, 0f) * _playerSpeed;
                        }
                    }
                    else
                    {
                        if (_lastTouchPos.y > _startTouchPos.y)
                        {
                            //Up Swipe
                            _rb.velocity = new Vector2(0f, 1f) *_playerSpeed;
                            IncreaseSize();
                            IncreaseSpeed();
                        }
                        else
                        {
                            //Down Swipe
                        }
                    }
                }
            }
        }
    }

    //Increase Doughball size
    private void IncreaseSize()
    {
        _player.transform.localScale += new Vector3(_desiredScale.x, _desiredScale.y, 0);
    }

    //Increase doughball speed
    private void IncreaseSpeed()
    {
        _playerSpeed += 0.5f;
    }
}
