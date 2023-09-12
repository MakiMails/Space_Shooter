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

        public void Move(float k)
        {
            _animator.SetFloat("y", k);
        }

        public void Turn(float k)
        {
            _animator.SetFloat("x",k);
        }
    }
}