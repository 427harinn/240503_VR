using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeHP_s : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.GetComponent<MyHP_s>().DecHPvalue();
        }
    }
}
