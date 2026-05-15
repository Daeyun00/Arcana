using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomController : MonoBehaviour
{
    [Header("Cameras")]
    public Camera WaitingRoomCam;
    public Camera PrepRoomCam;
    public Camera CookingRoomCam;
    public Camera BottlingRoomCam;

    [Header("UI Canvases (Assign in Inspector!)")]
    public GameObject WaitingRoomUI;
    public GameObject PrepRoomUI;
    public GameObject CookingRoomUI;
    public GameObject BottlingRoomUI;

    void Awake() 
    {
        Camera_to_Waiting_room();
    }

    // --- HELPER FUNCTION ---
    // This turns EVERYTHING off so we start with a blank slate before turning a room on.
    private void DeactivateAll() 
    {
        WaitingRoomCam.gameObject.SetActive(false);
        PrepRoomCam.gameObject.SetActive(false);
        CookingRoomCam.gameObject.SetActive(false);
        BottlingRoomCam.gameObject.SetActive(false);

        // We use "!= null" just in case you haven't assigned a UI yet, so it won't crash!
        if (WaitingRoomUI != null) WaitingRoomUI.SetActive(false);
        if (PrepRoomUI != null) PrepRoomUI.SetActive(false);
        if (CookingRoomUI != null) CookingRoomUI.SetActive(false);
        if (BottlingRoomUI != null) BottlingRoomUI.SetActive(false);
    }

    // --- ROOM SWITCHING ---
    public void Camera_to_Waiting_room()
    {
        DeactivateAll(); // Turn everything off first
        WaitingRoomCam.gameObject.SetActive(true); // Turn on the right camera
        if (WaitingRoomUI != null) WaitingRoomUI.SetActive(true); // Turn on the right UI
    }

    public void Camera_to_Prep_room()
    {   
        DeactivateAll();
        PrepRoomCam.gameObject.SetActive(true);
        if (PrepRoomUI != null) PrepRoomUI.SetActive(true);
    }

    public void Camera_to_Cooking_room()
    {
        DeactivateAll();
        CookingRoomCam.gameObject.SetActive(true);
        if (CookingRoomUI != null) CookingRoomUI.SetActive(true);
    }

    public void Camera_to_Bottling_room()
    {
        DeactivateAll();
        BottlingRoomCam.gameObject.SetActive(true);
        if (BottlingRoomUI != null) BottlingRoomUI.SetActive(true);
    }
}