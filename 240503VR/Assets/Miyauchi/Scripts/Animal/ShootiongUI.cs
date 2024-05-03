using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootiongUI : MonoBehaviour
{
    [SerializeField] Text timeText;
    [SerializeField] float playtime = 20;
    float restTime;

    [SerializeField] Text scoreText;
    int oldScore;

    // Start is called before the first frame update
    void Start()
    {
        restTime = playtime;
    }

    // Update is called once per frame
    void Update()
    {
        if (restTime >= 0)
        {
            restTime -= Time.deltaTime;
        }
        else
        {
            Debug.Log("�^�C���A�b�v");
        }
        timeText.text = (int)restTime + "�b";

        if(ScoreManager.instance.score_shootiong != oldScore)
        {
            scoreText.text = "score:" + ScoreManager.instance.score_shootiong;
        }

        oldScore = ScoreManager.instance.score_shootiong;
    }
}
