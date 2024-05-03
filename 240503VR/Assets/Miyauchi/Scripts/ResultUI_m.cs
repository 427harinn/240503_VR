using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultUI_m : MonoBehaviour
{
    [SerializeField] Text scoreText;
    [SerializeField] Text destroyPanelText;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "救ったアニマルの数: " + ScoreManager.instance.score_shootiong;
        destroyPanelText.text = "割ったパネルの枚数:" + (ScoreManager.instance.defaultHP - ScoreManager.instance.restHP);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
