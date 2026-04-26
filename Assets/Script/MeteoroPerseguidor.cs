using UnityEngine;

public class MeteoroPerseguidor : MonoBehaviour
{
    [Header("Meteor Config")]

    public float speed = 100f;
    public float rotateSpeed = 10f;
    public Vector3 targetPosition;

    public void SetTarget(Vector3 target)
    {
        targetPosition = target;
    }

    void Update()
    {
        if (targetPosition != Vector3.zero)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                targetPosition,
                speed * Time.deltaTime
            );

            Vector3 direction = targetPosition - transform.position;
            if (direction != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);
            }
        }
        else
        {
            Debug.Log("Target Position igual a 0");
        }
    }
}
