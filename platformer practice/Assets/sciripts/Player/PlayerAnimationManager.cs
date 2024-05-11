using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationManager : MonoBehaviour
{
    public playerMove player;
    Animator anim;

    void Start(){
        anim = player.GetComponent<Animator>();
        if(anim == null){
            Debug.Log("anim is null!");
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(player.isMoving){
            anim.SetBool("isMoving", true);
        }else{
            anim.SetBool("isMoving", false);
        }   
        if(player.isCrouching){
            anim.speed = 0.5f;
            anim.SetBool("isCrouched", true);
        }else if(player.isDashing){
            anim.speed = 1.2f;
            anim.SetBool("isCrouched", false);
        }else{
            anim.speed = 1;
            anim.SetBool("isCrouched", false);
        }
    }
}
