using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalSpone : MonoBehaviour
{
    [SerializeField] GameObject[] spones;
    [SerializeField] GameObject[] animals;

    // Start is called before the first frame update
    void Start()
    {
        sponeDeside();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// スポーン位置を決める
    /// </summary>
    private void sponeDeside()
    {
        int rnd_spone = Random.Range(0, spones.Length);
        int rnd_animal = Random.Range(0, animals.Length);
        Instantiate(animals[rnd_animal], spones[rnd_spone].transform.position, Quaternion.identity);
    }
}
