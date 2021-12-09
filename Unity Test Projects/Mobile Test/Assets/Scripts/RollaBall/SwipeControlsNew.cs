using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwipeControlsNew : MonoBehaviour
{
    public enum Swipe { Up, Down, Left, Right, None, UpLeft, UpRight, DownLeft, DownRight };

    public Swipe swipeEnum;
    public float minSwipeLength = 200f;

    Vector2 firstPressPos;
    Vector2 secondPressPos;
    Vector2 currentSwipe;
    
    float tweakFactor = 0.5f;
    
    public static Swipe swipeDirection;
    
    [SerializeField] private Transform _player;
    public float _playerSpeed;
    [SerializeField] private float _currentSpeed;
    [SerializeField] private float _maxSpeed;
    public Rigidbody2D _rb;
    [SerializeField] private Vector2 _desiredScale;
    public Vector3 _currentSize;
    [SerializeField] private Vector3 _maxSize;
    
    
    void Update ()
    {
        _currentSize = _player.transform.localScale;
        _currentSpeed = _playerSpeed;

        DetectSwipe();
        
        if (_player.transform.localScale.x >= _maxSize.x)
        {
            _player.transform.localScale = _maxSize;
        }

        if (_currentSpeed >= _maxSpeed)
        {
            _playerSpeed = _maxSpeed;
        }
    }
    
    public void DetectSwipe ()
    {
        if (Input.touches.Length > 0) 
        {
            Touch t = Input.GetTouch(0);
    
            if (t.phase == TouchPhase.Began) {
                firstPressPos = new Vector2(t.position.x, t.position.y); 
            }
    
            if (t.phase == TouchPhase.Ended) {
                secondPressPos = new Vector2(t.position.x, t.position.y);
            currentSwipe = new Vector3(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);
    
        // Make sure it was a legit swipe, not a tap
        if (currentSwipe.magnitude < minSwipeLength) 
        {
            swipeDirection = Swipe.None;
            return;
        }
    
        currentSwipe.Normalize();

        // Swipe up
        if (currentSwipe.y > 0 && currentSwipe.x > 0 - tweakFactor && currentSwipe.x < tweakFactor) 
        {
            swipeDirection = Swipe.Up;
            _rb.velocity = new Vector2(0f, 1f) *_playerSpeed;
            IncreaseSize();
            IncreaseSpeed();
            // Swipe down
        } else if (currentSwipe.y < 0 && currentSwipe.x > 0 - tweakFactor && currentSwipe.x < tweakFactor) {
            swipeDirection = Swipe.Down;
            // Swipe left
        } else if (currentSwipe.x < 0 && currentSwipe.y > 0 - tweakFactor && currentSwipe.y < tweakFactor) {
            swipeDirection = Swipe.Left;
            _rb.velocity = new Vector2(-1f, 0f) * _playerSpeed;
            // Swipe right
        } else if (currentSwipe.x > 0  && currentSwipe.y > 0 - tweakFactor && currentSwipe.y < tweakFactor) {
            swipeDirection = Swipe.Right;
            _rb.velocity = new Vector2(1f, 0f) * _playerSpeed;
            // Swipe up left
        } else if (currentSwipe.y > 0 && currentSwipe.x < 0 ) {
            swipeDirection = Swipe.UpLeft;
            _rb.velocity = new Vector2(-1f, 1f) * _playerSpeed;
            _rb.drag = 0.05f;
            IncreaseSize();
            IncreaseSpeed();
            // Swipe up right
        } else if (currentSwipe.y > 0 && currentSwipe.x > 0 ) {
            swipeDirection = Swipe.UpRight;
            _rb.velocity = new Vector2(1f, 1f) * _playerSpeed;
            _rb.drag = 0.05f;
            IncreaseSize();
            IncreaseSpeed();
            // Swipe down left
        } else if (currentSwipe.y < 0 && currentSwipe.x < 0 ) {
                swipeDirection = Swipe.DownLeft;
            // Swipe down right
        } else if (currentSwipe.y < 0 && currentSwipe.x > 0 ) 
        {
            swipeDirection = Swipe.DownRight;
        }
        
            } 
        } else {
            swipeDirection = Swipe.None;
            //debugInfo.text = "No swipe"; // if you display this, you will lose the debug text when you stop swiping
        }
    }
    
    //Increase Dough ball size
    private void IncreaseSize()
    {
        _player.transform.localScale += new Vector3(_desiredScale.x, _desiredScale.y, 0);
    }

    //Increase Dough ball speed
    private void IncreaseSpeed()
    {
        _playerSpeed += 0.5f;
    }
}
