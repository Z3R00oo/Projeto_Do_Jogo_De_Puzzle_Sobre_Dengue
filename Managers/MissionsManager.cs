using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionsManager : MonoBehaviour {

    public int moviments; //Quantidade de Movimentos para ganhar a Estrela
    public int currentMoviments; //Quantidade atual de Movimentos
    public int objectives; //Quantidade de Objetivos para ganhar a Estrela
    public int currentObjectives; //Quantidade atual de Objetivos
    public int levelToGo;

    public float time; //Quantidade de Tempo para ganhar a Estrela
    public float currentTime; //Quantidade atual de Tempo

    public bool isNotPassed; //Determina que não foi concluido nenhum level
    public bool isPassed; //Determina se o level foi concluido ou não

    // Usado apenas na inicialização
    void Start () {

        DontDestroyOnLoad(gameObject); //Faz com que o objeto que carrega este código não seja destruído na troca de cenas

    }
	
	// Usado a cada frame
	void Update () {

        currentMoviments = moviments; //Faz a quantidade atual de Movimentos receber a quantidade para ganhar a Estrela
        currentObjectives = objectives; //Faz a quantidade atual de Objetivos receber a quantidade para ganhar a Estrela
        currentTime = time; //Faz a quantidade atual de Objetivos receber a quantidade para ganhar a Estrela

        if (isNotPassed)
        {
            moviments = 0; //Faz a quantidade atual de Movimentos receber a quantidade para ganhar a Estrela
            objectives = 0; //Faz a quantidade atual de Objetivos receber a quantidade para ganhar a Estrela
            time = 0; //Faz a quantidade atual de Objetivos receber a quantidade para ganhar a Estrela
        }
		
	}
}
