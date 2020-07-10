using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sentinel;
using DigitalRuby.WeatherMaker;
using OculusSampleFramework;
using Boo.Lang.Environments;

public class my_menu : MonoBehaviour
{
    GameObject my_score;
    GameObject my_answers;

    GameObject futa_func,futa_menu, futa_check1,futa_check2, futa_button1, futa_button2, futa_button3, futa_button4;

    OtherObjectAction ooa;
    OtherObjectAction ooa2;
    OtherObjectAction ooa3;
    OtherObjectAction ooa4;
    OtherObjectAction ooa5;

    OtherObjectAction ooa_1, ooa_2, ooa_3, ooa_4;


    main my_main;

    public bool ans_on;
    public int ans_num;
    public bool ans;

    public bool score_on;

    public Hashtable ans_memo = new Hashtable();
    GameObject rs3_part;

    public Hashtable true_ans = new Hashtable();

    List<GameObject> rs3_select = new List<GameObject>();

    public Hashtable obj_menu = new Hashtable();

    void Start()
    {

        my_main = GameObject.Find("main").GetComponent<main>();
        Debug.Log(my_main);

        futa_func = GameObject.Find("AppearanceCheck");
        Debug.Log(futa_func);
        ooa_1 = futa_func.transform.Find("ChexkPointFrame/Result0/Yes").GetComponent<OtherObjectAction>();

        my_score = GameObject.Find("my_score");
        ooa = my_score.transform.GetChild(1).gameObject.GetComponent<OtherObjectAction>();
        ooa2 = my_score.transform.GetChild(2).gameObject.GetComponent<OtherObjectAction>();

        my_score.SetActive(false);
    


        my_answers = GameObject.Find("answers");
        ooa3 = my_answers.transform.GetChild(1).gameObject.GetComponent<OtherObjectAction>();
        ooa4 = my_answers.transform.GetChild(2).gameObject.GetComponent<OtherObjectAction>();
        ooa5 = my_answers.transform.GetChild(3).gameObject.GetComponent<OtherObjectAction>();

        my_answers.SetActive(false);


        futa_menu = futa_func.transform.GetChild(1).gameObject;
        futa_check1 = futa_func.transform.GetChild(1).gameObject;
        futa_check2 = futa_func.transform.GetChild(2).gameObject;

        ooa_1 = futa_menu.transform.GetChild(1).gameObject.GetComponent<OtherObjectAction>();
        ooa_2 = futa_menu.transform.GetChild(2).gameObject.GetComponent<OtherObjectAction>();
        ooa_3 = futa_menu.transform.GetChild(3).gameObject.GetComponent<OtherObjectAction>();
        ooa_4 = futa_menu.transform.GetChild(4).gameObject.GetComponent<OtherObjectAction>();

        my_answers.SetActive(false);


    }




    void Update()
    {
        use_button();

        call_menu();
        call_score();

    }



    void use_button()
    {

        if (ooa.param[0] > 0)
        {
            Debug.Log("採点が押された");
            score_on = true;
            ooa.param[0] = 0;
            my_score.SetActive(false);
        }

        if (ooa2.param[0] > 0)
        {
            Debug.Log("閉じるが押された");

            my_score.SetActive(false);
            ooa2.param[0] = 0;
        }




        if (ooa3.param[0] > 0 )
        {
            Debug.Log("閉じるが押された");

            my_answers.SetActive(false);
            ooa3.param[0] = 0;
        }



        if (ooa4.param[0] > 0 )
        {

            ans = true;

            Debug.Log("ありが押された");
       
            ans_on = true;
            ans_num += 1;
            ooa4.param[0] = 0;
        }



        if (ooa5.param[0] > 0)
        {
            ans = false;
            Debug.Log("なしが押された");

            ans_on = true;
            ans_num += 1;
            ooa5.param[0] = 0;
        }
    }

    void call_menu()
    {


        if (VRControllerMGR.instance.checkControllerStatus(0, ViveControllerStatus.TouchpadClickPress))
        {
            if (my_main.now != null)
            {       

                if (my_answers.activeSelf == false)
                {
                    rs3_part = my_main.now;
                    Debug.Log(rs3_part);
                    rs3_select.Add(rs3_part);

                    if(rs3_part.name == "RS3_sotobako")
                    {

                    }





                }
               


            }
        }
    }

    void call_score()
    {


        if (VRControllerMGR.instance.checkControllerStatus(0, ViveControllerStatus.ApplicationMenuPress ))
        {

            Debug.Log("採点出す");


            if (my_score.activeSelf == false)
            {
                my_score.SetActive(true);
               
            }


        }
    }

    void ans_memory()
    {
        if(ans_memo.ContainsKey(rs3_part))
            ans_memo[rs3_part] = ans;
     
        else
            ans_memo.Add(rs3_part, ans);

        Debug.Log(ans_memo[rs3_part]);
    }

    void correct_ans()
    {
        foreach(GameObject parts in rs3_select)
        {
            true_ans.Add(parts, true);
            Debug.Log(true_ans);
        }
    }
}
