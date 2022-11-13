using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace RacingCarMultiPlayer
{
    public class CarController : MonoBehaviour
    {
        private const string HORIZONTAL = "Horizontal";
        private const string VERTICAL = "Vertical";

        private float horizontalInput;
        private float verticalInput;
        private float currentSteerAngle;
        private float currentBreakForce;
        private bool isBreaking;

        [Header("Car Features")]
        [SerializeField] private float motorForce;
        [SerializeField] private float breakForce;
        [SerializeField] private float maxSteerAngle;
        [SerializeField] private PhotonView view;
        [SerializeField] private PhotonView NickName;
        [SerializeField] private Rigidbody rigid;

        [Header("WheelCollider")]
        [SerializeField] private WheelCollider frontLeftWheelColider;
        [SerializeField] private WheelCollider frontRightWheelColider;
        [SerializeField] private WheelCollider rearLeftWheelColider;
        [SerializeField] private WheelCollider rearRightWheelColider;

        [Header("WheelTransform")]
        [SerializeField] private Transform frontLeftWheelTransform;
        [SerializeField] private Transform frontRightWheelTransform;
        [SerializeField] private Transform rearLeftWheelTransform;
        [SerializeField] private Transform rearRightWheelTransform;

        [Header("Camera Follow")]
        [SerializeField] Camera camera;

        private void FixedUpdate()
        {
            if (view.IsMine)
            {
                GetInput();
                HandleMotor();
                HandleSteering();
                UpdateWheels();
            }

            if(!view.IsMine)
            {
                Destroy(camera);
                NickName.GetComponent<TextMesh>().text = view.Owner.NickName;
            }
        }

        private void GetInput()
        {
            horizontalInput = Input.GetAxis(HORIZONTAL);
            verticalInput = Input.GetAxis(VERTICAL);
            isBreaking = Input.GetKey(KeyCode.Space);
        }
        private void HandleMotor()
        {
            rearLeftWheelColider.motorTorque = verticalInput * motorForce;
            rearRightWheelColider.motorTorque = verticalInput * motorForce;
            //currentBreakForce = isBreaking ? breakForce : 0;

            if (isBreaking)
            {
                ApplyBreaking();
            }
        }

        private void ApplyBreaking()
        {
            frontRightWheelColider.brakeTorque = currentBreakForce;
            frontLeftWheelColider.brakeTorque = currentBreakForce;
            rearRightWheelColider.brakeTorque = currentBreakForce;
            rearLeftWheelColider.brakeTorque = currentBreakForce;
        }

        private void HandleSteering()
        {
            currentSteerAngle = maxSteerAngle * horizontalInput;
            frontLeftWheelColider.steerAngle = currentSteerAngle;
            frontRightWheelColider.steerAngle = currentSteerAngle;
        }
        private void UpdateWheels()
        {
            UpdateSingleWheel(frontLeftWheelColider,frontLeftWheelTransform.transform);
            UpdateSingleWheel(frontRightWheelColider, frontRightWheelTransform.transform);
            UpdateSingleWheel(rearRightWheelColider, rearRightWheelTransform.transform);
            UpdateSingleWheel(rearLeftWheelColider, rearLeftWheelTransform.transform);
        }

        private void UpdateSingleWheel(WheelCollider wheelColider, Transform wheelTransform)
        {
            Vector3 pos;
            Quaternion rot;
            wheelColider.GetWorldPose(out pos, out rot);
            wheelTransform.rotation = rot;
            //wheelTransform.position = pos;
        }
    }
}
