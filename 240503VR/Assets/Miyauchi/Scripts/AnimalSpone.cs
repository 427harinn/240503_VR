using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalSpone : MonoBehaviour
{
    GameObject[] spones;
    GameObject[] animals;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// �X�|�[���ʒu�����߂�
    /// </summary>
    private void sponeDeside()
    {
        int rnd_spone = Random.Range(0, spones.Length);
        int rnd_animal = Random.Range(0, animals.Length);
        Instantiate(animals[rnd_animal]);
    }
}
