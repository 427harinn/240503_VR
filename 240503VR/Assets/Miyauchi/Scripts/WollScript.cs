using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WollScript : MonoBehaviour
{
    Animator animator;

    AudioSource audioSource;
    [SerializeField] AudioClip breakSe;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = transform.parent.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ballet")
        {
            ScoreManager.instance.restHP--;
            animator.SetBool("hit", true);
            audioSource.PlayOneShot(breakSe);
        }
    }

    private void DestroyAnimFin()
    {
        Destroy(gameObject);
    }
}
