using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public playerMove player;
    public PlayerCameraMove pCamera;
    public mapManager map;
    public GameObject bossWall;
    //temp var
    public bool isBattleOver;
    void Start(){
        isBattleOver = false;
    }
    void FixedUpdate(){
        if(map.isOnBossField && !isBattleOver){
            bossWall.SetActive(true);
        }else{
            bossWall.SetActive(false);
        }
    }
}
