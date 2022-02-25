using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateLaser : MonoBehaviour
{
    private GameObject _capsule;

    // Start is called before the first frame update
    void Start()
    {
        GameObject parent = GameObject.CreatePrimitive(PrimitiveType.Capsule);

        _capsule = GameObject.CreatePrimitive(PrimitiveType.Capsule);
    }

    // Update is called once per frame
    void Update()
    {
        _capsule.transform.Rotate(0, 90 * Time.deltaTime, 0);
    }
}
