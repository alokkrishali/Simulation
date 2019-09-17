using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPos : MonoBehaviour
{
    [SerializeField]
    Vector3 pos;

    [SerializeField]
    CamerasController thisCaController;

    int layerMask = 1 << 9;

    void Start()
    {
        thisCaController = GameObject.FindObjectOfType<CamerasController>();
    }
    [SerializeField]
    Transform selectedTransform;

    public Vector3 [] GetItemData()
    {
        if (selectedTransform == null)
            return null;

        return new Vector3[3] { selectedTransform.localPosition, selectedTransform.localEulerAngles, selectedTransform.localScale };
    }
    Vector3 posVector;
    // Update is called once per frame
    void Update()
    {
        if (thisCaController.Selectedcamera == null)
            return;
       
        if (Input.GetMouseButtonDown(0))
        {
            Ray thisRay = thisCaController.Selectedcamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit info;

            if (Physics.Raycast(thisRay, out info, 200, layerMask))
            {
                selectedTransform = info.transform;
            }
        }
        else if (Input.GetMouseButton(0))
        {
            Ray thisRay = thisCaController.Selectedcamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit info;

            if (Physics.Raycast(thisRay, out info, 200, layerMask))
            {
                posVector = info.point;
                posVector.y = selectedTransform.position.y;
                selectedTransform.position = posVector;
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            selectedTransform = null;
        }

    }
}
