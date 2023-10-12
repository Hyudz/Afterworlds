using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class camera_movement : MonoBehaviour
{

    [SerializeField] private Transform player;

    public BoxCollider2D upBoundary;
    public BoxCollider2D downBoundary;
    public BoxCollider2D leftBoundary;
    public BoxCollider2D rightBoundary;

    private Camera mainCamera;
    private Vector3 minBounds, maxBounds;

    void Start()
    {
        mainCamera = Camera.main;

        // Calculate the camera's boundaries based on the Box Colliders
        if (upBoundary != null)
            maxBounds.y = upBoundary.bounds.max.y;

        if (downBoundary != null)
            minBounds.y = downBoundary.bounds.min.y;

        if (leftBoundary != null)
            minBounds.x = leftBoundary.bounds.min.x;

        if (rightBoundary != null)
            maxBounds.x = rightBoundary.bounds.max.x;
        
        Debug.Log(maxBounds.y);
        Debug.Log(maxBounds.x);
        Debug.Log(minBounds.y);
        Debug.Log(minBounds.x);
    }


    public void Update()
    {
        if (player != null)
        {
            // Get the character's position
            Vector3 targetPos = player.position;

            // Ensure the camera stays within the boundaries
            float x = Mathf.Clamp(targetPos.x, minBounds.x, maxBounds.x);
            float y = Mathf.Clamp(targetPos.y, minBounds.y, maxBounds.y);

            // Set the camera's position
            mainCamera.transform.position = new Vector3(x, y, mainCamera.transform.position.z);
        }
    }

    // Update is called once per frame
    //void Update()
    //    //transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
        //lookAhead = Mathf.Lerp(lookAhead, (aheadDistance * player.localScale.x), Time.deltaTime * cameraSpeed);

    //}
}
