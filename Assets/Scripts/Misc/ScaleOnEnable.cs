using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleOnEnable : MonoBehaviour
{
    [SerializeField] private float duration = 0.5f;

    private void Start()
    {
        var trans = transform.localScale;
        transform.localScale = Vector3.zero;
        transform.DOScale(trans, duration).SetEase(Ease.InOutExpo);
    }
}
