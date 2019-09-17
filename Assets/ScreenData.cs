using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class ScreenData : MonoBehaviour
{
    private bool IsShowData = true;
    ObjectPos objectPositionController;
    Vector3 [] objectPos = new Vector3[3];
    [SerializeField]
    Text PositionText, RotationText, ScaleText;


    void Start()
    {
        objectPositionController = FindObjectOfType<ObjectPos>();
        StartCoroutine(ShowData());
    }

    IEnumerator ShowData()
    {
        while(IsShowData)
        {
            if(objectPositionController != null)
                objectPos = objectPositionController.GetItemData();

            if(objectPos != null)
            {
                PositionText.text = objectPos[0].x + ", " + objectPos[0].y + ", " + objectPos[0].z;
                RotationText.text = objectPos[1].x + " , " + objectPos[1].y + " , " + objectPos[1].z;
                ScaleText.text = objectPos[2].x + " , " + objectPos[2].y + " , " + objectPos[2].z;
            }

            yield return new WaitForSeconds(.5f);
        }
    }
}
