using System;
using Managers;
using UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace Enemies.Batata_Boss
{
    public class BatataBossBehavior : Enemy
    {
        [Header("Geral")] [SerializeField] private GameObject rightBarrier;

        // [Header("Animaçoes")] [SerializeField] private Animator anim;

        [Header("Vida")] public int vidaBatata = 500;
        private int _vidaAtual;
        [SerializeField] private int vidaParaFaseDois = 450;
        [SerializeField] private int vidaParaFaseTres = 300;
        [SerializeField] private int vidaParaFaseQuatro = 100;
        [SerializeField] private int vidaParaFaseCinco = 50;
        [SerializeField] private Image vidaImg;
        [SerializeField] private Canvas enemyCanvas;

        [Header("Ataque Refrigerante")] public GameObject refrigerante;
        public Vector3 refriUpPosition;
        public Vector3 refriDownPosition;
        public float refriMoveSpeed = 3f;
        private bool _toggleRefri = false;
        [SerializeField] private int lifeAmountToAtaqueRefri;

        [Header("Ataque Baixo")] public Transform pontoAtaqueBaixo;
        public GameObject ondaDeBatataObject;
        private int _atacaBaixoCounter = 0;

        [Header("Ataque Cima")] public Transform pontoAtaqueCima;
        public GameObject batataAfiadaObject;
        private int _atacaCimaCounter;
        private int _atacaCimaAmount;

        [Header("Ataques em geral")] private bool _isAttacking;
        private bool _justAttacked;
        private float _attackDelay;
        [SerializeField] private float startingAttackDelay;
        [SerializeField] private float secondAttackDelay;
        [SerializeField] private float thirdAttackDelay;


        private void Start()
        {
            _attackDelay = startingAttackDelay;
            _justAttacked = true;
            Ataque2();
            _atacaCimaCounter = 0;
            _vidaAtual = vidaBatata;
            vidaImg.color = Color.cyan;
        }

        private void FixedUpdate()
        {
            ManageBossHealth();
            ManageCurrentAttack();

            if (!_isAttacking)
                ManageNextAttack();
            if (_toggleRefri) LevantaRefrigerante();
            else AbaixaRefrigerante();
        }

        private void ManageBossHealth()
        {
            if (_vidaAtual <= vidaParaFaseCinco)
            {
                _attackDelay = .1f;
                vidaImg.color = Color.red;
            }
            else if (_vidaAtual <= vidaParaFaseQuatro)
            {
                _attackDelay = .25f;
                vidaImg.color = Color.red;
            }
            else if (_vidaAtual <= vidaParaFaseTres)
            {
                _attackDelay = thirdAttackDelay;
                vidaImg.color = Color.magenta;
            }
            else if (_vidaAtual <= vidaParaFaseDois)
            {
                _attackDelay = secondAttackDelay;
                vidaImg.color = Color.yellow;
            }


            if (_vidaAtual <= 0)
                VenceuOBoss();
        }

        private void Update()
        {
            vidaImg.fillAmount = (float) _vidaAtual / vidaBatata;
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
                _toggleRefri = false;
                _isAttacking = false;
                _justAttacked = true;
            }
        }

        private void ManageNextAttack()
        {
            if (_justAttacked)
            {
                WaitForNextAttack();
            }
            else
            {
                var nextAttackId = Random.Range(0, 3);
                switch (nextAttackId)
                {
                    case 0:
                        Ataque1();
                        break;
                    case 1:
                        Ataque2();
                        break;
                    case 2:
                        if (_vidaAtual <= vidaParaFaseTres)
                            Ataque3();
                        break;
                }
            }
        }

        private void WaitForNextAttack()
        {
            _isAttacking = true;
            Invoke(nameof(BackToNextAttack), _attackDelay);
        }

        private void BackToNextAttack()
        {
            _isAttacking = false;
            _justAttacked = false;
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
            var repeatRate = 1f;
            _atacaCimaAmount = Random.Range(2, 7);
            InvokeRepeating(nameof(AtacaCima), 0f, repeatRate);
        }

        private void Ataque3() // levanta refri e ataca em cima
        {
            _isAttacking = true;
            _atacaCimaAmount = Random.Range(8, 16);
            var repeatRate = 1f;
            _toggleRefri = true;
            InvokeRepeating(nameof(AtacaCima), 0f, repeatRate);
        }

        private void VenceuOBoss()
        {
            gameObject.SetActive(false);
            Invoke(nameof(VaiPraCreditos), .6f);

            // //trigger anim
            // CancelInvoke();
            // _toggleRefri = false;
            // AbaixaRefrigerante();
            // //remove barrier
            // rightBarrier.gameObject.SetActive(false);
            // enemyCanvas.gameObject.SetActive(false);
            // //deactivate box
        }

        private void VaiPraCreditos()
        {
            DiedScreen.ReverseDontDestroy();
            SceneManager.LoadScene("Creditos");
        }

        private void AtacaBaixo()
        {
            if (!_toggleRefri)
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

        public override void TakeDamage(int amount)
        {
            gameObject.GetComponent<EnemyDamageFlash>().DamageFlash();
            _vidaAtual -= amount;
        }
    }
}