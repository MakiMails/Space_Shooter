using UnityEngine;

namespace Game.PlayerScripts
{
    public class PlayerController : MonoBehaviour
    {
        private PlayerMove _playerMove;

        private void Start ()
        {
            _playerMove = GetComponent<PlayerMove>();
        }

        private void Update ()
        {
            _playerMove.Move();
        }
    }
}
