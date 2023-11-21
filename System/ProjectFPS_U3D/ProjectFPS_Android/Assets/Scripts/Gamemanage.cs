using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

public class Gamemanage : MonoBehaviour {
    public GameObject[] Enemy;
    public GameObject[] EnemyCopy;
    public Transform[] EnemyPoints;
    public int Maxnum = 4;

    public int Tscore;
    public int Ttime;

    public GameObject obS;

    void Start () {
        GameObject EnemyObj = GameObject.Instantiate(Enemy[0], EnemyPoints[0].position, EnemyPoints[0].rotation);
        EnemyObj.name = Enemy[0].name;
        obS.SetActive(true);
    }
    // Update is called once per frame
    void Update ()
    {
        //Ttime = (int)Time.time;
        Ttime = Convert.ToInt32(Time.time);
        GameObject.Find("Canvas/Time_text").GetComponent<Text>().text = "游戏时间: "+ Ttime;
        GameObject.Find("Canvas/Score_text").GetComponent<Text>().text = "游戏得分: " + Tscore;

        //Debug.Log(Ttime);
        //Debug.Log("Score is " + Tscore);
        //Arepetition();
        EnemyCopy = GameObject.FindGameObjectsWithTag("Enemy");
        if (EnemyCopy.Length ==0)
        {
            Nrepetition();
        }
    }


    public void Arepetition()
    {
        EnemyCopy = GameObject.FindGameObjectsWithTag("Enemy");
        GuidNumber way02 = new GuidNumber();
        var EnemyType = way02.getGnum(3);
        var EnemyPoint = way02.getGnum(8);
        //int EnemyType = Random.Range(0, 3);
        //int EnemyPoint = Random.Range(0, 8);
        if (EnemyCopy.Length < Maxnum)
        {
            GameObject EnemyObj = GameObject.Instantiate(Enemy[EnemyType], EnemyPoints[EnemyPoint].position, EnemyPoints[EnemyPoint].rotation);
        }
    }

    public void Nrepetition()
    {
        GuidNumber way02 = new GuidNumber();
        int[] tempArray = new int[4];
        bool nrepetition;
        for (int i = 0; i < tempArray.Length;)
        {
            int tempNum = way02.getGnum(8);
            nrepetition = true;
            for (int j = 0; j < tempArray.Length; j++)
            {
                if (tempNum == tempArray[j])
                {
                    nrepetition = false;
                }
            }
            if (nrepetition)
            {
                tempArray[i] = tempNum;
                var EnemyType = way02.getGnum(3);
                GameObject EnemyObj = GameObject.Instantiate(Enemy[EnemyType], EnemyPoints[tempArray[i]].position, EnemyPoints[tempArray[i]].rotation);
                EnemyObj.name = Enemy[EnemyType].name;
                i++;
            }
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