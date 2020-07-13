using Dissonance;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class score_manager : MonoBehaviour
{
    my_menu2 my_Menu;
    record_keeper rec_keep;

    void Start()
    {
        my_Menu = GameObject.Find("main").GetComponent<my_menu2>();
        Debug.Log(my_Menu);
        rec_keep = GameObject.Find("main").GetComponent<record_keeper>();
        make_true_answer();
    }


    void Update()
    {
        if (my_Menu.score_on == true)
        {

            Debug.Log("採点機能実装");
            my_Menu.score_on = false;

            make_score();

        }



    }

    Hashtable true_Answer = new Hashtable();
    void make_true_answer()
    {
        true_Answer.Add("RS3_sotobako", false);
        true_Answer.Add("RS3_onoffhandle", false);
        true_Answer["RS3_handle"] = false;
        true_Answer["RS3_coverGaishi"] = false;
        true_Answer["RS3_gaishi"] = false;
        true_Answer["RS3_futa"] = false;
        true_Answer["RS3_bolt"] = false;
        true_Answer["RS3_settitanshi"] = false;

        Debug.Log(true_Answer["RS3_sotobako"]);
        Debug.Log(true_Answer["RS3_handle"]);
    }


    int all_num = 0;
    int correct_num = 0;
    void make_score()
    {

  
        for (int i = 0; i < true_Answer.Count; i++)
        {
                all_num++;

            foreach (GameObject obj in my_Menu.rs3_select)
            {
                Debug.Log(obj.name);
                Debug.Log(rec_keep.my_ans_par[obj.name]);
                if (true_Answer[obj.name] == rec_keep.my_ans_par[obj.name])
                    correct_num++;
               
            
            }
            
        }
        Debug.Log(correct_num);
    }


}
