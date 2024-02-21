using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class JumpYTween : MonoBehaviour
{
    [SerializeField] private float jumpPower = 5f;
    [SerializeField] private float jumpDuration = 1f;
   private void Start()
    {
        JumpTween();
    }

    private void JumpTween()
    {
        var pos = transform.position;
        transform.DOJump(pos, jumpPower, 1, jumpDuration).OnComplete(JumpTween).SetEase(Ease.InOutQuad);
    }

    private void OnDisable()
    {
        transform.DOKill();
    }

}
