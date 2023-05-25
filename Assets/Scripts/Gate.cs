using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
public class portallNumer
{
    public static bool p1 = false;
    public static bool p2 = false;
    public static bool p3 = false;
    public static bool p4 = false;
    public static bool p5 = false;
    public static bool p6 = false;
    public static bool p7 = false;
    public static bool p8 = false;
}
public class Gate : MonoBehaviour
{

    public int id;
    public bool enter;
    public bool notsave;
    public bool iaw;
    public bool p3;
    public bool p4;
    public bool p5;
    public Collider other;
    private void Start()
    {
        
            if (portallNumer.p2 == true && iaw)
            {
            GameObject.FindWithTag("Player").transform.position = transform.position;
                portallNumer.p2 = false;
            }
            if (portallNumer.p3 == true && p3)
        {
            GameObject.FindWithTag("Player").transform.position = transform.position;
            portallNumer.p3 = false;
            }
            if (portallNumer.p4 == true && p4)
        {
            GameObject.FindWithTag("Player").transform.position = transform.position;
            portallNumer.p4 = false;
            }
            if (portallNumer.p5 == true && p5)
        {
            GameObject.FindWithTag("Player").transform.position = transform.position;
            portallNumer.p5 = false;
            }
       
       

    }
    public void startcol()
    {
        enter = true;
        
    }
    
    private void OnTriggerEnter(Collider s)
    {
        if (s.gameObject.tag == "Player")
        {

            startcol();



        }
    }
   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (enter && iaw)
            {
                if (!notsave)
                {
                }
                portallNumer.p2 = true;
                SceneManager.LoadScene(id);

            }
            if (enter && p3)
            {
                if (!notsave)
                {
                }
                portallNumer.p3 = true;
                SceneManager.LoadScene(id);

            }
            if (enter && p4)
            {
                if (!notsave)
                {
                }
                portallNumer.p4 = true;
                SceneManager.LoadScene(id);

            }
            if (enter && p5)
            {
                if (!notsave)
                {
                }
                portallNumer.p5 = true;
                SceneManager.LoadScene(id);

            }
            if (enter)
            {
                if (!notsave)
                {
                }
                SceneManager.LoadScene(id);
            }
        }
    }
    private void OnTriggerExit(Collider s)
    {
        if (s.gameObject.tag == "Player")
        {

            enter = false;
            PlayerPrefs.SetString("text", "");
            other = s;


        }
    }
    
}

