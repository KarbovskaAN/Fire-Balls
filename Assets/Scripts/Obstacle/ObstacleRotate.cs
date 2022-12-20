using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class ObstacleRotate : MonoBehaviour
{
    [SerializeField] private float _animationDirection;
    
    public void Rotate(ObstacleRotate obstacleRotate)
    {
        obstacleRotate.transform.DORotate(new Vector3(0, 360, 0),_animationDirection , RotateMode.FastBeyond360).SetLoops(-1,LoopType.Yoyo);
    }
}
