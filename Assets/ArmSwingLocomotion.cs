using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmSwingLocomotion : MonoBehaviour
{
    [SerializeField] CharacterController characterController;

    [SerializeField] GameObject leftHand, rightHand;

    Vector3 previousPosLeft, previousPosRight, direction;

    Vector3 gravity = new Vector3(0, -9.8f, 0);

    [SerializeField] float speed = 4;
    // Start is called before the first frame update
    void Start()
    {
        SetPreviousPos();
    }

    // Update is called once per frame
    void Update()
    {
        //Calculate the velocity of the player hand movement
        Vector3 leftHandVelocity = leftHand.transform.position - previousPosLeft;
        Vector3 rightHandVelocity = rightHand.transform.position - previousPosRight;
        float totalVelocity = +leftHandVelocity.magnitude * 1f + rightHandVelocity.magnitude * 1f;

        if(totalVelocity >= 0.05f) // true if player swang their hand
        {
            //getting the direction that the player is facing
            direction = Camera.main.transform.forward;
            //move the player using character controller
            characterController.Move(speed * Time.deltaTime * Vector3.ProjectOnPlane(direction, Vector3.up));
        }

        //applying gravity
        characterController.Move(gravity * Time.deltaTime);
        SetPreviousPos();
    }

    void SetPreviousPos()
    {
        previousPosLeft = leftHand.transform.position;
        previousPosRight = rightHand.transform.position;
    }
}
