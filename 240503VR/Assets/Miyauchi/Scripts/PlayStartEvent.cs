using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayStartEvent : MonoBehaviour
{
    [SerializeField] Image questImage;
    [SerializeField] Image countdownImage;
    [SerializeField] Sprite[] countdownSprites;

    AudioSource audioSource;
    [SerializeField] AudioClip silentSe;
    [SerializeField] AudioClip countSe;
    [SerializeField] AudioClip startSe;

    private bool questSe = false;
    private bool soundSe = false;
    private bool sound2Se = false;
    private bool sound3Se = false;

    [SerializeField] GameObject wall;
    [SerializeField] GameObject gameUI;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        Move1();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Move1()
    {
        questImage.transform.DOLocalMove(new Vector3(50, 0, 0), 1).OnComplete(Move2);
    }

    private void Move2()
    {
        if (!questSe)
        {
            questSe = true;
            audioSource.PlayOneShot(silentSe);
        }
        questImage.DOFade(0, 0.5f).SetLoops(6, LoopType.Yoyo).OnComplete(Move3);
    }

    private void Move3()
    {
        questImage.gameObject.SetActive(false);

        countdownImage.gameObject.transform.DOBlendableRotateBy(new Vector3(0, 0, 720), 1.0f, RotateMode.WorldAxisAdd);
        countdownImage.gameObject.transform.DOBlendableScaleBy(new Vector3(300, 300, 0), 0.9f).OnComplete(Move4);
        
    }

    private void Move4()
    {
        if (!sound3Se)
        {
            sound3Se = true;
            audioSource.PlayOneShot(countSe);
        }
        countdownImage.gameObject.transform.DOBlendableScaleBy(new Vector3(320f, 320f, 0), 0.55f).SetLoops(2, LoopType.Yoyo).OnComplete(Move5);
    }

    private void Move5()
    {
        if (!sound2Se)
        {
            sound2Se = true;
            audioSource.PlayOneShot(countSe);
            countdownImage.sprite = countdownSprites[1];
        }
        //var sprite = Resources.Load<Sprite>("2");
        //var image = GameObject.Find("SomeSprite").GetComponent<Image>();
        //image.sprite = sprite;
        countdownImage.gameObject.transform.DOBlendableScaleBy(new Vector3(320f, 320f, 0), 0.55f).SetLoops(2, LoopType.Yoyo).OnComplete(Move6);
        //countdownImage.DOFade(0, 0.5f).SetLoops(6, LoopType.Yoyo).OnComplete(Move3);
    }

    private void Move6()
    {
        if (!soundSe)
        {
            soundSe = true;
            audioSource.PlayOneShot(countSe);
            countdownImage.sprite = countdownSprites[2];
        }
        //var sprite = Resources.Load<Sprite>("2");
        //var image = GameObject.Find("SomeSprite").GetComponent<Image>();
        //image.sprite = sprite;
        countdownImage.gameObject.transform.DOBlendableScaleBy(new Vector3(320f, 320f, 0), 0.55f).SetLoops(2, LoopType.Yoyo).OnComplete(Move7);
        //countdownImage.DOFade(0, 0.5f).SetLoops(6, LoopType.Yoyo).OnComplete(Move3);
    }

    private void Move7()
    {
        if (!ScoreManager.instance.inGame)
        {
            ScoreManager.instance.inGame = true;

            wall.SetActive(true);
            gameUI.SetActive(true);
            countdownImage.gameObject.SetActive(false);
            audioSource.PlayOneShot(startSe);
        }
    }
}
