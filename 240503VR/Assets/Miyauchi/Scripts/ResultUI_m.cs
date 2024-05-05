using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultUI_m : MonoBehaviour
{
    [SerializeField] Text scoreText;
    [SerializeField] Text catScoreText;
    [SerializeField] Text foxScoreText;
    [SerializeField] Text penginScoreText;
    [SerializeField] Text destroyPanelText;

    AudioSource audioSource;
    [SerializeField] AudioClip sceneCanageSe;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        scoreText.text = "�~�����A�j�}���̐�: " + ScoreManager.instance.score_shootiong;
        catScoreText.text = "" + ScoreManager.instance.score_cat;
        foxScoreText.text = "" + ScoreManager.instance.score_fox;
        penginScoreText.text = "" + ScoreManager.instance.score_pengin;
        destroyPanelText.text = "�������p�l���̖���:" + (ScoreManager.instance.defaultHP - ScoreManager.instance.restHP);
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.One)) //�E��A�{�^��
        {
            audioSource.PlayOneShot(sceneCanageSe);
            Invoke("SceneChange", 1.0f);
        }
    }

    private void SceneChange()
    {
        SceneManager.LoadScene("ShootiongTitle");
    }
}
