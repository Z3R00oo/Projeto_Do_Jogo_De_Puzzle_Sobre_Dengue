using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplicationController : MonoBehaviour {

    public static int totalLevels = 15; //Determina a quantidade de Levels
    public static int totalStars = 15; //Determina a quantidade de Estrelas

    private static int currentLevel = 1; //Determina a quantidade atual de Levels
    private static int currentStar = 0; //Detemrina a quantidade atual de Estrelas

    // Usado para desbloquear um Level
    public static void UnlockedLevel(int levelNumber)
    {
        if (totalLevels <= 15) //Caso a quantidade de Levels seja menor ou igual a 15
        {
            PlayerPrefs.SetInt("Level" + levelNumber, 1); //O level é salvo nas configurações
        }
    }

    // Usado para desbloquear uma Estrela
    public static void UnlockedStar(int starNumber)
    {
        if (totalStars <= 15) //Caso a quantidade de Estrelas seja menor ou igual a 15
        {
            PlayerPrefs.SetInt("Star" + starNumber, 1); //A estrela é salva nas configurações
        }
    }

    // Usado para determinar se uma estrela está desbloqueada
    public static bool isUnlockedStar(int starNumber)
    {
        if (PlayerPrefs.GetInt("Star" + starNumber) == 1) //Caso a respectiva estrela esteja salva nas configurações
        {
            return true; //Retorna verdadeiro
        }

        return false; //Retorna falso (padrão)
    }

    // Usado para determinar se um level está desbloqueado
    public static bool isUnlocked(int levelNumber)
    {
        if(PlayerPrefs.GetInt("Level" + levelNumber) == 1) //Caso o respectivo level esteja salvo nas configurações
        {
            return true; //Retorna verdadeiro
        }

        return false; //Retorna falso (padrão)
    }

    //Determina a quantidade de levels atual
    public static void SetCurrentLevel(int levelToSet)
    {
        currentLevel = levelToSet; //A quantidade de level atual recebe o valor do level determinado
    }

    //Determina a quantidade de estrelas atual
    public static void SetCurrentStar(int starToSet)
    {
        currentStar = starToSet; //A quantidade de estrelas atual recebe o valor da estrela determinada
    }

    // Usado para recomeçar o Level
    public static void ResetLevel()
    {
        SceneManager.LoadScene("Level" + currentLevel); //Carrega a cena com valor do level atual
    }

    //Usado para sair do Level
    public static void ExitLevel()
    {
        SceneManager.LoadScene("MainMenu"); //Carrega a cena do menu principal
    }

    //Usado para continuar o jogo
    public static void ContinueGame()
    {
        SceneManager.LoadScene("LevelMenu"); //Carrega a cena com o menu de levels
    }

    // Usado para pegar a quantidade atual de levels
    public static int GetCurrentLevel()
    {
        return currentLevel; //Retorna a quantidade atual de levels
    }

    // Usado para pegar a quantidade atual de estrelas
    public static int GetCurrentStar()
    {
        return currentStar; //Retorna a quantidade atual de estrelas
    }
}
