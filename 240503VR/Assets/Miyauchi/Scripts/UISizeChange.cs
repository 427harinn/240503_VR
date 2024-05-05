using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISizeChange : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Move1();

        transform.DOBlendableScaleBy(new Vector3(0.1f, 0.1f, 0), 1.3f).SetLoops(-1, LoopType.Yoyo);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Move1()
    {
        transform.DOBlendableScaleBy(new Vector3(0.1f, 0.1f, 0), 2f).OnComplete(Move2);
    }

    private void Move2()
    {
        transform.DOBlendableScaleBy(new Vector3(-0.1f, -0.1f, 0), 2f).OnComplete(Move1);
    }
}
