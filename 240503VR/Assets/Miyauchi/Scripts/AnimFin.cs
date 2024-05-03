using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimFin : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField] AudioClip loveSe;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = transform.parent.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void HitAnimFin()
    {
        Destroy(transform.parent.gameObject);
    }

    private void LoveEffect()
    {
        audioSource.PlayOneShot(loveSe);
    }
}
