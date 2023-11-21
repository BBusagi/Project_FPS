using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 控制人物移动脚本
/// </summary>
public class Movement : MonoBehaviour
{
    public int speed = 5;
    float h;
    float v;
    float s;
    bool ground;
    void Update()
    {
        v = Input.GetAxis("Vertical");//垂直方向 前后
        h = Input.GetAxis("Horizontal");//水平方向 左右
        float buffer = Time.deltaTime * speed;
        Vector3 V3_translate = new Vector3(0, 0, Mathf.Lerp(0, v, buffer));
        Vector3 V3_rotation = new Vector3(0, Mathf.Lerp(0, h, buffer), 0);
        transform.Translate(V3_translate);//Time.deltaTime 时间间隔
        transform.Rotate(V3_rotation * 10);//Quaternion 亦可以使用四元数
    }

    public void JumpBu()
    {
        //s = Input.GetAxis("Jump") + 15;
            if (ground)
            {
                GetComponent<Rigidbody>().AddForce(new Vector3(0, 15, 0) * 100);
                ground = false;
            }
    }
    void OnCollisionEnter(Collision rigidbody)
    {
        var name = rigidbody.collider.name;
        //Debug.Log("Name is " + name);
        if (name == "ground")
        {
            ground = true;
        }
    }

}
