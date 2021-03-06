﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instanciador : MonoBehaviour
{
    [System.Serializable]
    public struct PosicoesRotacoes
    {
        public Vector3 posicao;
        public float rotacao;
    }

    public GameObject projetil;
    public float intervalo;

    public bool atirar {get; set;}
    public PosicoesRotacoes[] posicoesRotacoes;

    GerenciadorJogo gerenJogo;

    void Awake()
    {
        gerenJogo = FindObjectOfType<GerenciadorJogo>();
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoopTiro());
    }

    // Update is called once per frame
    IEnumerator LoopTiro()
    {
        if (!gameObject.CompareTag("Player"))
            yield return new WaitUntil(() => atirar);

        while (true)
        {
            if (!gerenJogo.pausado && !gerenJogo.emPergunta && DeveAtirar() && enabled)
            {
                for (int i = 0; i < posicoesRotacoes.Length; i++)
                {
                    var novo_projetil = Instantiate<GameObject>(
                        projetil,
                        transform.position + posicoesRotacoes[i].posicao,
                        transform.rotation
                    );

                    novo_projetil.GetComponent<Transform>().Rotate(0, 0, posicoesRotacoes[i].rotacao);

                }
            }
            yield return new WaitForSeconds(intervalo);
        }
    }

    bool DeveAtirar()
    {
        if (gameObject.CompareTag("Player"))
            return Input.GetMouseButton(0);
        else
            return atirar;
    }
}
