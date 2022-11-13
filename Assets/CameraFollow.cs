using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RacingCarMultiPlayer
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private Vector3 offset;
        [SerializeField] private Transform carTransform;
        [SerializeField] private float translateSpeed;
        [SerializeField] private float rotationSpeed;

        [SerializeField] private PhotonView view;
        private void FixedUpdate() { 
            HandleTranslation();
            HandleRotation();
            Debug.Log(carTransform.transform.position);
        }
        private void HandleTranslation()
        {
            var targetPosition = carTransform.TransformPoint(offset);
            transform.position = Vector3.Lerp(transform.position, targetPosition, translateSpeed * Time.deltaTime);
        }
        private void HandleRotation()
        {
            var direction = carTransform.position - transform.position;
            var rotation = Quaternion.LookRotation(direction, Vector3.up);

            transform.rotation = Quaternion.Lerp(transform.rotation, rotation,rotationSpeed * Time.deltaTime);
        }
    }
}
