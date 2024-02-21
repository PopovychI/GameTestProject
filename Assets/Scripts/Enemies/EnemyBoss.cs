using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoss : Enemy, IDamageable
{

    private Transform[] movePositions = new Transform[2];
    [SerializeField] private float movespeed;
    private Transform currentMovePoint;

    public void SetMovePoints(Transform[] movePosition)
    {
        movePositions = movePosition;
        currentMovePoint = movePositions[0];
    }
    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        MoveBetweenPoints();
    }
    private void MoveBetweenPoints()
    {
        if (rbody.velocity.magnitude > movespeed) return;
        if (Vector3.Distance(currentMovePoint.position, transform.position) > 5f)
        {
            rbody.AddForce((currentMovePoint.position - transform.position) * Time.fixedDeltaTime * movespeed);
        }
        else ChangeMovePoint();
    }
    private void ChangeMovePoint()
    {
        if (currentMovePoint == movePositions[0]) currentMovePoint = movePositions[1];
        else currentMovePoint = movePositions[0];
    }
}
