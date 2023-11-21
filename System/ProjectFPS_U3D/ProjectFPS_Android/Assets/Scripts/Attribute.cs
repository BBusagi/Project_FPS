using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class Attribute : MonoBehaviour {
    public float hp;
    private int sweapon = 10;
    private int mweapon = 50;
    private int bweapon = 100;
    private int score;
    private int getbullet = 10;
    private Gamemanage gm;
    private Shoot shootm;


    // Use this for initialization
    void Start () {
        gm = GameObject.Find("GameManage").GetComponent<Gamemanage>();
        GuidNumber guidnum = new GuidNumber();

        if (this.name  =="enemy_S")
        {
            score = guidnum.getGnum(50);
            hp = 50;
        }
        else if (this.name == "enemy_M")
        {
            score = guidnum.getGnum(100);
            hp = 100;
        }
        else
        {
            score = guidnum.getGnum(500);
            hp = 500;
        }
    }

    // Update is called once per frame
    void Update () {
        if (hp <= 0)
        {
            gm.Tscore += score;
            shootm = GameObject.Find("shoot_point").GetComponent<Shoot>();
            shootm.bulletnum += getbullet;
            Destroy(this.gameObject);
        }
	}

    void OnCollisionEnter(Collision other)
    {
        GameObject ob = other.gameObject;
        var name = ob.name;
        //Debug.Log("Name is " + name);

        var tag = other.collider.tag;
        if (tag == "Sweapon")
        {
            hp -= sweapon;
        }
        else if (tag == "Mweapon")
        {
            hp -= mweapon;
        }
        else if(tag == "Bweapon")
        {
            hp -= bweapon;
        }
    }

    public class GuidNumber
    {
        public int getGnum(int max)
        {
            byte[] guid = Guid.NewGuid().ToByteArray();
            int seed = BitConverter.ToInt32(guid, 0);
            Random random = new Random(seed);
            int inum = 0;
            inum = random.Next(0, max);
            return inum;
        }
    }

}