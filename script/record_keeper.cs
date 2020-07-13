using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class record_keeper : MonoBehaviour
{
    my_menu2 my_Menu;


    GameObject check_point;
    GameObject act;

    SpriteRenderer Target_Sprite;
    SpriteRenderer Target_Sprite_sta;
    public List<GameObject> all_check_points = new List<GameObject>();
    public List<GameObject> all_check_status = new List<GameObject>();

    public Sprite _futa;
    public Sprite _switchs;
    public Sprite _handle;
    public Sprite _coverGaishi;


    public Sprite _ari;
    public Sprite _nasi;

    int ch_order = -1;
    int exist_ch_order;

    void Start()
    {
        my_Menu = GameObject.Find("main").GetComponent<my_menu2>();

        check_point = GameObject.Find("CheckBoard/Bord01/CheckPoints");

        foreach (Transform tra in check_point.transform)
        {
            foreach (Transform tra2 in tra)
            {
                if (tra2.name == "CheckPointLabel")
                {
                    all_check_points.Add(tra2.transform.Find("Label").gameObject);
                }
            }
        }

        foreach (Transform tra3 in check_point.transform)
        {
            foreach (Transform tra4 in tra3)
            {
                if (tra4.name == "ConditionLabel")
                {
                    all_check_status.Add(tra4.transform.Find("Label").gameObject);
                }
            }
        }


    }

    bool once_time = true ;
    void Update()
    {

        if (my_Menu.ans_push == true)
        {


            once_play();


            my_Menu.ans_push = false;


            if (my_Menu.ans_par == true)
            {
                Target_Sprite_sta.sprite = _ari;
            }
            else
            {
                Target_Sprite_sta.sprite = _nasi;
            }



            if (my_Menu.exist_part == false)
            {
                act = check_point.transform.GetChild(ch_order).gameObject;
                act.SetActive(true);
                Debug.Log(act);
            }
            else
            {
                Debug.Log("ccc");
                act = check_point.transform.GetChild(exist_ch_order).gameObject;
                act.SetActive(true);
            }

        }


        if (my_Menu.click_close == true)
        {
            my_Menu.click_close = false;
            once_time = true;

        }

    }

    void once_play()
    {
        if (once_time == true)
        {
            once_time = false;

            my_Menu.check_record();

            Debug.Log(my_Menu.exist_num);
            Debug.Log(ch_order);

            if (my_Menu.exist_part == false)
            {

                if (ch_order <= 8)
                {
                    ch_order += 1;
                }
                Debug.Log("aaa");
                Target_Sprite = all_check_points[ch_order].GetComponent<SpriteRenderer>();
                Target_Sprite_sta = all_check_status[ch_order].GetComponent<SpriteRenderer>();



            }
            else
            {
                Debug.Log("bbb");
                exist_ch_order = my_Menu.exist_num;
                Target_Sprite = all_check_points[exist_ch_order].GetComponent<SpriteRenderer>();
                Target_Sprite_sta = all_check_status[exist_ch_order].GetComponent<SpriteRenderer>();
            }


            my_Menu.rs3_push = false;


            Debug.Log(my_Menu.now_activ);
            if (my_Menu.now_activ == my_Menu.futa_func)
            {
                Target_Sprite.sprite = _futa;

            }
            else if (my_Menu.now_activ == my_Menu.switch_func)
            {
                Target_Sprite.sprite = _switchs;

            }
            else if (my_Menu.now_activ == my_Menu.handle_func)
            {
                Target_Sprite.sprite = _handle;

            }
            else if (my_Menu.now_activ == my_Menu.coverGaishi_func)
            {
                Target_Sprite.sprite = _coverGaishi;

            }

        }
    }

    void no_use1()
        {
        if (my_Menu.rs3_push == true)
        {
            my_Menu.check_record();

            Debug.Log(my_Menu.exist_num);
            Debug.Log(ch_order);

            if (my_Menu.exist_part == false)
            {

                if (ch_order <= 8)
                {
                    ch_order += 1;
                }
                Debug.Log("aaa");
                Target_Sprite = all_check_points[ch_order].GetComponent<SpriteRenderer>();
                Target_Sprite_sta = all_check_status[ch_order].GetComponent<SpriteRenderer>();



            }
            else
            {
                Debug.Log("bbb");
                exist_ch_order = my_Menu.exist_num;
                Target_Sprite = all_check_points[exist_ch_order].GetComponent<SpriteRenderer>();
                Target_Sprite_sta = all_check_status[exist_ch_order].GetComponent<SpriteRenderer>();
            }


            my_Menu.rs3_push = false;


            Debug.Log(my_Menu.now_activ);
            if (my_Menu.now_activ == my_Menu.futa_func)
            {
                Target_Sprite.sprite = _futa;

            }
            else if (my_Menu.now_activ == my_Menu.switch_func)
            {
                Target_Sprite.sprite = _switchs;

            }
            else if (my_Menu.now_activ == my_Menu.handle_func)
            {
                Target_Sprite.sprite = _handle;

            }
            else if (my_Menu.now_activ == my_Menu.coverGaishi_func)
            {
                Target_Sprite.sprite = _coverGaishi;

            }

        }
    }
}
