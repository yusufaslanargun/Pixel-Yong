using UnityEngine;
using UnityEngine.EventSystems;

public class LeftButtonController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    PlayerMovement player;
    private bool isPressed;
    private bool isMoving = false;

    private void Awake()
    {
        player = FindObjectOfType<PlayerMovement>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isPressed = true;
        isMoving = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isPressed = false;
    }

    private void Update()
    {
        if (isPressed)
        {
            player.MoveLeft();
        }
        else if(isMoving)
        {
            player.Stop();
            isMoving = false;
        }
    }
}
