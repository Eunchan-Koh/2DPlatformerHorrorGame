using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFootstepSound : MonoBehaviour
{
    public playerMove player;
    CircleCollider2D circleCollider;
    float dashRadius;
    float walkRadius;
    float crouchRadius;
    float stayRadius;
    // Start is called before the first frame update
    void Start()
    {   
        dashRadius = 10;
        walkRadius = 6;
        crouchRadius = 3;
        stayRadius = 0;
        circleCollider = GetComponent<CircleCollider2D>();
        if(circleCollider == null){
            Debug.Log("circleCollider is null");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Mathf.Abs(player.rigid.velocity.x) >= player.dashSpeed-0.5f){
            circleCollider.radius = dashRadius;
        }else if(Mathf.Abs(player.rigid.velocity.x) >= player.walkSpeed-0.5f){
            circleCollider.radius = walkRadius;
        }else if(Mathf.Abs(player.rigid.velocity.x) >= player.crouchSpeed-0.5f){
            circleCollider.radius = crouchRadius;
        }else{
            circleCollider.radius = stayRadius;
        }
    }
}
