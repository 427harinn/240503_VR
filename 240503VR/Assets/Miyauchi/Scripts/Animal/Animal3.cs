using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal3 : MonoBehaviour
{
    [SerializeField] float moveChangeDeltaTime = 2.0f;
    float moveChangeTime;
    [SerializeField] float speed = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (moveChangeTime >= 0)
        {
            moveChangeTime -= Time.deltaTime;
        }
        else
        {
            moveChangeTime = moveChangeDeltaTime;
            speed = -speed;
        }

        gameObject.transform.position += new Vector3(speed, 0, 0) * 0.1f;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ballet")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
