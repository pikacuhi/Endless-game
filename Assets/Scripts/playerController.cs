using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 direction;
    public float forwardSpeed;

    private int desiredLane = 1;
    // 0 left 1 mid 2 right
    public float laneDistance = 4;

    public float jumpForce;
    public float gravity= -20;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {

            direction.z = forwardSpeed;
         

        //validasi dulu if player di ground dia bru bisa loncat(biar g infinite jump)
        if(controller.isGrounded){
            // direction.y = 0;
            if(Input.GetKeyDown(KeyCode.UpArrow)){
            Jump();
            }
        }else{//klo g d lantai 
            direction.y += gravity * Time.deltaTime; //buat gravitasi
        }


        if(Input.GetKeyDown(KeyCode.RightArrow)){
            desiredLane++;
            if(desiredLane == 3) desiredLane = 2;
        }

        if(Input.GetKeyDown(KeyCode.LeftArrow)){
            desiredLane--; 
            if(desiredLane == -1) desiredLane = 0;
        }

        //calculate where we should 

        Vector3 targetPosition = (transform.position.z * transform.forward) + (transform.position.y * transform.up);

        if(desiredLane == 0){
            targetPosition += Vector3.left * laneDistance;
        }else if(desiredLane == 2){
            targetPosition += Vector3.right * laneDistance;
        }

        // transform.position = targetPosition; biar lbh oke pake cara yg bwh
        // transform.position = Vector3.Lerp(transform.position, targetPosition, 75 * Time.fixedDeltaTime);
        // controller.center = controller.center;

        //biar obs yg 1 jalur ga nembus
        if(transform.position == targetPosition) return;
        Vector3 diff = targetPosition - transform.position;
        Vector3 moveDir = diff.normalized * 25 * Time.deltaTime;

        if(moveDir.sqrMagnitude < diff.sqrMagnitude) controller.Move(moveDir);
        else controller.Move(diff);
    }

    private void FixedUpdate(){
        controller.Move(direction*Time.fixedDeltaTime);
    }

    private void Jump(){

        direction.y = jumpForce;
    }

    private void OnControllerColliderHit(ControllerColliderHit hit){
        if(hit.transform.tag == "obstacle") {
            PlayerManager.gameOver = true;
        }
    }
}
