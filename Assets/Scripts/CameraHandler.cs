using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHandler : MonoBehaviour
{

    public GameObject cameraGameObject;

    Vector2 StartPosition;
    Vector2 DragStartPosition;
    Vector2 DragNewPosition;
    Vector2 Finger0Position;
    float DistanceBetweenFingers;

    void Update()
    {
        if(Input.touchCount == 2){
                if(Input.GetTouch(0).phase == TouchPhase.Moved){
                    Vector2 NewPosition = GetWorldPosition();
                    Vector2 PositionDifference = NewPosition - StartPosition;
                    cameraGameObject.transform.Translate(-PositionDifference);
                    transform.position = new Vector3(Mathf.SmoothStep(Camera.main.transform.position.x, Camera.main.transform.position.x, Camera.main.transform.position.x), 0, transform.position.z);
                }
                StartPosition = GetWorldPosition();
        }
    }

    Vector2 GetWorldPosition(){
        return cameraGameObject.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition);
    }

    Vector2 GetWorldPositionOfFinger(int FingerIndex){
        return cameraGameObject.GetComponent<Camera>().ScreenToWorldPoint(Input.GetTouch(FingerIndex).position);
    }
}
