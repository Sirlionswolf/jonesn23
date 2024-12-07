using UnityEngine;

public class Pet : MonoBehaviour
{
    [SerializeField]
    GameObject followingPlayer;

    float speed = 3f;
    float minDistance = 2;

    string skin;

    public void RenderTick()
    {
        Vector3 displacement = followingPlayer.transform.position - transform.position;
        float distance = displacement.magnitude;

        if (distance > minDistance)
        {
            Vector3 direction = Vector3.Normalize(displacement);
            transform.position += direction * speed * Time.deltaTime;

            if ((direction.x > 0 && transform.rotation.y == -1))
            {
                transform.Rotate(0, 180, 0);
            }
            if ((direction.x < 0 && transform.rotation.y == 0))
            {
                transform.Rotate(0, -180, 0);
            }
        }
    }
}