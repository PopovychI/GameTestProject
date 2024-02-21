using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour, ITurnable
{
    [SerializeField] private float speed;
    [SerializeField] private float turnSpeed;
    [SerializeField] private float maxRotationAngle;

    [SerializeField] private bool detectSwipeAfterRelease = false;
    [SerializeField] private float SWIPE_THRESHOLD = 20f;

    private Vector2 fingerDownPos;
    private Vector2 fingerUpPos;
    private Rigidbody rbody;
    private Vector3 forwardDirection = -Vector3.right;
    private bool turnFreezed;

    private void Awake()
    {
        rbody = GetComponent<Rigidbody>();
    }

    public void MoveForward()
    {
        rbody.AddForce(-transform.right * Time.fixedDeltaTime * speed);
    }

    public void TurnLeft()
    {

        rbody.AddForce(-transform.forward * Time.fixedDeltaTime * turnSpeed * 5f);
        if (turnFreezed) return;
        rbody.AddTorque(-transform.up * turnSpeed * Time.fixedDeltaTime);
    }

    public void TurnRight()
    {
        rbody.AddForce(transform.forward * Time.fixedDeltaTime * turnSpeed * 5f);
        if (turnFreezed) return;
        rbody.AddTorque(transform.up * turnSpeed * Time.fixedDeltaTime);
    }
    public void FreezeTurn()
    {
        turnFreezed = true;
    }


    public void MovementLoop()
    {
        MoveForward();

        if (!EnsureRightDirection()) return;

        TouchCheck();

    }


    private bool EnsureRightDirection()
    {
        var yRot = Vector3.Angle(-transform.right, forwardDirection);
        if (yRot < maxRotationAngle) return true;
        if (transform.rotation.y > 0)
        {
            TurnLeft();
            return false;
        }
        if (transform.rotation.y < 0)
        {
            TurnRight();
            return false;
        }
        return true;
    }


    private void TouchCheck()
    {

        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                fingerUpPos = touch.position;
                fingerDownPos = touch.position;
            }

            //Detects Swipe while finger is still moving on screen
            if (touch.phase == TouchPhase.Moved)
            {
                if (!detectSwipeAfterRelease)
                {
                    fingerDownPos = touch.position;
                    DetectVerticalSwipe();
                }
            }

            //Detects swipe after finger is released from screen
            if (touch.phase == TouchPhase.Ended)
            {
                fingerDownPos = touch.position;
                DetectVerticalSwipe();
            }
        }
    }

    private void DetectVerticalSwipe()
    {

        if (HorizontalMoveValue > SWIPE_THRESHOLD && HorizontalMoveValue > VerticalMoveValue)
        {
            if (fingerDownPos.x - fingerUpPos.x > 0)
            {
                TurnRight();
            }
            else if (fingerDownPos.x - fingerUpPos.x < 0)
            {
                TurnLeft();
            }
            fingerUpPos = fingerDownPos;
        }
    }

    private float VerticalMoveValue => Mathf.Abs(fingerDownPos.y - fingerUpPos.y);
    

    private float HorizontalMoveValue => Mathf.Abs(fingerDownPos.x - fingerUpPos.x);
    
}
