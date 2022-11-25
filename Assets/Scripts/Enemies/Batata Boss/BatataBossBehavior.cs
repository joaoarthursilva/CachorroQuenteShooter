using System;
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

        [Header("Ataque Baixo")] public Transform pontoAtaqueBaixo;
        public GameObject ondaDeBatataObject;
        public bool ataque1 = false;
        private int _atacaBaixoCounter=0;

        [Header("Ataque Cima")] public Transform pontoAtaqueCima;
        public GameObject batataAfiadaObject;
        public bool ataque2 = false;
        private int _atacaCimaCounter=0;

        [Header("Ataque Cima com Refri")] public bool ataque3 = false;

        private void Start()
        {
            _vidaAtual = vidaBatata;
        }

        private void FixedUpdate()
        {
            if (toggleRefri) LevantaRefrigerante();
            else AbaixaRefrigerante();
            if(_atacaBaixoCounter>=3)
            {
                CancelInvoke(nameof(AtacaBaixo));
                _atacaBaixoCounter = 0;
            }
            if(_atacaCimaCounter>=3)
            {
                CancelInvoke(nameof(AtacaCima));
                _atacaCimaCounter = 0;
            }
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
            if (_vidaAtual <= 0)
                VenceuOBoss();
        }

        private void Ataque1() // em baixo
        {
            InvokeRepeating(nameof(AtacaBaixo), 0f, .7f);
            // AtacaBaixo();
        }

        private void Ataque2() // em cima
        {
            InvokeRepeating(nameof(AtacaCima), 0f, .7f);
            // AtacaCima();
        }

        private void Ataque3() // levanta refri e ataca em cima
        {
            toggleRefri = true;
            Ataque2();
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