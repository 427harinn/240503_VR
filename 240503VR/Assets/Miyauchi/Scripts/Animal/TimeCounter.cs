using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeCounter : MonoBehaviour
{
    [SerializeField] Text timeText;
    [SerializeField] float playtime = 20;
    float restTime;

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
            Debug.Log("タイムアップ");
        }
        timeText.text = (int)restTime + "秒";
    }
}
