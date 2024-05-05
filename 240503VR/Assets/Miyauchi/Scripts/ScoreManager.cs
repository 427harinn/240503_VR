using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance = null;

    public int score_shootiong = 0;
    public int score_cat = 0;
    public int score_fox = 0;
    public int score_pengin = 0;
    public int panel_shootiong = 0;
    public int defaultAnimalNum = 15;
    public int animalNum = 0;
    public int defaultHP = 20;
    public int restHP;

    public bool inGame = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }

        //restHP = defaultHP;
    }
}
