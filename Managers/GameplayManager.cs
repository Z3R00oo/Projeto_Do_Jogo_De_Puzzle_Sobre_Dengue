using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameplayManager : MonoBehaviour {

    public int currentPlayerMoviments; //Quantidade atual de movimentos do Personagem
    public int totalObjectives; //Quantidade total de objetivos do level
    public int currentObjectivesCompleted; //Quantidade atual de objetivos cumpridos do level

    public float currentTime; //Quantidade atual de tempo

    public bool isFinished; //Determina se o level acabou ou não

    public Text movimentsText; //Texto da quantidade de movimentos do Personagem
    public Text objectivesText; //Texto da quantidade de objetivos do level
    public Text timerText; //Texto da quantidade de tempo

    public GameObject gameOverPanel; //Painel de Derrota
    public GameObject gameWinPanel; //Painel de Vitória
    public GameObject exit; //Objeto da Saída

    public AudioSource buttonSoundFX; //Determina um som para o botão

    private float startTime; //Tempo inicial

    private MissionsManager missionsManager; //Associa o "MissionsManager" ao controlador de jogo
    private PlayerController player; //Associa o "PlayerCOntroller" ao controlador de jogo

	//Usado apenas na inicialização
	void Start () {

        missionsManager = FindObjectOfType<MissionsManager>(); //Procura na cena um objeto com as características do "MissionsManager"
        player = FindObjectOfType<PlayerController>(); //Procura na cena um objeto com as características do "PlayerController"

        startTime = Time.time; //Determina o tempo inicial

        Cursor.visible = false; //Faz o cursor do mouse desaparecer da tela

    }
	
	//Usado a cada frame
	void Update () {

        if (!isFinished) //Caso o player não tenha desaparecido na cena
        {

            float t = Time.time - startTime; //Determina uma variavel que servirá como contador

            currentTime = t; //O tempo atual deve receber o valor do contador

            string minutes = ((int)t / 60).ToString(); //Determina os minutos
            string seconds = (t % 60).ToString("f0"); //Determina os segundos

            timerText.text = "Tempo: " + minutes + ":" + seconds; //Faz o texto do tempo na tela receber a qauntidade de tempo atual
        }

        movimentsText.text = "Movimentos: " + currentPlayerMoviments.ToString(); //Faz o texto dos movimentos na tela receber a quantidade de movimentos atual
        objectivesText.text = "Focos Eliminados: " + currentObjectivesCompleted.ToString() + "/" + totalObjectives.ToString(); //Faz o texto dos objetivos na tela receber a quantidade atual e a quantidade total de objetivos

        

        if(currentObjectivesCompleted >= totalObjectives) //Caso a quantidade de objetivos atual for maior ou igual ao total de objetivos
        {
            exit.SetActive(true); //O objeto da Saída é ativado na cena
        }

        if (player.isDead) //Caso o Jogador esteja morto
        {
            missionsManager.currentMoviments = 0; //A quantidade de movimentos necessários para ganhar a estrela é reduzida a zero
            missionsManager.currentObjectives = 0; //A quantidade de objetivos necessários para ganhar a estrela é reduzida a zero
            missionsManager.currentTime = 0; //A quantidade de tempo necessários para ganhar a estrela é reduzida a zero
        }

	}

    //Usado para recomeçar o Level
    public void RestartLevel()
    {
        ApplicationController.ResetLevel(); //Recarrega o Level atual
        buttonSoundFX.Play(); //Determina que o som do botão deve tocar
    }

    //Usado para sair do Level se não tiver completado
    public void ExitLevelWhenNotPassed()
    {
        ApplicationController.ExitLevel(); //Sai do Level e volta para o Menu Principal
        missionsManager.isNotPassed = true; //Determina que o level não foi concluído
        buttonSoundFX.Play(); //Determina que o som do botão deve tocar
    }

    //Usado para sair do Level se tiver completado
    public void ExitLevelWhenPassed()
    {
        ApplicationController.ExitLevel(); //Sai do Level e volta para o Menu Principal
        buttonSoundFX.Play(); //Determina que o som do botão deve tocar
    }

    //Usado para continuar o jogo
    public void ContinueGame()
    {
        ApplicationController.ContinueGame(); //Continua o Jogo e volta para o Menu de Levels
        buttonSoundFX.Play(); //Determina que o som do botão deve tocar
    }
}
