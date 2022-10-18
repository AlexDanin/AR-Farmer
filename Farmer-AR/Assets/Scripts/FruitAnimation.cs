using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitAnimation : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * 50);
        transform.position = new Vector3(transform.position.x, 0.6f + Mathf.Sin(Time.fixedTime) * 0.5f, transform.position.z);
    }
}
