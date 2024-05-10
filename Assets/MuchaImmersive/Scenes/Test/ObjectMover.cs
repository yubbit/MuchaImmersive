using UnityEngine;
using System.Collections;


public class ObjectMover : MonoBehaviour
{
    public Vector3 position1;
    public Vector3 position2;
    public Vector3 position3;
    public Vector3 position4;

    public float movementSpeed = 5f;

    void Update()
    {
        // Move to position 1 when pressing the 1 key
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            MoveToPosition(position1);
        }

        // Move to position 2 when pressing the 2 key
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            MoveToPosition(position2);
        }

        // Move to position 3 when pressing the 3 key
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            MoveToPosition(position3);
        }

        // Move to position 4 when pressing the 4 key
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            MoveToPosition(position4);
        }
    }

    void MoveToPosition(Vector3 targetPosition)
    {
        // Stop any ongoing movement
        StopAllCoroutines();

        // Start a coroutine to smoothly move to the target position
        StartCoroutine(MoveCoroutine(targetPosition));
    }

    IEnumerator MoveCoroutine(Vector3 targetPosition)
    {
        while (Vector3.Distance(transform.position, targetPosition) > 0.01f)
        {
            // Move towards the target position smoothly
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, movementSpeed * Time.deltaTime);

            yield return null;
        }
    }
}
