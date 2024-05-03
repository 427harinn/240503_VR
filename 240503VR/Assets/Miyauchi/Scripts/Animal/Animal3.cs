using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal3 : MonoBehaviour
{
    [SerializeField] float moveRange = 2.0f;
    float moveChangeTime;
    [SerializeField] float time = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        Move1();
    }

    // Update is called once per frame
    void Update()
    {
        /*if (moveChangeTime >= 0)
        {
            moveChangeTime -= Time.deltaTime;
        }
        else
        {
            moveChangeTime = moveChangeDeltaTime;
            speed = -speed;
        }

        gameObject.transform.position += new Vector3(speed, 0, 0) * 0.1f;*/
    }

    private void Move1()
    {
        transform.DOMove(new Vector3(-moveRange, 0, 0), time).SetRelative(true).OnComplete(Move2);
    }

    private void Move2()
    {
        transform.DOBlendableScaleBy(new Vector3(1, 1, 0), 0.5f).OnComplete(Move3);
    }

    private void Move3()
    {
        transform.DOBlendableScaleBy(new Vector3(-1, -1, 0), 0.5f).OnComplete(Move4);
    }

    private void Move4()
    {
        transform.DOMove(new Vector3(moveRange, 0, 0), time).SetRelative(true).OnComplete(Move5);
    }

    private void Move5()
    {
        transform.DOBlendableScaleBy(new Vector3(1, 1, 0), 0.5f).OnComplete(Move6);
    }

    private void Move6()
    {
        transform.DOBlendableScaleBy(new Vector3(-1, -1, 0), 0.5f).OnComplete(Move1);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ballet")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
