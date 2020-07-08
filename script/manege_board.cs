using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;

public class manege_board : MonoBehaviour
{
    public Text text1, text2, text3, text4, text5, text6;
    my_menu my_Menu;

    string my_ans;

    void Start()
    {
        my_Menu = GameObject.Find("main").GetComponent<my_menu>();
        Debug.Log(my_Menu);
    }

    
    void Update()
    {
        if (my_Menu.ans_on == true)
        {
            if (my_Menu.ans == true)
                my_ans = "【あり】";
            else
                my_ans = "【なし】";


            switch (my_Menu.ans_num)
            {
                case 1:
                    text1.text = my_ans;
                    break;
                case 2:
                    text2.text = my_ans;
                    break;
                case 3:
                    text3.text = my_ans;
                    break;
                case 4:
                    text4.text = my_ans;
                    break;
                case 5:
                    text5.text = my_ans;
                    break;
                case 6:
                    text6.text = my_ans;
                    break;

                default:
                    break;


            }

            my_Menu.ans_on = false;


        }

        
    
    
    }

}
