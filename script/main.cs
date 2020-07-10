using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class main : MonoBehaviour
{
    public GameObject target;

    OtherObjectAction ooa;

    bool emit_on = false;

    RaycastHit hitinfo;
    Ray point;

    private GameObject screen;
    Ray ray;
    GameObject MovePointerRay0, MovePointerRay1;


    void Start()
    {
        if (GameObject.Find("VideoScreen") != null) screen = GameObject.Find("VideoScreen").gameObject;
        Debug.Log(screen);

    }


    void Update()
    {
        pointer_manage();
        point_marker(1, 0, 0);

    }


    public void pointer_manage()
    {
    

        if (VRPointer.instance.getHit(0).transform != null)
        {

            GameObject vrpoint = VRPointer.instance.getHit(0).collider.gameObject;
          
            if (vrpoint.transform.root.name != "rs3")
            {
   
                target = null;
            }
            else 
            {

                target = VRPointer.instance.getHit(0).collider.gameObject;
            }

        }
        else target = null; 
   
    }


    public GameObject now;
    GameObject old;

    public void point_marker(float rr, float gg, float bb)
    {
  
        now = target;

        if (target != null)
        {

                Renderer r = target.gameObject.GetComponent<MeshRenderer>();
                r.material.EnableKeyword("_EMISSION");
                r.material.SetColor("_EmissionColor", new Color(rr, gg, bb));

                if (now != null)
                {
                    if (old != now & old != null)
                    {
                        emit0();
                    }
                }
                else
                {
                    emit0();
                }
   


        }

        if(target== null & old != null)
        {
            emit0();
        }

        old = now;
    }


    public void emit0()
    {
    
            Renderer r2 = old.gameObject.GetComponent<MeshRenderer>();
            r2.material.EnableKeyword("_EMISSION");
            r2.material.SetColor("_EmissionColor", new Color(0, 0, 0)); 

    }



}
