using UnityEngine;

public class Wood : MonoBehaviour
{
    [SerializeField] private float speed = 2;
    private void FixedUpdate()
    {
        transform.Rotate(0, 0, speed);
    }
}