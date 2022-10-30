using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    [SerializeField]
    private GameObject cam, nums;
    public bool flag;
    void Update()
    {
        if (flag)
        {
            nums.transform.LookAt(new Vector3(-cam.transform.position.x, -cam.transform.position.y, -cam.transform.position.z));
        }
        else
        {
            nums.transform.LookAt(new Vector3(cam.transform.position.x, nums.transform.position.y, cam.transform.position.z));
        }
    }
}
