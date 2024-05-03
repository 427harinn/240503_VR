using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal1 : MonoBehaviour
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
        transform.DORotate(new Vector3(0, 0, 360), 1, RotateMode.LocalAxisAdd).OnComplete(Move3);
    }

    private void Move3()
    {
        transform.DOMove(new Vector3(moveRange, 0, 0), time).SetRelative(true).OnComplete(Move4);
    }

    private void Move4()
    {
        transform.DORotate(new Vector3(0, 0, 360), 1, RotateMode.LocalAxisAdd).OnComplete(Move1);
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
