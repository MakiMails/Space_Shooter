using UnityEngine;

namespace Game.CameraScripts
{
    internal class CameraMove : MonoBehaviour
    {
        [SerializeField] private Transform target;
        [SerializeField] private Vector3 offset;
        [SerializeField] private float sensitivity = 3;
        [SerializeField] private float limit = 80;
        private float x, Y;

        private void LateUpdate()
        {
            Rotate();
        }

        private void Rotate()
        {
            x = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivity;
            Y += Input.GetAxis("Mouse Y") * sensitivity;
            Y = Mathf.Clamp(Y, -limit, limit);
            transform.localEulerAngles = new Vector3(-Y, x, 0);
            transform.position = transform.localRotation * offset + target.position;
        }
    }
}
