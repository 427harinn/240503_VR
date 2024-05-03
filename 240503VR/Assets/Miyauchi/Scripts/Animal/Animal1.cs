using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal1 : MonoBehaviour
{
    [SerializeField] float moveRange = 2.0f;
    float moveChangeTime;
    [SerializeField] float time = 3.0f;

    AudioSource audioSource;
    [SerializeField] AudioClip hitSe;

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        animator = transform.GetChild(0).GetComponent<Animator>();

        Move0();
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
        transform.DOLocalMove(new Vector3(-moveRange, 0, 0), time).SetRelative(true).OnComplete(Move2);
    }

    private void Move2()
    {
        transform.DORotate(new Vector3(0, 0, 360), 1, RotateMode.LocalAxisAdd).OnComplete(Move3);
    }

    private void Move3()
    {
        transform.DOLocalMove(new Vector3(moveRange, 0, 0), time).SetRelative(true).OnComplete(Move4);
    }

    private void Move4()
    {
        transform.DORotate(new Vector3(0, 0, 360), 1, RotateMode.LocalAxisAdd).OnComplete(Move1);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ballet")
        {
            audioSource.PlayOneShot(hitSe);
            Destroy(collision.gameObject);
            ScoreManager.instance.score_shootiong++;
            ScoreManager.instance.animalNum--;

            animator.SetBool("hit", true);

            //Invoke("HitAnimFin", 1.0f); //後でアニメーション終了後に呼び出す処理に変更
        }
    }

    /*private void HitAnimFin(){
        Destroy(gameObject);
    }*/
}
