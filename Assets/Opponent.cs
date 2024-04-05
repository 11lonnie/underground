using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Opponent : MonoBehaviour
{
    public bool leftCheck = false;
    public bool rightCheck = false;
    public float maxSpeed = 300;
    private float currentSpeed = 1;
    private int gear = 1;
    public int lane = 0;
    private float finalPosition;
    private float currentPosition;
    private Rigidbody rigid;
    private bool switchLock = false;

    // Start is called before the first frame update
    void Start()
    {
        // transform.position = new Vector3(transform.position.x, transform.position.y, lane * -3);
        rigid = GetComponent<Rigidbody>();
        currentPosition = lane * -3;
        finalPosition = currentPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentSpeed > 0){
            currentSpeed += maxSpeed/currentSpeed/1000;
            transform.Translate(currentSpeed*Time.deltaTime, 0, 0);
            transform.position = new Vector3(transform.position.x, transform.position.y, currentPosition);
            currentPosition = Mathf.SmoothStep(currentPosition, finalPosition, 30f * Time.deltaTime);
            if (Mathf.Abs(currentPosition) > Mathf.Abs(finalPosition) - 0.1){
                switchLock = false;
            }
        }
    }

    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.layer == 6){
            rigid.AddForce(currentSpeed * 1000, currentSpeed * 10, 0);
            currentSpeed = 0;
        }
    }
    public void LaneSwitch(){
        int laneSwitcher = 0;
        if(!switchLock){
            
            if(Random.Range(0,1) == 0){
                laneSwitcher = 1;
            } else{
                laneSwitcher = -1;
            }

            if (rightCheck){
                laneSwitcher = -1;
                if(lane == 0 || leftCheck)
                    laneSwitcher = 0;
            } else if (leftCheck){
                laneSwitcher = 1;
                if(lane == 3 || rightCheck)
                    laneSwitcher = 0;
            }

            print(laneSwitcher);
            switchLock = true;

            lane += laneSwitcher;
            
            finalPosition = lane * -3;
        }
        
    }
}
