using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;

    void Update()
    {
        Move();
        LookAtMouse();
    }

    void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Vector3 move = new Vector3(x, 0, z);

        transform.position += move.normalized * moveSpeed * Time.deltaTime;
    }

    void LookAtMouse()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        Plane plane = new Plane(Vector3.up, Vector3.zero);

        float distance;

        if (plane.Raycast(ray, out distance))
        {
            Vector3 targetPoint = ray.GetPoint(distance);

            Vector3 direction = targetPoint - transform.position;

            direction.y = 0;

            if (direction.sqrMagnitude > 0.001f)
            {
                transform.rotation = Quaternion.LookRotation(direction);
            }
        }
    }
}