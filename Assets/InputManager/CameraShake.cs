using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    public Camera mainCamera;
    public float zoomSpeed = 10f;
    public float maxZoom = 20f;
    public float minZoom = 60f;
    private bool isZooming = false;
    private float targetZoom;

    private void OnEnable()
    {
        // Subscribe to the zoom input events.
        Actions.onZoomStarted += StartZoom;
        Actions.onZoomPerformed += PerformZoom;
        Actions.onZoomCanceled += CancelZoom;
    }

    private void OnDisable()
    {
        // Unsubscribe from the zoom input events.
        Actions.onZoomStarted -= StartZoom;
        Actions.onZoomPerformed -= PerformZoom;
        Actions.onZoomCanceled -= CancelZoom;
    }

    void StartZoom()
    {
        Debug.Log("Zoom button pressed.");
        // Set the target zoom to the camera's current field of view.
        isZooming = true;
        targetZoom = mainCamera.fieldOfView;
    }

    void PerformZoom()
    {
        Debug.Log("Zoom button held.");
        if (isZooming)
        {
            // Start zooming.
            StartCoroutine(ZoomCamera());
        }
    }

    private IEnumerator ZoomCamera() 
    {
        while (isZooming)
        {
            // Decrement the target zoom value to zoom in.
            targetZoom -= zoomSpeed * Time.deltaTime;
            // Clamp the target zoom.
            targetZoom = Mathf.Clamp(targetZoom, maxZoom, minZoom);
            // Reset the camera's field of view to the target zoom.
            mainCamera.fieldOfView = targetZoom;
            // Wait for the next frame before updating the zoom.
            yield return null;
        }
    }

    void CancelZoom()
    {
        if (isZooming)
        {
            // Reset the zoom flag and the camera's field of view.
            isZooming = false;
            mainCamera.fieldOfView = minZoom;
            Debug.Log("Zoom canceled");
        }
    }
}
