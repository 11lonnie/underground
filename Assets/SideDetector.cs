using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class SideDetector : MonoBehaviour
{

    public bool left = false;

    public Opponent opponent;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other) {

        if (other.gameObject.layer == 6 || other.gameObject.layer == 3){
            if(left){
                opponent.leftCheck = true;
            } else{
                opponent.rightCheck = true;
            }
        }
    }

    private void OnTriggerExit(Collider other) {

        if (other.gameObject.layer == 6 || other.gameObject.layer == 3){
            if(left){
                opponent.leftCheck = false;
            } else{
                opponent.rightCheck = false;
            }
        }
    }
}
