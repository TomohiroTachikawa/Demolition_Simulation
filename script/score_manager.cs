using Dissonance;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class score_manager : MonoBehaviour
{
    my_menu2 my_Menu;
    record_keeper rec_keep;

    OtherObjectAction ooa_sc;
    GameObject score_board;
    UILabel result1, result2,result3;

    void Start()
    {
        my_Menu = GameObject.Find("main").GetComponent<my_menu2>();
        Debug.Log(my_Menu);
        rec_keep = GameObject.Find("CheckBoard").GetComponent<record_keeper>();
        make_true_answer();

        score_board = GameObject.Find("score_board");
        ooa_sc = score_board.transform.GetChild(6).gameObject.GetComponent<OtherObjectAction>();
        score_board.SetActive(false);

        Transform target_text = score_board.transform.Find("_num");
        result1 = target_text.GetComponent<UILabel>();
        Debug.Log(result1);
        Transform target_text2 = score_board.transform.Find("_rate");
        result2 = target_text2.GetComponent<UILabel>();
        Debug.Log(result2);
        Transform target_text3 = score_board.transform.Find("result");
        result3 = target_text3.GetComponent<UILabel>();
        Debug.Log(result3);

        rec_keep = GameObject.Find("CheckBoard").GetComponent<record_keeper>();
        make_true_answer();
    }


    void Update()
    {
        if (my_Menu.score_on == true)
        {

            Debug.Log("採点機能実装");
            my_Menu.score_on = false;

            judge();

        }

        if(score_board.activeSelf==true)
        close_result();

    }

    Hashtable true_Answer = new Hashtable();
    void make_true_answer()
    {
        true_Answer["RS3_sotobako"] = false;
        true_Answer["RS3_onoffhandle"] = false;
        true_Answer["RS3_handle"] = false;
        true_Answer["RS3_coverGaishi"] = false;
        true_Answer["RS3_gaishi"] = false;
        true_Answer["RS3_futa"] = false;
        true_Answer["RS3_bolt"] = false;
        true_Answer["RS3_settitanshi"] = false;
        
        Debug.Log(true_Answer["RS3_sotobako"]);
        Debug.Log(true_Answer["RS3_handle"]);
    }


    
    int correct_num = 0;
    int make_score()
    {

        
        foreach (GameObject obj in my_Menu.rs3_select)
        {
                Debug.Log(obj.name);
                Debug.Log(true_Answer[obj.name]);
                Debug.Log(rec_keep.my_ans_par[obj.name]);
            if (true_Answer[obj.name].ToString() == rec_keep.my_ans_par[obj.name].ToString())
            {
                correct_num++;
                Debug.Log("正解したパーツ：" + obj.name);
            }
                                        
        }
            
        Debug.Log(correct_num);

        return correct_num;

    }

    void judge()
    {
        make_score();
        float rate_corr;

        if (correct_num != 0)
            rate_corr = Mathf.Round(correct_num * 100 / true_Answer.Count);
        else
            rate_corr = 0;


        string score_num = "正解数：" + correct_num + " 個/" + true_Answer.Count + " 個";
        string score_rate = "正答率：" + rate_corr + "％";

        Debug.Log(score_num);
        Debug.Log(score_rate);

        result1.text = score_num;
        result2.text = score_rate;


        if (rate_corr >= 80)
        result3.text = "成功";
        else
        result3.text = "失敗";

        score_board.SetActive(true);



    }

    void close_result()
    {
       
        if (ooa_sc.param[0] > 0)
        {
            Debug.Log("閉じるが押された");

            score_board.SetActive(false);
            ooa_sc.param[0] = 0;

            Debug.Log("5秒後リセット");


        }

    }



}
