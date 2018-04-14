﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;



//Player controlled in each of the scenes
public class PlaneController : MonoBehaviour
{

    public float rotationalSpeed;
    public Vector3 rotationLimit;
    public float speed;

    Rigidbody rigid;
    Vector3 rotation;

    public LayerMask windCollider;

    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        RotateMyBoi();
        UpdateTheVeloc();
    }

    void RotateMyBoi()
    {
        rotation += new Vector3(Input.GetAxis("Pitch") * rotationalSpeed, Input.GetAxis("Yaw") * rotationalSpeed, Input.GetAxis("Roll") * rotationalSpeed);
        rotation.x = Mathf.Clamp(rotation.x, -rotationLimit.x, rotationLimit.x);
        rotation.y = Mathf.Clamp(rotation.y, -rotationLimit.y, rotationLimit.y);
        rotation.z = Mathf.Clamp(rotation.z, -rotationLimit.z, rotationLimit.z);
        transform.eulerAngles = rotation;

    }

    void UpdateTheVeloc()
    {
        rigid.velocity = transform.forward * speed;
    }
    void OnTriggerStay(Collider col)
    {
        //Wind Collision
        if(col.gameObject.layer == windCollider.value)
        {
            
        }

    }

}