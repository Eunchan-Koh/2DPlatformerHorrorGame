using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySoundDetection : MonoBehaviour
{
    public bool heard;
    public Vector2 heardFrom;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D collision){
        if(collision.gameObject.layer == 9){
            Debug.Log("he heard you!");
            heardFrom = collision.gameObject.transform.position;
            heard = true;
        }
    }
    void OnTriggerExit2D(Collider2D collision){
        if(collision.gameObject.layer == 9){
            Debug.Log("he lost your sound!");
            heardFrom = collision.gameObject.transform.position;
            heard = false;
        }
    }
}
