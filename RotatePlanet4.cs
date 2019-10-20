using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlanet4 : MonoBehaviour
{
    int speed = 18;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 target = new Vector3(1,1,-1);

        //transform.rotation = Quaternion.Slerp(transform.rotation, target,  Time.deltaTime * 1);
        transform.RotateAround(target, new Vector3(-1,0,-1), speed*Time.deltaTime);
    }
}
