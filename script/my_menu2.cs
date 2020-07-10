using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sentinel;
using DigitalRuby.WeatherMaker;
using OculusSampleFramework;
using Boo.Lang.Environments;

public class my_menu2 : MonoBehaviour
{
    GameObject my_score;
    GameObject my_rs3Menu;


   OtherObjectAction ooa, ooa2;
   OtherObjectAction ooa_1, ooa_2, ooa_3, ooa_4, ooa_5, ooa_6, ooa_7, ooa_8, ooa_9 ,ooa_10, ooa_11, ooa_12;

    main my_main;

    public bool ans_on;
    public int ans_num;
    public bool ans;

    public bool score_on;

    public bool ans_par;
    public bool click_button;
    public bool click_close;
    public bool ans_push =false;
    public bool rs3_push = false;

    public GameObject now_activ;
    public GameObject futa_func;
    public GameObject switch_func;
    public GameObject handle_func;
    public GameObject coverGaishi_func;

    void Start()
    {
        my_main = GameObject.Find("main").GetComponent<main>();

        my_score = GameObject.Find("my_score");
        ooa = my_score.transform.GetChild(1).gameObject.GetComponent<OtherObjectAction>();
        ooa2 = my_score.transform.GetChild(2).gameObject.GetComponent<OtherObjectAction>();
        my_score.SetActive(false);


        my_rs3Menu = GameObject.Find("my_rs3Menu");
    

        futa_func = my_rs3Menu.transform.Find("futa").gameObject;
        ooa_1 = futa_func.transform.Find("CheckPointFrame/answerZone/Yes").GetComponent<OtherObjectAction>();
        ooa_2 = futa_func.transform.Find("CheckPointFrame/answerZone/No").GetComponent<OtherObjectAction>();
        ooa_3 = futa_func.transform.Find("Close").GetComponent<OtherObjectAction>();
        futa_func.SetActive(false);

        switch_func = my_rs3Menu.transform.Find("switch").gameObject;
        ooa_4 = switch_func.transform.Find("CheckPointFrame/answerZone/Yes").GetComponent<OtherObjectAction>();
        ooa_5 = switch_func.transform.Find("CheckPointFrame/answerZone/No").GetComponent<OtherObjectAction>();
        ooa_6 = switch_func.transform.Find("Close").GetComponent<OtherObjectAction>();
        switch_func.SetActive(false);

        handle_func = my_rs3Menu.transform.Find("handle").gameObject;
        ooa_7 = handle_func.transform.Find("CheckPointFrame/answerZone/Yes").GetComponent<OtherObjectAction>();
        ooa_8 = handle_func.transform.Find("CheckPointFrame/answerZone/No").GetComponent<OtherObjectAction>();
        ooa_9 = handle_func.transform.Find("Close").GetComponent<OtherObjectAction>();
        handle_func.SetActive(false);

        coverGaishi_func = my_rs3Menu.transform.Find("coverGaishi").gameObject;
        ooa_10 = coverGaishi_func.transform.Find("CheckPointFrame/answerZone/Yes").GetComponent<OtherObjectAction>();
        ooa_11= coverGaishi_func.transform.Find("CheckPointFrame/answerZone/No").GetComponent<OtherObjectAction>();
        ooa_12 = coverGaishi_func.transform.Find("Close").GetComponent<OtherObjectAction>();
        coverGaishi_func.SetActive(false);

     

        now_activ = futa_func;
        now_activ.SetActive(false);
        my_rs3Menu.SetActive(false);

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


        use_ooa(ooa_1, ooa_2, ooa_3);
        use_ooa(ooa_4, ooa_5, ooa_6);
        use_ooa(ooa_7, ooa_8, ooa_9);
        use_ooa(ooa_10, ooa_11, ooa_12);




    }

    void use_ooa(OtherObjectAction par1, OtherObjectAction par2, OtherObjectAction par3)
    {
        if (par1.param[0] > 0)
        {
            Debug.Log("ありが押された");
            ans_par = true;
            par1.param[0] = 0;
            ans_push = true;
 
        }

        if (par2.param[0] > 0)
        {
            ans_par = false;
            Debug.Log("なしが押された");
            par2.param[0] = 0;
            ans_push = true;
        }

        if (par3.param[0] > 0)
        {
            Debug.Log("閉じるが押された");
            par3.param[0] = 0;
            now_activ.SetActive(false);
            my_rs3Menu.SetActive(false);
        }
    }

    GameObject rs3_part;
    public List<GameObject> rs3_select = new List<GameObject>();
    public int exist_num;
    public bool exist_part;
    void call_menu()
    {


        if (VRControllerMGR.instance.checkControllerStatus(0, ViveControllerStatus.TouchpadClickPress))
        {
            Debug.Log(my_main);
            Debug.Log(now_activ.activeSelf);

            if (my_main.now != null& now_activ.activeSelf == false)
            {
                
                rs3_push = true;
                rs3_part = my_main.now;
               

                if (rs3_select.Contains(rs3_part))
                {
                    exist_num = rs3_select.IndexOf(rs3_part);
                    exist_part = true;
                }
                else
                {
                    rs3_select.Add(rs3_part);
                    exist_part = false;
                }
                             
     
                if (rs3_part.name == "RS3_sotobako")
                {
                    now_activ = futa_func;
                    my_rs3Menu.SetActive(true);
                    futa_func.SetActive(true);
                
                }

                if (rs3_part.name == "RS3_onoffhandle")
                {
                    now_activ = switch_func;
                    my_rs3Menu.SetActive(true);
                    switch_func.SetActive(true);
                }

                if (rs3_part.name == "RS3_handle")
                {
                    now_activ = handle_func;
                    my_rs3Menu.SetActive(true);
                    handle_func.SetActive(true);
                }

                if (rs3_part.name == "RS3_coverGaishi")
                {
                    now_activ = coverGaishi_func;
                    my_rs3Menu.SetActive(true);
                    coverGaishi_func.SetActive(true);
                }

            }
            Debug.Log(my_main.now);
        }
    }

    void call_score()
    {


        if (VRControllerMGR.instance.checkControllerStatus(0, ViveControllerStatus.ApplicationMenuPress))
        {

           


            if (my_score.activeSelf == false)
            {
                my_score.SetActive(true);

            }


        }
    }



    public Hashtable ans_memo = new Hashtable();
    public Hashtable true_ans = new Hashtable();
    public Hashtable obj_menu = new Hashtable();


}
