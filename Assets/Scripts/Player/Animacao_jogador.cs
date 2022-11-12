using UnityEngine;

namespace Player
{
    public class Animacao_jogador : MonoBehaviour
    {
        [SerializeField]
        private Animator animator;

        [SerializeField]
        private Rigidbody2D rb;

        private static readonly int Correndo = Animator.StringToHash("correndo");
        private static readonly int Pulando = Animator.StringToHash("pulando");
        private static readonly int Caindo = Animator.StringToHash("caindo");


        private void Update()
        {

            var velocityx = Mathf.Abs(this.rb.velocity.x);
            animator.SetBool(Correndo, velocityx > 0);


            switch (rb.velocity.y)
            {
                case > 0:
                    animator.SetBool(Pulando, true);
                    animator.SetBool(Caindo, false);
                    break;
                case < 0:
                    animator.SetBool(Pulando, false);
                    animator.SetBool(Caindo, true);
                    break;
                case 0:
                    animator.SetBool(Pulando, false);
                    animator.SetBool(Caindo, false);
                    break;
            }
        }

    }
}
