using UnityEngine;

public class PipeMoveScript : MonoBehaviour
{
    public float moveSpeed = 8;
    public float deadZone = -30;

    // Update is called once per frame
    void Update()
    {
        var transform1 = transform;
        transform1.position += Vector3.left * (moveSpeed * Time.deltaTime);

        if (transform.position.x < deadZone)
        {
            Destroy(gameObject);
        }
    }
}
