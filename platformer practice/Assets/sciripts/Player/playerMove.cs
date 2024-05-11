using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Diagnostics.Tracing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;
using UnityEngine.EventSystems;

public class playerMove : MonoBehaviour
{
    float h;
    float MoveSpeed;
    public Rigidbody2D rigid;
    public bool isJumping;
    public float JumpPower;
    Vector2 rayposition;
    CapsuleCollider2D capsule;
    SpriteRenderer spriteRenderer;
    public bool isMoving;
    public bool isCrouching;
    public bool isDashing;
    public bool actuallyRunning;
    public bool actuallyMoving;
    public float walkSpeed;
    public float crouchSpeed;
    public float dashSpeed;
    public float stamina;
    public float staminaReduceSpeed;
    public float staminaRecoverSpeed;
    public bool dashable;
    public PlayerObjectInteract ObjectInteract;
    public bool hiding;
    bool hidingCooldown;
    public PlayerFootstepSound footSound;
    public bool teleportCooldown;
    public bool teleporting;
   

    // Start is called before the first frame update
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        if(rigid == null){
            Debug.Log("rigid is null!");
        }
        MoveSpeed = 10f;
        isJumping = false;
        JumpPower = 10;
        capsule = GetComponent<CapsuleCollider2D>();
        if(capsule == null){
            Debug.Log("capsule is null!");
        }
        spriteRenderer = GetComponent<SpriteRenderer>();
        if(spriteRenderer == null){
            Debug.Log("spriteRenderer is null!");
        }
        isMoving = false;
        dashSpeed = 15f;
        walkSpeed = 10f;
        crouchSpeed = 3f;
        isDashing = false;
        stamina = 100;
        actuallyRunning = false;
        actuallyMoving = false;
        staminaReduceSpeed = 60;
        staminaRecoverSpeed = 30;
        dashable = true;
        hiding = false;
        hidingCooldown = false;
        teleportCooldown = false;
        teleporting = false;
        
        
        
    }

    // Update is called once per frame
    void Update()
    {   
        if(!hiding){
            MoveHor();
            Crouch();
            Jump();
            Dash();
        }else{
            rigid.velocity = Vector2.zero;
        }
        CheckMoving();
        CheckRunning();
        StaminaManage();
        Hide();
        HideLayerCheck();
        Teleport();
        DebugLoc();
        
    }
    
    
    void DebugLoc(){
        if(Input.GetKey(KeyCode.X)){
            rigid.position = new Vector2(373.3f, 16);
        }
    }
    void OnCollisionStay2D(Collision2D collision){
        //ground
        if(collision.gameObject.layer == 6){
            isJumping = false;
        }
        
    }
    void MoveHor(){
        h = Input.GetAxisRaw("Horizontal");
        rigid.velocity = new Vector2(h*MoveSpeed,rigid.velocity.y);
        if(h>0){
            spriteRenderer.flipX = false;
        }else if(h<0){
            spriteRenderer.flipX = true;
        }
        if(h==0){
            isMoving = false;
        }else{
            isMoving = true;
        }
    }
    void Crouch(){
        float yScale;
        float Offset;
        if(Input.GetKey(KeyCode.DownArrow)){
            yScale = 1;
            Offset = -0.8f;
            MoveSpeed = crouchSpeed;
            isCrouching = true;
        }else{
            yScale = 2.8f;
            Offset = 0;
            MoveSpeed = walkSpeed;
            isCrouching = false;
        }
        
        capsule.offset = new Vector2(capsule.offset.x, Offset);
        capsule.size = new Vector2(capsule.size.x, yScale);
        // transform.localScale = new Vector3(transform.localScale.x, yScale, transform.localScale.z);
        // transform.position = new Vector3(transform.position.x, transform.position.y-offSet,transform.position.z);
        
    }
    void Dash(){
        if(Input.GetKey(KeyCode.LeftShift) && !isCrouching && dashable){
            isDashing = true;
            MoveSpeed = dashSpeed;

        }else{
            isDashing = false;            
        }

    }
    void CheckMoving(){
        if(isMoving&&rigid.velocity!=Vector2.zero)
        actuallyMoving = true;
        else
        actuallyMoving = false;

    }
    void CheckRunning(){
        if(Mathf.Abs(rigid.velocity.x) >= dashSpeed - 0.5f){
            actuallyRunning = true;
        }else{
            actuallyRunning = false;
        }
    }
    void StaminaManage(){
        if(actuallyRunning){
            //based on real-time, reduce stamina by 1 every 0.1sec
            stamina -= staminaReduceSpeed*Time.deltaTime;
            if(stamina<=0){
                stamina = 0;
                // Debug.Log("out of stamina!");
                dashable = false;
                Invoke("FinishResting", 2f);
            }
            // Debug.Log("stamina is decreasing!: " + stamina);
        }else{
            //based on real-time, increase stamina by 1 every 0.2sec
            stamina += staminaRecoverSpeed*Time.deltaTime;
            if(stamina>=100){
                stamina = 100;
            }
            // Debug.Log("stamina is increasing!: " + stamina);
            
        }

    }
    void FinishResting(){
        dashable = true;
    }

    void Hide(){
        if(Input.GetKey(KeyCode.Z)){
            if(hidingCooldown){
                
            }else{
                hidingCooldown = true;
                if(ObjectInteract.hidable && !hiding){
                    Debug.Log("hided!!");
                    hiding = true;
                }else if(ObjectInteract.hidable && hiding){
                    Debug.Log("Exited!!");
                    hiding = false;
                }
                if(ObjectInteract.pickable){
                    Debug.Log("picked!");
                    ObjectInteract.interactedObject.SetActive(false);
                }
                Invoke("hidingCooldownCheck", 0.5f);
            }
            
        }
        
    }
    void hidingCooldownCheck(){
        hidingCooldown = false;
    }

    void HideLayerCheck(){
        if(hiding){
            this.gameObject.layer = 10;
            footSound.gameObject.layer = 10;
            // this.gameObject.SetActive(false);
            spriteRenderer.color = new Color(1,1,1,0);
        }else{
            this.gameObject.layer = 9;
            footSound.gameObject.layer = 9;
            // this.gameObject.SetActive(true);
            spriteRenderer.color = new Color(1,1,1,1);
        }
    }

    void Teleport(){
        if(Input.GetKey(KeyCode.Z)){
            if(teleportCooldown){

            }else{
                teleportCooldown = true;
                if(ObjectInteract.teleportable){
                    teleporting = true;
                   TeleportMove();
                }
                Invoke("TeleportCooldownCancel",0.2f);
                Invoke("TeleportingCancel", 0.2f);
            }
        }
    }
    void TeleportMove(){
        transform.position = ObjectInteract.location;
    }
    void TeleportingCancel(){
        teleporting = false;
    }
    void TeleportCooldownCancel(){
        teleportCooldown = false;
    }

    void Jump(){
        if(!isJumping && Input.GetButtonDown("Jump")){
            isJumping = true;
            JumpCheck();
            
        }
    }
    void JumpCheck(){
        rigid.velocity = Vector2.zero;
        rigid.AddForce(Vector2.up*JumpPower, ForceMode2D.Impulse);
        // Debug.Log("jump!!!");

    }
    void JumpCancel(){
        isJumping = false;
    }
}
