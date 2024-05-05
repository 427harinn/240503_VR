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

    }

    // Update is called once per frame
    void Update()
    {
        if (ScoreManager.instance.inGame)
        {
            if (ScoreManager.instance.animalNum < ScoreManager.instance.defaultAnimalNum)
            {
                sponeDeside();
            }
        }

        
    }

    /// <summary>
    /// スポーン位置を決める
    /// </summary>
    private void sponeDeside()
    {
        ScoreManager.instance.animalNum++;

        int rnd_spone = Random.Range(0, spones.Length);
        int rnd_animal = Random.Range(0, animals.Length);
        GameObject newAnimal = Instantiate(animals[rnd_animal], spones[rnd_spone].transform.position, Quaternion.identity);
        newAnimal.transform.parent = spones[rnd_spone].transform;
        newAnimal.transform.rotation = spones[rnd_spone].transform.rotation;
    }
}
