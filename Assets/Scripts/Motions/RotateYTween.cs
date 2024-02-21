using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateYTween : MonoBehaviour
{
    [SerializeField] private float rotateDuration = 1f;
    private void OnEnable()
    {
        JumpTween();
    }

    private void JumpTween()
    {
        var rotation = transform.rotation.eulerAngles;
        rotation.y += 90;
        transform.DORotate(rotation, rotateDuration).SetEase(Ease.Linear).OnComplete(JumpTween);
    }

    private void OnDisable()
    {
        transform.DOKill();
    }
}
