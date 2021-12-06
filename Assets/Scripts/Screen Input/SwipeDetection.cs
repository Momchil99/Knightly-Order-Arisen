using System.Collections;
using UnityEngine;

public class SwipeDetection : MonoBehaviour
{
    [SerializeField] private float minimumDistance = 0.2f;
    [SerializeField] private float maximumTime = 1f;
    [SerializeField, Range (0f, 1f)] private float directionThreshhold = 0.9f;
    [SerializeField] private GameObject trail;

    private InputManager inputManager;
    public CharacterMovement characterMovement;

    private Vector2 startPosition;
    private float startTime;
    private Vector2 endPosition;
    private float endTime;
    private Coroutine coroutine;

    private void Awake()
    {
        inputManager = InputManager.Instance;
        characterMovement = FindObjectOfType<CharacterMovement>();
    }

    private void OnEnable()
    {
        inputManager.OnStartTouch += SwipeStart;
        inputManager.OnEndTouch += SwipeEnd;
    }

    private void OnDisable()
    {
        inputManager.OnStartTouch -= SwipeStart;
        inputManager.OnEndTouch -= SwipeEnd;
    }

    private void SwipeStart(Vector2 position, float time)
    {
        startPosition = position;
        startTime = time;
        trail.SetActive(true);
        trail.transform.position = position;
       coroutine = StartCoroutine(Trail());
    }

    private IEnumerator Trail()
    {
        while (true)
        {
            trail.transform.position = inputManager.PrimaryPosition();
            yield return null;
        }
    }

    private void SwipeEnd(Vector2 position, float time)
    {
        trail.SetActive(false);
        StopCoroutine(coroutine);
        endPosition = position;
        endTime = time;
        DetectSwipe();
    }

    private void DetectSwipe()
    {
        if (Vector3.Distance(startPosition, endPosition)>= minimumDistance && (endTime - startTime) <= maximumTime)
        {
            Debug.DrawLine(startPosition, endPosition, Color.red,5f);
            
            Vector3 direction = endPosition - startPosition;
            Vector2 direction2D = new Vector2(direction.x,direction.y).normalized;
            SwipeDirection(direction2D);
        }
    }

    private void SwipeDirection(Vector2 direction)
    {
        if (Vector2.Dot(Vector2.up, direction) > directionThreshhold)
        {
            Debug.Log("Swipe Up");
        }
        else if (Vector2.Dot(Vector2.down, direction) > directionThreshhold)
        {
            characterMovement.Parry();
        }
        else if (Vector2.Dot(Vector2.left, direction) > directionThreshhold)
        {
            characterMovement.RightTopDownAttack();
        }
        else if (Vector2.Dot(Vector2.right, direction) > directionThreshhold)
        {
            StartCoroutine(characterMovement.LeftSpinningAttack());
        }
    }
}
