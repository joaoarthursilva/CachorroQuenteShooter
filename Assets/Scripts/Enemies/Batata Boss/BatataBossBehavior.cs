using UnityEngine;

namespace Enemies.Batata_Boss
{
    public class BatataBossBehavior : MonoBehaviour
    {
        [Header("Geral")] [SerializeField] private GameObject rightBarrier;

        // [Header("Animaçoes")] [SerializeField] private Animator anim;

        [Header("Vida")] public int vidaBatata = 100;
        private int _vidaAtual;

        [Header("Ataque Refrigerante")] public GameObject refrigerante;
        public Vector3 refriUpPosition;
        public Vector3 refriDownPosition;
        public float refriMoveSpeed = 3f;
        public bool toggleRefri = false;
        public bool ataque3 = false;
        [Header("Ataque Baixo")] public Transform pontoAtaqueBaixo;
        public GameObject ondaDeBatataObject;
        public bool ataque1 = false;
        private int _atacaBaixoCounter = 0;

        [Header("Ataque Cima")] public Transform pontoAtaqueCima;
        public GameObject batataAfiadaObject;
        public bool ataque2 = false;
        private int _atacaCimaCounter;
        private int _atacaCimaAmount;
        
        [Header("Ataques em geral")] private bool _isAttacking;
        private bool _justAttacked;
        public float attackDelay; 

        private void Start()
        {
            _justAttacked = false;
            Ataque2();
            _atacaCimaCounter = 0;
            _vidaAtual = vidaBatata;
        }

        private void FixedUpdate()
        {
            ManageBossHealth();
            ManageCurrentAttack();
            ManageManualAttacks(); // for development only
            if (!_isAttacking) ManageNextAttack();
        }

        private void ManageBossHealth()
        {
            if (_vidaAtual <= 0)
                VenceuOBoss();
        }

        private void ManageCurrentAttack()
        {
            if (_atacaBaixoCounter >= 3)
            {
                CancelInvoke(nameof(AtacaBaixo));
                _atacaBaixoCounter = 0;
                _isAttacking = false;
                _justAttacked = true;
            }

            if (_atacaCimaCounter >= _atacaCimaAmount)
            {
                CancelInvoke(nameof(AtacaCima));
                _atacaCimaCounter = 0;
                toggleRefri = false;
                _isAttacking = false;
                _justAttacked = true;
            }
        }

        private void ManageNextAttack()
        {
            var nextAttackId = Random.Range(0, 3);
            if (_justAttacked)
            {
                WaitForNextAttack();
            }
            else
            {
                switch (nextAttackId)
                {
                    case 0:
                        Ataque1();
                        break;
                    case 1:
                        Ataque2();
                        break;
                    case 2:
                        Ataque3();
                        break;
                }
            }
        }

        private void WaitForNextAttack()
        {
            _isAttacking = true;
            Invoke(nameof(BackToNextAttack), attackDelay);
        }

        private void BackToNextAttack()
        {
            _isAttacking = false;
            _justAttacked = false;
        }

        private void ManageManualAttacks()
        {
            if (ataque2)
            {
                Ataque2();
                ataque2 = false;
            }

            if (ataque1)
            {
                Ataque1();
                ataque1 = false;
            }

            if (ataque3)
            {
                Ataque3();
                ataque3 = false;
            }

            if (toggleRefri) LevantaRefrigerante();
            else AbaixaRefrigerante();
        }

        private void Ataque1() // em baixo
        {
            _isAttacking = true;
            var repeatRate = Random.Range(.7f, 1f);

            InvokeRepeating(nameof(AtacaBaixo), 0f, repeatRate);
        }

        private void Ataque2() // em cima
        {
            _isAttacking = true;
            var repeatRate = Random.Range(.6f, .8f);
            _atacaCimaAmount = Random.Range(2, 7);
            InvokeRepeating(nameof(AtacaCima), 0f, repeatRate);
        }

        private void Ataque3() // levanta refri e ataca em cima
        {
            _isAttacking = true;
            _atacaCimaAmount = Random.Range(8, 16);
            var repeatRate = Random.Range(.6f, 1.2f);
            toggleRefri = true;
            InvokeRepeating(nameof(AtacaCima), 0f, repeatRate);
        }

        private void VenceuOBoss()
        {
            //trigger anim
            //remove barrier
            rightBarrier.gameObject.SetActive(false);
            //deactivate box
            gameObject.SetActive(false);
        }

        private void AtacaBaixo()
        {
            if (!toggleRefri)
                Instantiate(ondaDeBatataObject, pontoAtaqueBaixo.position, Quaternion.identity);
            _atacaBaixoCounter++;
        }

        private void AtacaCima()
        {
            Instantiate(batataAfiadaObject, pontoAtaqueCima.position,
                transform.rotation * Quaternion.Euler(0f, 0f, 90f));
            _atacaCimaCounter++;
        }

        private void LevantaRefrigerante()
        {
            var refriPos = refrigerante.transform.position;
            refrigerante.transform.position =
                Vector3.MoveTowards(refriPos, refriUpPosition, refriMoveSpeed * Time.fixedDeltaTime);
        }

        private void AbaixaRefrigerante()
        {
            refrigerante.transform.position =
                Vector3.MoveTowards(refrigerante.transform.position, refriDownPosition, 0.1f);
        }

        private void OnCollisionEnter2D(Collision2D col)
        {
            if (col.gameObject.layer != 11)
                return;
            _vidaAtual -= 1;
        }
    }
}