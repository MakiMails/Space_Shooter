using UnityEngine;
using Game.States.PlayerState;

namespace Game.PlayerScripts
{
    internal class PlayerMove : MonoBehaviour
    {

        [SerializeField] private PlayerMoveState _playerMoveStateDeffult;
        [SerializeField] private PlayerMoveState _playerMoveStateAttack;

        private float _speed;

        public float Speed
        {
            get => _speed;
            set => _speed = value;
        }

        [SerializeField] private AnimationCurve _animationCurve;
        private PlayerControllerAnim _playerControllerAnim;

        private float _timeGainCoefficient = 6f;
        private float _timeReductionCoefficient = 8f;

        private float _timeY;
        private float _timeX;

        [SerializeField] private Transform _cameraTransform;

        private void Start()
        {
            _playerControllerAnim = GetComponent<PlayerControllerAnim>();
            _speed = _playerMoveStateDeffult.Speed;
            AddMirrorKeysInAnimationCurve();
        }

        public void Move()
        {
            Vector3 cameraDirection = _cameraTransform.rotation * Vector3.forward;
            cameraDirection.y = 0;

            if (Input.GetKey(KeyCode.W))
            {
                _timeY = Mathf.Lerp(_timeY, 1f, Time.deltaTime * _timeGainCoefficient);
                TurnBody(_cameraTransform.rotation);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                _timeY = Mathf.Lerp(_timeY, -1f, Time.deltaTime * _timeGainCoefficient);
                TurnBody(_cameraTransform.rotation);
            }
            else
            {
                _timeY = Mathf.Lerp(_timeY, 0, Time.deltaTime * _timeReductionCoefficient);
            }

            transform.position += cameraDirection * _speed * _animationCurve.Evaluate(_timeY) * Time.deltaTime;
            _playerControllerAnim.Move(_animationCurve.Evaluate(_timeY));

            Vector3 directionLeft = Vector3.Cross(cameraDirection, Vector3.up);

            if (Input.GetKey(KeyCode.A))
            {
                _timeX = Mathf.Lerp(_timeX, 1f, Time.deltaTime * _timeGainCoefficient);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                _timeX = Mathf.Lerp(_timeX, -1f, Time.deltaTime * _timeGainCoefficient);
            }
            else
            {
                _timeX = Mathf.Lerp(_timeX, 0, Time.deltaTime * _timeReductionCoefficient);
            }

            transform.position += directionLeft * _speed * _animationCurve.Evaluate(_timeX) * Time.deltaTime;
            _playerControllerAnim.Turn(-_animationCurve.Evaluate(_animationCurve.Evaluate(_timeX)));
        }

        public void LowerSpeed()
        {
            Speed = _playerMoveStateAttack.Speed;
        }

        public void IncreaseSpeed()
        {
            Speed = _playerMoveStateDeffult.Speed;
        }

        private void AddMirrorKeysInAnimationCurve()
        {
            Keyframe[] keyframes = _animationCurve.keys;

            for (int i = keyframes.Length - 1; i > -1; i--)
            {
                _animationCurve.AddKey(-keyframes[i].time, -keyframes[i].value);
            }
        }

        private void TurnBody(Quaternion cameraQuaternion)
        {
            cameraQuaternion.x = 0;
            cameraQuaternion.z = 0;

            transform.rotation = Quaternion.Lerp(transform.rotation, cameraQuaternion, Time.deltaTime * 5f);
        }
    }
}