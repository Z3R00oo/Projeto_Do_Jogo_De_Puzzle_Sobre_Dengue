using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelButtonController : MonoBehaviour {

    public int levelToGo; //Determina o numero do level a ser carregado
    public int currentStar; //Determina a quantidade de estrelas atual
    public int totalPlayerMovimentsToScore; //Determina a quantidade de movimentos do player para ganhar a estrela
    public int totalObjectivesToScore; //Determina a quantidade de objetivos para ganhar a estrela

    public float totalTimeToScore; //Determina o tempo para ganhar a estrela

    public bool isLevelPassed; //Determina se o level ja foi concluido

    public Text levelNumber; //Determina o numero do level

    public GameObject boxUnlocked; //Determina o objeto da caixa desbloqueada
    public GameObject boxLocked; //Determina o objeto da caixa bloqueada
    public GameObject star; //Determina o objeto da estrela

    private bool isUnlocked; //Determina se o level está desbloaqueado
    private bool isUnlockedStar; //Determina se a estrela está desbloqueada

    private MissionsManager missionsManager; //Associa o controlador de missões ao botão de level
    private MainMenuController mainMenuController; //Associa o menu principal ao botão de level

    // Usado apenas na Inicialização
    void Start()
    {

        missionsManager = FindObjectOfType<MissionsManager>(); //Procura na cena um objeto com as caracteristicas do controlador de missão

        mainMenuController = FindObjectOfType<MainMenuController>(); //Procura na cena um objeto com as caracteristicas do menu principal

        isUnlocked = ApplicationController.isUnlocked(levelToGo); //Determina se o level está desbloqueado

        isUnlockedStar = ApplicationController.isUnlockedStar(currentStar); //Determina se a estrela está desbloqueada

        if (isUnlockedStar && !isLevelPassed) //Caso a estrela esteja desbloqueada e o level ja não tenha sido concluido
        {
            star.SetActive(true); // O objeto da estrela é ativado
            ApplicationController.SetCurrentStar(currentStar); //Determina A quantidade atual de estrelas
            mainMenuController.currentStars++; //Aumenta em 1 a quantidade de estrelas atual
            isLevelPassed = true; //Determina que o level foi concluido
        }
        else //Caso isso não aconteça
        {
            star.SetActive(false); // A estrela não é ativada
            isLevelPassed = false; //Detemrina que o level não foi concluido
        }


        if (isUnlocked || levelToGo == 1) //Caso o level esteja desbloqueado ou seja o level 1
        {
            boxUnlocked.SetActive(true); //O objeto de caixa desbloqueada é ativado
            boxLocked.SetActive(false); //O objeto de caixa bloqueada é desativado
        }
        else //Caso isso não aconteça
        {
            boxUnlocked.SetActive(false); //O objeto de caixa desbloqueada é desativado
            boxLocked.SetActive(true); //O objeto de caixa bloqueada é ativado
        }

        levelNumber.text = levelToGo.ToString(); //O texto do numero do level recebe o numero do level que deve carregar

    }

    // Usado quando clicar no determinado level
    public void OnClick()
    {
        if (isUnlocked || levelToGo == 1) //Caso o level esteja desbloqueado ou seja o level 1
        {
            ApplicationController.SetCurrentLevel(levelToGo); //Determina A quantidade atual de levels
            //SceneManager.LoadScene("Level" + levelToGo); //Carrega o determinado level
            SceneManager.LoadScene("LoadingScene"); //Carrega a cena de Loading
            missionsManager.isNotPassed = false; //Determina que não pode concluir um level
            missionsManager.levelToGo = levelToGo;
            missionsManager.moviments = totalPlayerMovimentsToScore; //a quantidade de movimentos do controlador de missão recebe o total de movimentos do player para ganhar a estrela
            missionsManager.time = totalTimeToScore; //O tempo do controlador de missão recebe o tempo para ganhar a estrela
            missionsManager.objectives = totalObjectivesToScore; //a quantidade de objetivos controlador de missão recebe o total de objetivos para ganhar a estrela
            missionsManager.isPassed = isLevelPassed; //Determina que o bool do controlador de missão recebe o valor do bool deste level
            mainMenuController.buttonSoundFX.Play(); //Determina que o som do botão deve tocar
        }
    }
}
