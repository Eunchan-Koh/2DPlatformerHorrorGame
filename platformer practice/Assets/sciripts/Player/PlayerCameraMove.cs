using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerCameraMove : MonoBehaviour
{
    public playerMove player;
    Vector3 cameraPosition;
    public float cameraSpeed;

    public bool isLimited;
    public mapManager map;
    public GameManager Gmanager;
    public Camera playerCamera;
    public float normalCameraSize;
    public float hideCameraSize;
    public float hideCameraSpeed;
    public float cameraCurSize;
    
    
    // Start is called before the first frame update
    void Awake()
    {
        cameraSpeed = 3;
        cameraPosition = new Vector3(0,0,-10);
        isLimited = false;
        normalCameraSize = 10;
        hideCameraSize = 3;
        hideCameraSpeed = 3;
        cameraCurSize = normalCameraSize;
    }
    float Lerp(float p1, float p2, float d1) {
        if(d1>1){
            return p2;
        }else if(d1<0){
            return p1;
        }
        return (1-d1)*p1 + d1*p2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate(){
        if(player.hiding){
            transform.position = Vector3.Lerp(transform.position, player.ObjectInteract.location+cameraPosition, Time.deltaTime*cameraSpeed);
            cameraCurSize = Lerp(cameraCurSize, hideCameraSize, Time.deltaTime*hideCameraSpeed);
            playerCamera.orthographicSize = cameraCurSize;
        }else{
            transform.position = Vector3.Lerp(transform.position, player.transform.position+cameraPosition, Time.deltaTime*cameraSpeed);
            cameraCurSize = Lerp(cameraCurSize, normalCameraSize, Time.deltaTime*hideCameraSpeed);
            playerCamera.orthographicSize = cameraCurSize;
        }
        if(player.teleporting){
            cameraSpeed = 100;
        }else{
            cameraSpeed = 3;
        }
        CameraLock();
        CameraLockCancel();
        
    }
    void CameraLock(){
        float lx = map.mapsizeX - map.width;
        float clampX = Mathf.Clamp(transform.position.x, map.tempCenter.x - lx, map.tempCenter.x + lx);
        float ly = map.mapsizeY - map.height;
        float clampY = Mathf.Clamp(transform.position.y, map.tempCenter.y - ly, map.tempCenter.y + ly);
        float tempX = map.tempCenter.x+lx;
        float tempY = map.tempCenter.y+ly;
        if(transform.position.x <= tempX && transform.position.y <= tempY && !Gmanager.isBattleOver){
            isLimited = true;
        }
        if(isLimited){
            transform.position = new Vector3(clampX, clampY, -10);
        }
    }
    
    public void CameraLockCancel(){
        if(Input.GetKey(KeyCode.X)){
            isLimited = false;
        }
    }
}
