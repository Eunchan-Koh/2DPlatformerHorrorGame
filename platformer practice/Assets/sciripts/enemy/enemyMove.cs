using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;

public class enemyMove : MonoBehaviour
{
    CapsuleCollider2D capsuleCollider;
    Rigidbody2D rigid;
    public enemySoundDetection soundDetect;
    public float dir;
    public float roamDir;
    public float chaseSpeed;
    public float roamSpeed;
    public float opSpeed;
    public bool chasing;
    public bool thinking;
    // Start is called before the first frame update
    void Start()
    {
        capsuleCollider = GetComponent<CapsuleCollider2D>();
        rigid = GetComponent<Rigidbody2D>();
        chaseSpeed = 11;
        opSpeed = 1;
        roamSpeed = 5;
        thinking = false;
        Think();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(soundDetect.heard && rigid.position.x >= soundDetect.heardFrom.x-0.3f && rigid.position.x <= soundDetect.heardFrom.x+0.3f){
            // Debug.Log("not here?");
            soundDetect.heard = false;
        }
        
    }

    void FixedUpdate(){
        if(soundDetect.heard){
            CancelInvoke("chaseCancel");
            chasing = true;
        }else{
            Invoke("chaseCancel", 0.3f);
        }
        if(chasing){
            Move();
        }else{
            Roam();
        }
    }
    void Think(){
        roamDir = UnityEngine.Random.Range(-1,2);
        // Move();//pushes once every 3 sec(think is called)
        Invoke("Think", 2f);
    }
    void Roam(){
        rigid.velocity = new Vector2(roamDir*roamSpeed, rigid.velocity.y);
    }
    void chaseCancel(){
        chasing = false;
    }
    void Move(){
        // rigid.velocity = new Vector2(dir*moveSpeed, rigid.velocity.y);
        if(soundDetect.heardFrom.x > rigid.position.x){//player is on right side
            dir = 1;
        }else if(soundDetect.heardFrom.y > rigid.position.y){
            dir = -1;
        }
        // transform.position = Vector3.Lerp(transform.position,soundDetect.heardFrom+new Vector2(0,0),Time.deltaTime*2);
        // rigid.velocity = new Vector2(dir*moveSpeed, rigid.velocity.y);
        
        
        // rigid.AddForce(Vector2.right*dir*2, ForceMode2D.Impulse);
        rigid.velocity = new Vector2(rigid.velocity.x+(opSpeed*dir), rigid.velocity.y);
        
        if(Mathf.Abs(rigid.velocity.x)>=chaseSpeed){
            //limit speed to 11
            rigid.velocity = new Vector2(dir*chaseSpeed, rigid.velocity.y);
        }
    }
}
