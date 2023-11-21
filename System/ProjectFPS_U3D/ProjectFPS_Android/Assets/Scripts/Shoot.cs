using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using HedgehogTeam.EasyTouch;

///<summary>
///
///<summary>
public class Shoot : MonoBehaviour
{

    public GameObject bullet;
    public int speed = 50;
    public int bulletnum  ;
    bool shoot = true;
    public AudioSource sound ;

    void Start()
    {
        bulletnum = 10;
        //GameObject.Instantiate(bullet,transform.position,transform.rotation); 
    }

    public void FireBu()
    {
        if (this.gameObject.activeInHierarchy != false  && bulletnum != 0)
        {
            //Vector3 rt_rotation = new Vector3(transform.rotation.x + 90, 0,0);
            GameObject rt_bullet = GameObject.Instantiate(bullet, transform.position, transform.rotation);
            rt_bullet.tag = this.tag;
            Rigidbody rg = rt_bullet.GetComponent<Rigidbody>();
            rg.velocity = transform.up * speed;
            sound.Play();
            Destroy(rt_bullet, 3f);
            bulletnum--;
        }
        else
        {
            return;
        }

    }


    private void FixedUpdate()
    {
        Debug.Log(bulletnum);
    }
}
