using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
        ScoreManager.instance.restHP = ScoreManager.instance.defaultHP;

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
            SceneManager.LoadScene("ShootiongResult");
            Debug.Log("タイムアップ");
        }
        timeText.text = (int)restTime + "秒";

        if(ScoreManager.instance.score_shootiong != oldScore)
        {
            scoreText.text = "score:" + ScoreManager.instance.score_shootiong;
        }

        oldScore = ScoreManager.instance.score_shootiong;
    }
}
