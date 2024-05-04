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

    [SerializeField] Slider slider;
    int oldHP;

    // Start is called before the first frame update
    void Start()
    {
        slider.value = ScoreManager.instance.defaultHP;
        ScoreManager.instance.restHP = ScoreManager.instance.defaultHP;
        oldHP = ScoreManager.instance.restHP;

        restTime = playtime;
    }

    // Update is called once per frame
    void Update()
    {
        if (restTime <= 0 || ScoreManager.instance.restHP <= 0)
        {
            SceneManager.LoadScene("ShootiongResult");
            Debug.Log("タイムアップ");
        }
        else
        {
            restTime -= Time.deltaTime;
        }
        timeText.text = (int)restTime + "秒";

        if(ScoreManager.instance.score_shootiong != oldScore)
        {
            scoreText.text = "score:" + ScoreManager.instance.score_shootiong;
        }

        if (ScoreManager.instance.restHP != oldHP)
        {
            slider.value = ScoreManager.instance.restHP;
        }

        oldScore = ScoreManager.instance.score_shootiong;
        oldHP = ScoreManager.instance.restHP;
    }
}
