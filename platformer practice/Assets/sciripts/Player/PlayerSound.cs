using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSound : MonoBehaviour
{
    public playerMove player;
    public AudioClip walkSound;
    AudioSource audioSource;
    public bool moveSoundCool;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        moveSoundCool = false;
    }
    void moveSoundCoolCancel(){
        moveSoundCool = false;
    }
    void MoveSoundCheck(){
        float waittime;
        if(player.isCrouching){
            waittime = 0.5f;
        }else if(player.isDashing){
            waittime = 0.1f;
        }else{
            waittime = 0.25f;
        }
        if(player.actuallyMoving && !moveSoundCool){
            moveSoundCool = true;
            audioSource.clip = walkSound;
            audioSource.Play();
            Invoke("moveSoundCoolCancel", waittime);
        }else if(!player.actuallyMoving){
            audioSource.Stop();
        }
    }
    void Update()
    {
        MoveSoundCheck();
    }
}
