using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapManager : MonoBehaviour
{
    public playerMove player;
    public PlayerCameraMove playerCamera;
    public Vector2 tempCenter;
    public float height;
    public float width;
    public float mapsizeX;
    public float mapsizeY; 
    public bool isOnBossField;
    public GameObject mapCenter;
    void Awake(){
        // tempCenter = new Vector2(338f,-100.9f);
        tempCenter = mapCenter.transform.position;
        height = Camera.main.orthographicSize;
        width = height * Screen.width/Screen.height;
        mapsizeX = 23;
        mapsizeY = 13.16f;
        isOnBossField = false;
    }
    void FixedUpdate(){
        MapsizeCheck();
    }
    
    void MapsizeCheck(){
        if(!playerCamera.isLimited){
            //vertical rays
            Debug.DrawRay(player.rigid.position - new Vector2(mapsizeX, mapsizeY), Vector2.up*mapsizeY*2, Color.green);
            Debug.DrawRay(player.rigid.position + new Vector2(mapsizeX, mapsizeY), Vector2.down*mapsizeY*2, Color.green);
            //horizontal rays
            Debug.DrawRay(player.rigid.position - new Vector2(mapsizeX, mapsizeY), Vector2.right*mapsizeX*2, Color.green);
            Debug.DrawRay(player.rigid.position + new Vector2(mapsizeX, mapsizeY), Vector2.left*mapsizeX*2, Color.green);
        }else{
            Debug.DrawRay(tempCenter-new Vector2(mapsizeX, mapsizeY), Vector2.up*mapsizeY*2, Color.green);
            Debug.DrawRay(tempCenter+new Vector2(mapsizeX, mapsizeY), Vector2.down*mapsizeY*2, Color.green);
            //horizontal rays
            Debug.DrawRay(tempCenter-new Vector2(mapsizeX, mapsizeY), Vector2.right*mapsizeX*2, Color.green);
            Debug.DrawRay(tempCenter+new Vector2(mapsizeX, mapsizeY), Vector2.left*mapsizeX*2, Color.green);
            Debug.DrawRay(tempCenter, Vector2.left*mapsizeX*2, Color.green);
        }
        if(playerCamera.isLimited){
            isOnBossField = true;
        }else{//entered boss field
            isOnBossField = false;
        }
        
    }
}
