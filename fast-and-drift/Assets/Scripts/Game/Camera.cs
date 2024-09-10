using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Camera : MonoBehaviour
{
    [SerializeField] private float speedFollow;
    [SerializeField] private float speedRot;
    public Vector3 offset;
    [SerializeField] private Transform objFollow;
    [SerializeField] private Vector3 posTarget;
    public float volumeMaster2;

    public void VolumeMaster(float volume)
    {
        volumeMaster2 = volume;
        AudioListener.volume = volumeMaster2;
    }

    private void Update()
    {

    }

    private void FixedUpdate()
    {
        FollowCar();
    }
    private void FollowCar(){
        posTarget = objFollow.TransformPoint(offset);

        transform.position = Vector3.Lerp(transform.position, posTarget, speedFollow * Time.deltaTime);

        Vector3 distanceTarget = objFollow.position -  transform.position;
        Quaternion newRot = Quaternion.LookRotation(distanceTarget, Vector3.up);

        transform.rotation = Quaternion.Lerp(transform.rotation, newRot, speedRot * Time.deltaTime);
    }
}
