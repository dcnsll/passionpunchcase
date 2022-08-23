using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Rotate360 : MonoBehaviour
{
    private Vector3 rot;


    private void Awake()
    {
        rot = new Vector3(0, 360, 0);
    }

    void Start()
    {

        transform.DOBlendableLocalRotateBy(new Vector3(0, -360, 0), 4f, RotateMode.FastBeyond360).SetLoops(-1).SetEase(Ease.Linear);
    }

    
}
