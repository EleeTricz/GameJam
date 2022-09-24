using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    

    public float speed;   

    public Camera cam; 

    private Vector3 goTo = new Vector3(0,0,-10);

    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();


    } 

    void Update()
    {

        float x= Input.GetAxisRaw("Horizontal");
        float y= Input.GetAxisRaw("Vertical");

        #region Move
        if(y==1)
        {
            transform.position += new Vector3(0,speed,0);
            anim.SetInteger("dir",2);
            anim.SetBool("walk1",true);
        }
        else if(x==1)
        {
            transform.position += new Vector3(speed,0,0);
            anim.SetInteger("dir",1);
            anim.SetBool("walk2",true);
        }
        else if(y== -1)
        {
            transform.position += new Vector3(0,-speed,0);
            anim.SetInteger("dir",0);
            anim.SetBool("walk",true);
        }
        else if(x== -1)
        {
            transform.position += new Vector3(-speed,0,0);
            anim.SetInteger("dir",3);
            anim.SetBool("walk3",true);
        }
        else
        {
            anim.SetBool("walk",false);
            anim.SetBool("walk1",false);
            anim.SetBool("walk2",false);
            anim.SetBool("walk3",false);
        }
        #endregion
        #region Cam 
            cam.transform.position = Vector3.LerpUnclamped(cam.transform.position,goTo,2*Time.deltaTime);

            if(transform.position.x > cam.transform.position.x +9)
            {
                goTo = new Vector3(cam.transform.position.x + 12,cam.transform.position.y,-10);
            }
            else if(transform.position.x < cam.transform.position.x -9)
            {
                goTo = new Vector3(cam.transform.position.x - 12,cam.transform.position.y,-10);
            }
            else if(transform.position.y > cam.transform.position.y +5)
            {
                goTo = new Vector3(cam.transform.position.x, cam.transform.position.y + 5,-10);
            }
            else if(transform.position.y < cam.transform.position.y -5)
            {
                goTo = new Vector3(cam.transform.position.x, cam.transform.position.y - 5,-10);
            }
        #endregion
    }
}
