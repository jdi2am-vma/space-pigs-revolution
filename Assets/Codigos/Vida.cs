﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vida : MonoBehaviour
{
    public int vida;

    /// Desconta vida pelo dano,
    /// talvez a vida descontada não seja a mesma do dano
    /// por conta da possível presença do escudo.
    /// Retorna a vida descontada.
    public int CausarDano(int dano)
    {
        // TODO: Implementar efeito de escudo
        vida -= dano;
        return dano;
    }
}