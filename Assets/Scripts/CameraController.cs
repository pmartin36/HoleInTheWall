using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Camera Camera { get; private set; }
    private CinemachineBrain brain;
    private ICinemachineCamera vCamera => brain.ActiveVirtualCamera;
    private Transform vCameraTransform => vCamera.VirtualCameraGameObject.transform;

    private Quaternion resetRotatation;

    private Transform focus;
    private Vector3 lastFocusPoint;

    public float FollowDistance { get; private set; }

    void Start()
    {
        Camera = GetComponent<Camera>();
        brain = GetComponent<CinemachineBrain>();
        resetRotatation = vCameraTransform.rotation;
        FollowDistance = 7f;
    }

    public void SetFocus(Transform f)
    {
        focus = f;
        lastFocusPoint = f.position;
    }

    void Update()
    {
        Move(focus.position - lastFocusPoint);
        lastFocusPoint = focus.position;
    }

    public void Rotate(Vector3 euler)
    {
        vCameraTransform.rotation = Quaternion.Euler(0f, euler.y, 0f) * vCameraTransform.rotation;
        vCameraTransform.rotation = vCameraTransform.rotation * Quaternion.Euler(-euler.x, 0f, 0f);

        vCameraTransform.position = focus.position - vCameraTransform.forward * FollowDistance;

        //vCameraTransform.RotateAround(rotationBody, Vector3.right, euler.x);
        //vCameraTransform.RotateAround(rotationBody, Vector3.up, euler.y);
    }

	public void ResetView()
	{
        vCameraTransform.rotation = resetRotatation;
        vCameraTransform.position = focus.position - vCameraTransform.forward * FollowDistance;
    }

    public void Move(Vector3 delta)
    {
        vCameraTransform.position += delta;
    }
}
