using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossPunch : MonoBehaviour
{
    public float chaseSpeed;
    public float smashSpeed;
    public playerMove player;
    int randomNum;
    bool isOnPattern;
    public float normalHeight;
    public float PatternOneHeight;
    bool isResting;
    Vector3 newloc;
    public int statusIndex;
    bool aimed;
    public float coolTime;
    public float zVal;
    void Awake(){
        chaseSpeed = 8f;
        smashSpeed = 10f;
        randomNum = Random.Range(1,3);
        isOnPattern = false;
        normalHeight = 5;
        PatternOneHeight = 7;
        isResting = true;
        newloc = Vector3.zero;
        statusIndex = 0;
        StatusUpdate();
        aimed = false;
        coolTime = 3f;
        zVal = -1;
    }
    void FixedUpdate(){
            if(statusIndex == 1){
                newloc = new Vector3(player.transform.position.x, player.transform.position.y+normalHeight, zVal);
                transform.position = Vector3.Lerp(transform.position, newloc, Time.deltaTime*chaseSpeed);
                coolTime = 3f;
                //resting finished after 3 seconds
            }else if(statusIndex == 2){
                //after 3 seconds, hold hand a bit higher
                newloc = new Vector3(player.transform.position.x, player.transform.position.y+PatternOneHeight, zVal);
                transform.position = Vector3.Lerp(transform.position, newloc, Time.deltaTime*chaseSpeed);
                coolTime = 0.5f;
            }else if(statusIndex == 3){
                //after 3 seconds, stop for 0.5s
                if(!aimed){
                    aimed = true;
                    newloc = new Vector3(player.transform.position.x, player.transform.position.y+PatternOneHeight+1, zVal);
                }
                transform.position = Vector3.Lerp(transform.position, newloc, Time.deltaTime*10);
                coolTime = 2.5f;
            }else if(statusIndex == 4){
                aimed = false;
                // Vector2 checkedLoc = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
                //after 0.5s, smashes
                // newloc = checkedLoc;
                transform.position = Vector3.Lerp(transform.position, new Vector3(newloc.x, player.transform.position.y, newloc.z), Time.deltaTime*smashSpeed);
                coolTime = 3f;
            }
                
            
            
        
    }
    void StatusUpdate(){
        statusIndex++;
        if(statusIndex>4)statusIndex=1;
        Invoke("StatusUpdate",coolTime);
    }
    void Stopforsec(){
        aimed = false;
    }

}
