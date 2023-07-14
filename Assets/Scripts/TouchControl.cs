
// using UnityEngine;
// using UnityEngine.EventSystems;

// public class TouchControl : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
// {
//     public float moveSpeed = 5f;
//     public float threshold = 0.1f;

//     private bool isMoving = false;
//     private Vector2 movementDirection;
//     private RectTransform joystickBackground; // Reference to the joystick background image
//     private RectTransform joystickHandle; // Reference to the joystick handle image

//     [SerializeField] GameObject sceneManager;
//     bool canHeroWalk;

//     private void Start()
//     {
//         // Find and assign the joystick background and handle based on their names in the scene
//         joystickBackground = GameObject.Find("JoystickBackground").GetComponent<RectTransform>();
//         joystickHandle = GameObject.Find("JoystickHandle").GetComponent<RectTransform>();
//     }

//     private void Update()
//     {
//         canHeroWalk = sceneManager.GetComponent<BattleSceneManager>().canHeroWalk;

//         if (canHeroWalk)
//         {
//             // Move the character based on the movement direction
//             if (isMoving)
//             {
//                 transform.Translate(movementDirection * moveSpeed * Time.deltaTime);
//             }
//         }
//     }

//     public void OnPointerDown(PointerEventData eventData)
//     {
//         // Update joystick position when the user touches the joystick handle
//         Vector2 touchPosition = eventData.position;
//         Vector2 localPoint;
//         if (RectTransformUtility.ScreenPointToLocalPointInRectangle(joystickBackground, touchPosition, null, out localPoint))
//         {
//             joystickHandle.localPosition = localPoint;
//         }
//     }

//     public void OnDrag(PointerEventData eventData)
//     {
//         // Calculate the movement direction based on the joystick handle's position
//         Vector2 touchPosition = eventData.position;
//         Vector2 localPoint;
//         if (RectTransformUtility.ScreenPointToLocalPointInRectangle(joystickBackground, touchPosition, null, out localPoint))
//         {
//             // Update the joystick handle position within the joystick background boundaries
//             joystickHandle.localPosition = Vector2.ClampMagnitude(localPoint, joystickBackground.rect.width * 0.5f);

//             // Calculate the normalized movement direction based on the joystick handle's position
//             movementDirection = joystickHandle.localPosition.normalized;

//             // Set isMoving based on whether the joystick offset exceeds a threshold value
//             isMoving = joystickHandle.localPosition.magnitude > threshold;
//         }
//     }

//     public void OnPointerUp(PointerEventData eventData)
//     {
//         // Reset the joystick handle position and movement direction when the user releases the joystick
//         joystickHandle.localPosition = Vector2.zero;
//         movementDirection = Vector2.zero;
//         isMoving = false;
//     }
// }




// joystick - like without the UI
using UnityEngine;

public class TouchControl : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float threshold = 0.1f; // Add a threshold value

    private bool isMoving = false;
    private Vector2 movementDirection;
    private Vector2 joystickStartPosition;
    private Vector2 joystickCurrentPosition;
    private Vector2 joystickOffset; // Declare joystickOffset here

    [SerializeField] GameObject sceneManager;
    bool canHeroWalk;

    private void Update()
    {
        canHeroWalk = sceneManager.GetComponent<BattleSceneManager>().canHeroWalk;

        if (canHeroWalk)
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                switch (touch.phase)
                {
                    case TouchPhase.Began:
                        // Store the initial touch position as the joystick start position
                        joystickStartPosition = touch.position;
                        break;
                    case TouchPhase.Moved:
                    case TouchPhase.Stationary:
                        // Calculate the distance and direction between the current touch position and the joystick start position
                        joystickCurrentPosition = touch.position;
                        joystickOffset = joystickCurrentPosition - joystickStartPosition; // Remove the Vector2 declaration

                        // Calculate the movement direction based on the joystick offset
                        movementDirection = joystickOffset.normalized;

                        // Move the character based on the calculated movement direction
                        transform.Translate(movementDirection * moveSpeed * Time.deltaTime);
                        break;
                    case TouchPhase.Ended:
                    case TouchPhase.Canceled:
                        // Reset the movement direction and joystick positions
                        movementDirection = Vector2.zero;
                        joystickStartPosition = Vector2.zero;
                        joystickCurrentPosition = Vector2.zero;
                        break;
                }

                // Set isMoving based on whether the joystick offset exceeds a threshold value
                isMoving = joystickOffset.magnitude > threshold;
            }
            else
            {
                isMoving = false;
            }
        }
    }
}




// point to go where

// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class TouchControl : MonoBehaviour
// {
//     public float moveSpeed = 5f;

//     private Vector2 targetPosition;
//     private bool isMoving = false;

//     [SerializeField] GameObject sceneManager;
//     bool canHeroWalk;

//     void Update()
//     {
//         canHeroWalk = sceneManager.GetComponent<BattleSceneManager>().canHeroWalk;

//         if (canHeroWalk && Input.touchCount > 0)
//         {
//             Touch touch = Input.GetTouch(0);

//             if (touch.phase == TouchPhase.Began)
//             {
//                 // Convert touch position to world space
//                 Vector3 screenPosition = new Vector3(touch.position.x, touch.position.y, transform.position.z);
//                 targetPosition = Camera.main.ScreenToWorldPoint(screenPosition);

//                 isMoving = true;
//             }
//         }

//         if (isMoving)
//         {
//             // Calculate the direction towards the target position
//             Vector2 direction = (targetPosition - (Vector2)transform.position).normalized;

//             // Move the character linearly towards the target position
//             transform.position += (Vector3)(direction * moveSpeed * Time.deltaTime);

//             // Check if the character has passed the target position
//             if (Vector2.Dot(direction, targetPosition - (Vector2)transform.position) <= 0)
//             {
//                 // Snap the character to the target position
//                 transform.position = targetPosition;

//                 isMoving = false;
//             }
//         }
//     }
// }
