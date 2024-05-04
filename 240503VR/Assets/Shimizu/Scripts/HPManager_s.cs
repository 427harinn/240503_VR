using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPManager_s : MonoBehaviour
{
    GameObject[] HPs;
    bool [] a = new bool[2];
    // Start is called before the first frame update
    void Start()
    {
        HPs = GameObject.FindGameObjectsWithTag("photon");
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < HPs.Length; i++)
        {
            if (HPs[i].GetComponent<MyHP_s>().GetHPvalue() < 0)
            {
                HPs[i].GetComponent<MyHP_s>().losedef();
                a[i] = true;
            }
        }

        if (a[0])
        {
            HPs[1].GetComponent<MyHP_s>().windef();
        }
        else if (a[1])
        {
            HPs[0].GetComponent<MyHP_s>().windef();
        }
    }
}
