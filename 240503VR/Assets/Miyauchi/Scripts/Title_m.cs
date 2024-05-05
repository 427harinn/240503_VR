using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title_m : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField] AudioClip sceneCanageSe;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.One)) //‰EŽèAƒ{ƒ^ƒ“
        {
            audioSource.PlayOneShot(sceneCanageSe);
            Invoke("SceneChange", 1.0f);
        }
    }

    private void SceneChange()
    {
        SceneManager.LoadScene("ShootiongPlay");
    }
}
