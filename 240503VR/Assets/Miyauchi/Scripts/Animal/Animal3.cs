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

    }

    private void Move0()
    {
        int rnd_x = Random.Range(-4, 4);
        int rnd_y = Random.Range(0, 6);

        transform.DOLocalMove(new Vector3(rnd_x, rnd_y, 0), time).SetRelative(true).OnComplete(Move1);
    }

    private void Move1()
    {
        transform.DOLocalMove(new Vector3(-moveRange, -moveRange / 1.5f, 0), time).SetRelative(true).OnComplete(Move2);
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
        transform.DOLocalMove(new Vector3(moveRange, moveRange / 1.5f, 0), time).SetRelative(true).OnComplete(Move5);
    }

    private void Move5()
    {
        transform.DOBlendableScaleBy(new Vector3(1, 1, 0), 0.5f).OnComplete(Move6);
    }

    private void Move6()
    {
        transform.DOBlendableScaleBy(new Vector3(-1, -1, 0), 0.5f).OnComplete(Move7);
    }

    private void Move7()
    {
        transform.DOBlendableScaleBy(new Vector3(1, 1, 0), 0.5f).OnComplete(Move8);
    }

    private void Move8()
    {
        transform.DOBlendableScaleBy(new Vector3(-1, -1, 0), 0.5f).OnComplete(Move1);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ballet")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            ScoreManager.instance.score_shootiong++;
            ScoreManager.instance.animalNum--;
        }
    }
}
