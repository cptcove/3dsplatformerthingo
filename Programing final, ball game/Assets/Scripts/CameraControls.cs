using UnityEngine;

public class CameraControls : MonoBehaviour
{
    [SerializeField] private Vector3 camOffset = new Vector3(0f, 1.5f, -2.6f);
    private Transform target;

    private void Start()
    {
        target = FindObjectOfType<PlayerMovement>().GetComponent<Transform>();
    }

    private void LateUpdate()
    {
        this.transform.position = target.TransformPoint(camOffset);
        this.transform.LookAt(target);
    }
}