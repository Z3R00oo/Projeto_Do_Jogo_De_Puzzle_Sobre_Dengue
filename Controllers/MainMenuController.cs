using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour {

    public int totalStars; //Quantidade total de estrelas necessárias
    public int currentStars; //Quantidade atual de estrelas adquiridas

    public Text starsText; //Texto da quantidade de estrelas na tela

    public GameObject mainMenu; //Associa o objeto do "MainMenu" 
    public GameObject levelMenu; //Associa o objeto do "LevelMenu"

    public AudioSource buttonSoundFX; //Determina um som para o botão

    // Usado apenas na inicialização
    void Start () {

        //PlayerPrefs.DeleteAll(); //Deleta todas as configurações salvas durante o Game


    }
	
	// Usado a cada frame
	void Update () {

        starsText.text = currentStars + "/" + totalStars; //Determina que o texto da quantidade de estrelas deve receber a quantidade de estrelas atual e e quantidade total
		
	}
    // Usado quando aperta o botão Jogar
    public void StartButton()
    {
        levelMenu.SetActive(true); //Determina que o objeto do Menu de levels deve ativar
        mainMenu.SetActive(false); //Determina que o objeto do Menu principal deve desativar
        buttonSoundFX.Play(); //Determina que o som do botão deve tocar
    }
    // Usado quando aperta o botão Voltar
    public void BackButton()
    {
        levelMenu.SetActive(false); //Determina que o objeto do Menu de levels deve desativar
        mainMenu.SetActive(true); //Determina que o objeto do Menu principal deve ativar
        buttonSoundFX.Play(); //Determina que o som do botão deve tocar
    }
    // Usado quando aperta o botão Sair do menu principal
    public void ExitGame()
    {
        Application.Quit(); //Fecha a aplicação
        buttonSoundFX.Play(); //Determina que o som do botão deve tocar
    }
}
