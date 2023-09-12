using UnityEngine;

namespace Game.PlayerScripts
{
    internal class PlayerMove : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private Transform _cameraTransform;
        private PlayerControllerAnim _playerControllerAnim;

        [SerializeField] private AnimationCurve _animationCurve;

        private float _timeY;
        private float _timeX;

        private void Start()
        {
            _playerControllerAnim = GetComponent<PlayerControllerAnim>();
        }

        public void Move()
        {
            Vector3 cameraDirection = _cameraTransform.rotation * Vector3.forward;
            cameraDirection.y = 0;

            if (Input.GetKey(KeyCode.W))
            {
                _timeY += Time.deltaTime * 2f;
                _timeY = Mathf.Clamp(_timeY, 0f, 1f);

                transform.position += cameraDirection * _speed * Time.deltaTime;
                _playerControllerAnim.MoveForward(_animationCurve.Evaluate(_timeY));
            }
            else if (Input.GetKey(KeyCode.S))
            {
                _timeY -= Time.deltaTime * 2f;
                _timeY = Mathf.Clamp(_timeY, -1f, 0f);

                transform.position -= cameraDirection * _speed * Time.deltaTime;
                _playerControllerAnim.MoveBack(-_animationCurve.Evaluate(_timeY * -1f));
            }
            else
            {
                _timeY = Mathf.Lerp(_timeY, 0, Time.deltaTime * 2f);
                _playerControllerAnim.MoveNull(_timeY);
            }

            Vector3 directionLeft = Vector3.Cross(cameraDirection, Vector3.up);

            if (Input.GetKey(KeyCode.A))
            {
                _timeX -= Time.deltaTime * 4f;
                _timeX = Mathf.Clamp(_timeX, -1f, 0f);

                transform.position += directionLeft * _speed * Time.deltaTime;
                _playerControllerAnim.Turn(-_animationCurve.Evaluate(_timeX * -1f));
            }
            else if (Input.GetKey(KeyCode.D))
            {
                _timeX += Time.deltaTime * 4f;
                _timeX = Mathf.Clamp(_timeX, 0f, 1f);

                transform.position -= directionLeft * _speed * Time.deltaTime;
                _playerControllerAnim.Turn(_animationCurve.Evaluate(_timeX));
            }
            else
            {
                _timeX = Mathf.Lerp(_timeX, 0, Time.deltaTime * 4f);
                _playerControllerAnim.Turn(_timeX);
            }
        }
    }
}