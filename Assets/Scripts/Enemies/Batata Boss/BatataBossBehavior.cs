using System;
using UnityEngine;

namespace Enemies.Batata_Boss
{
    public class BatataBossBehavior : MonoBehaviour
    {
        [Header("Vida")] public int vidaBatata = 100;
        public int _vidaAtual;

        [Header("Ataque Refrigerante")] public GameObject refrigerante;
        public Vector3 refriUpPosition;
        public Vector3 refriDownPosition;
        public float refriMoveSpeed = 3f;
        public bool toggleRefri = false;


        [Header("Ataque Baixo")] public Transform pontoAtaqueBaixo;
        public GameObject ondaDeBatataObject;
        public bool shootBaixo = false;
        [Header("Ataque Cima")] public Transform pontoAtaqueCima;
        public GameObject batataAfiadaObject;
        public bool shootCima = false;

        private void Start()
        {
            _vidaAtual = vidaBatata;
        }

        private void FixedUpdate()
        {
            if (toggleRefri) LevantaRefrigerante();
            else AbaixaRefrigerante();

            if (shootCima)
            {
                AtacaCima();
                shootCima = false;
            }

            if (shootBaixo)
            {
                AtacaBaixo();
                shootBaixo = false;
            }

            if (_vidaAtual <= 0)
                VenceuOBoss();
        }

        private void VenceuOBoss()
        {
            Debug.Log("Venceu");
        }

        private void AtacaBaixo()
        {
            Instantiate(ondaDeBatataObject, pontoAtaqueBaixo.position, Quaternion.identity);
        }

        private void AtacaCima()
        {
            Instantiate(batataAfiadaObject, pontoAtaqueCima.position, Quaternion.identity);
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