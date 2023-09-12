using UnityEngine;

namespace Game.PlayerScripts
{
    internal class PlayerControllerAnim : MonoBehaviour
    {
        private Animator _animator;

        private void Start ()
        {
            _animator = GetComponent<Animator>();
        }

        public void MoveForward(float k)
        {
            _animator.SetFloat("y", k);
        }

        public void MoveBack(float k)
        {
            
            _animator.SetFloat("y", k);
        }

        public void MoveNull(float k)
        {
            _animator.SetFloat("y", k);
        }

        public void Turn(float k)
        {
            _animator.SetFloat("x",k);
        }
    }
}