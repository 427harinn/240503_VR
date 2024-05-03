using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyExpansion_s : MonoBehaviour
{
    Transform bodyOriginTrans;
    Transform cameraTrans;
    // Start is called before the first frame update
    void Start()
    {
        bodyOriginTrans = transform;
        cameraTrans = transform.parent.transform;
    }

    // Update is called once per frame
    void Update()
    {
        bodyOriginTrans.localScale = new Vector3(bodyOriginTrans.localScale.x, cameraTrans.localPosition.y + 1, bodyOriginTrans.localScale.z);
    }
}
