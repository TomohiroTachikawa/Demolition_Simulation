using Dissonance;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class score_manager : MonoBehaviour
{
    my_menu2 my_Menu;

    void Start()
    {
        my_Menu = GameObject.Find("main").GetComponent<my_menu2>();
        Debug.Log(my_Menu);
    }


    void Update()
    {
        if (my_Menu.score_on == true)
        {

            Debug.Log("採点機能実装");
            my_Menu.score_on = false;


        }

    }

    void make_score()
    { 
    
    }
    
}
