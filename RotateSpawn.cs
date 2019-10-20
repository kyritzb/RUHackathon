﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSpawn : MonoBehaviour
{
    int speed = 2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 target = new Vector3(0,0,0);

        //transform.rotation = Quaternion.Slerp(transform.rotation, target,  Time.deltaTime * 1);
        transform.RotateAround(target, new Vector3(0,1,0), speed*Time.deltaTime);
    }
}
