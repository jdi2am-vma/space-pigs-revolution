﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SistemaPerguntas : MonoBehaviour
{
    Pergunta perguntaEmUso;

    public void DefinirPerguntaEmUso(Pergunta p)
    {
        perguntaEmUso = p;
    }

    public void EvtAlternativaEscolhida(int indiceAlternativa)
    {
        if (indiceAlternativa > 3)
            Debug.LogError("Alternativa não válida");

        // se alternativa tentada é a certa
        if (perguntaEmUso.resposta == indiceAlternativa)
            ConfirmarAcerto();

        TransicaoFases.ProximaFase();
    }

    void ConfirmarAcerto()
    {
        // marcar pergunta como usada
        perguntaEmUso.jaRespondida = true;

        // dar uma vida a mais
        VidaMaxJogador.vidaMax++;
    }
}
