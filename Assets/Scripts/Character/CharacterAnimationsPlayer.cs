using NavyTest.AnimatorControllers;
using UnityEngine;

namespace NavyTest.Character
{
    public class CharacterAnimationsPlayer
    {
        private readonly Animator _animator;

        public CharacterAnimationsPlayer(Animator animator)
        {
            _animator = animator;
        }

        public void PlayRunAnimation()
        {
            _animator.Play(AnimatorController.State.Run);
        }

        public void PlayIdleAnimation()
        {
            _animator.Play(AnimatorController.State.Idle);
        }
    }
}
