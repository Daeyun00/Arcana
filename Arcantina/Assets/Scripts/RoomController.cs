using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomController : MonoBehaviour
{
    public Camera WaitingRoomCam;
    public Camera PrepRoomCam;
    public Camera CookingRoomCam;
    public Camera BottlingRoomCam;

    void Start() {
        Camera_to_Waiting_room();
    }
    public void Camera_to_Waiting_room()
    {
        PrepRoomCam.enabled = false;
        CookingRoomCam.enabled = false;
        BottlingRoomCam.enabled = false;
        WaitingRoomCam.enabled = true;
    }
    public void Camera_to_Prep_room()
    {   
        CookingRoomCam.enabled = false;
        BottlingRoomCam.enabled = false;
        WaitingRoomCam.enabled = false;
        PrepRoomCam.enabled = true;

    }
    public void Camera_to_Cooking_room()
    {
        PrepRoomCam.enabled = false;
        BottlingRoomCam.enabled = false;
        WaitingRoomCam.enabled = false;
        CookingRoomCam.enabled = true;
    }
    public void Camera_to_Bottling_room()
    {
        PrepRoomCam.enabled = false;
        CookingRoomCam.enabled = false;
        WaitingRoomCam.enabled = false;
        BottlingRoomCam.enabled = true;
    }
}
