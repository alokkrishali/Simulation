using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerasController : MonoBehaviour
{
    [SerializeField]
    Camera FrontCam, TopCam, RotationCam;
    Camera currentCam;

    Transform SelectedCamera, parentTransform;

    [SerializeField]
    float CameraRotationSpeed = 8;

    [SerializeField]
    ObjectCreator objectsRef;
    Vector3 roateAround;

    public Camera Selectedcamera
    {
        get
        {
            return currentCam ;
        }
    }
    void Awake()
    {
        FrontCam.enabled = true;
        currentCam = FrontCam;
        parentTransform = GetComponentInParent<Transform>();
    }

    private void DisableAllCam()
    {
        FrontCam.enabled = false; TopCam.enabled = false; RotationCam.enabled = false;
    }

    public void EnableCamera(int index)
    {
        DisableAllCam();
        switch (index)
        {
            case 1:
                FrontCam.enabled = true;
                SelectedCamera = FrontCam.transform;
                RotationCam.transform.SetParent(parentTransform);
                roateAround = parentTransform.position;
                currentCam = FrontCam;
                break;
            case 2:
                TopCam.enabled = true;
                SelectedCamera = TopCam.transform;
                RotationCam.transform.SetParent(parentTransform);
                roateAround = parentTransform.position;
                currentCam = TopCam;
                break;
            case 3:
                RotationCam.enabled = true;
                SelectedCamera = RotationCam.transform;
                SelectedCamera.SetParent(objectsRef.currentObject.transform);
                SelectedCamera.localPosition = new Vector3(0, .5f, 4);
                roateAround = objectsRef.currentObject.transform.position;
                currentCam = null;
                break;
        }
    }

    void Update()
    {
        RotateCamera();
        HandleZoom();
    }
    [SerializeField]
    float zoom = 0;
    private void HandleZoom()
    {
        if (currentCam == null)
            return;

        if(Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            Debug.Log("+");

            currentCam.fieldOfView -= 2;

        }
        else if (Input.GetAxis("Mouse ScrollWheel")>0)
        {
            Debug.Log("-");
            currentCam.fieldOfView += 2;
        }
    }

    void RotateCamera()
    {
        if (!RotationCam.enabled)
            return;

        SelectedCamera.LookAt(objectsRef.currentObject.transform);
        SelectedCamera.RotateAround(roateAround, objectsRef.currentObject.transform.up, CameraRotationSpeed * Time.deltaTime);
    }
}
