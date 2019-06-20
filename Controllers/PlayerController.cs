using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float displacement; //Valor do deslocamento do Personagem

    public bool isDead; //Determina se o personagem está morto ou não

    public GameObject frontVision; //Associa o objeto do Personagem que olha para tras
    public GameObject backVision; //Associa o objeto do Personagem que olha para frente
    public GameObject leftVision; //Associa o objeto do Personagem que olha para a esquerda
    public GameObject rightVision; //Associa o objeto do Personagem que olha para a direita

    public AudioSource moveSoundFX; //Determina um Som para o movimento do player
    public AudioSource successSoundFX; //Determina um som para quando a fase é completada
    public AudioSource collectSoundFX; //Determina um som para quando elimina um foco do mosquito da dengue
    public AudioSource failSoundFX; //Determina um som para quando não completa a fase
    public AudioSource backgroundMusic; //Determina uma musica de fundo

    private bool canMoveUp = true, canMoveDown = true, canMoveLeft = true, canMoveRight = true; //Determina se o Personagem pode ou não se mover para determinada direção

    private GameplayManager gameManager; //Associa o "GameManager" ao personagem
    private MissionsManager missionsManager; //Associa o "MissionsManager" ao personagem

    //Usado apenas na inicialização
    void Start () {

        missionsManager = FindObjectOfType<MissionsManager>(); //Procura na cena um objeto com as características do "MissionsManager"
        gameManager = FindObjectOfType<GameplayManager>(); //Procura na cena um objeto com as características do "GameManager"

    }
	
	//Usado a cada frame
	void Update () {

        CharacterMoviment(); //Permite que o Personagem se movimentar durante o jogo

        if (gameManager.currentPlayerMoviments <= 0) //Caso a quantidade atual de movimentos for menor ou igual a zero
        {
            gameManager.gameOverPanel.SetActive(true); //O painel de Derrota é ativado na cena
            gameObject.SetActive(false); //O objeto do Jogador é desativado na cena
            isDead = true; //Determina que o Player está morto
            failSoundFX.Play(); //Determina que o som de fracasso deve tocar
            backgroundMusic.Stop(); //Determina que a musica de fundo deve parar
        }
    }

    //Usado para movimentar o Personagem
    private void CharacterMoviment()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && canMoveUp) // Caso eu aperte "Seta para cima" no teclado e o Personagem possa se mover para cima
        {
            gameObject.transform.position = new Vector3(transform.position.x, transform.position.y + displacement, transform.position.z); // determina uma nova posição positiva na Vertical
            gameManager.currentPlayerMoviments--; // Faz com que diminua a quantidade de movimentos do Personagem

            moveSoundFX.Play(); //Determina que o som do movimento do personagem deve tocar

            backVision.SetActive(true); //Faz com o objeto do Personagem que olha para frente fique ativo na cena
            frontVision.SetActive(false); //Faz com o objeto do Personagem que olha para tras fique inativo na cena
            rightVision.SetActive(false); //Faz com o objeto do Personagem que olha para a direita fique inativo na cena
            leftVision.SetActive(false); //Faz com o objeto do Personagem que olha para a esquerda fique inativo na cena
            backVision.GetComponent<Animator>().SetFloat("velocity", 1f); // Faz com que o "animator" do objeto do Personagem que olha para frente, troque de animação através do parâmetro "velocity"
        }
        else
        {
            backVision.GetComponent<Animator>().SetFloat("velocity", 0f); // Faz com que o "animator" do objeto do Personagem que olha para frente, troque de animação através do parâmetro "velocity"
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) && canMoveDown) // Caso eu aperte "Seta para baixo" no teclado e o Personagem possa se mover para baixo
        {
            gameObject.transform.position = new Vector3(transform.position.x, transform.position.y - displacement, transform.position.z); // determina uma nova posição negativa na Vertical
            gameManager.currentPlayerMoviments--; // Faz com que diminua a quantidade de movimentos do Personagem

            moveSoundFX.Play(); //Determina que o som do movimento do personagem deve tocar

            frontVision.SetActive(true); //Faz com o objeto do Personagem que olha para tras fique ativo na cena
            backVision.SetActive(false); //Faz com o objeto do Personagem que olha para frente fique inativo na cena
            rightVision.SetActive(false); //Faz com o objeto do Personagem que olha para a direita fique inativo na cena
            leftVision.SetActive(false); //Faz com o objeto do Personagem que olha para a esquerda fique inativo na cena
            frontVision.GetComponent<Animator>().SetFloat("velocity", 1f); // Faz com que o "animator" do objeto do Personagem que olha para tras, troque de animação através do parâmetro "velocity"

        }
        else
        {
            frontVision.GetComponent<Animator>().SetFloat("velocity", 0f); // Faz com que o "animator" do objeto do Personagem que olha para tras, troque de animação através do parâmetro "velocity"
        }


        if (Input.GetKeyDown(KeyCode.LeftArrow) && canMoveLeft) // Caso eu aperte "Seta para a esquerda" no teclado e o Personagem possa se mover para a esquerda
        {
            gameObject.transform.position = new Vector3(transform.position.x - displacement, transform.position.y, transform.position.z); // determina uma nova posição negativa na Horizontal
            gameManager.currentPlayerMoviments--; // Faz com que diminua a quantidade de movimentos do Personagem

            moveSoundFX.Play(); //Determina que o som do movimento do personagem deve tocar

            leftVision.SetActive(true); //Faz com o objeto do Personagem que olha para a esquerda fique ativo na cena
            backVision.SetActive(false); //Faz com o objeto do Personagem que olha para frente fique inativo na cena
            rightVision.SetActive(false); //Faz com o objeto do Personagem que olha para a direita fique inativo na cena
            frontVision.SetActive(false); //Faz com o objeto do Personagem que olha para tras fique inativo na cena
            leftVision.GetComponent<Animator>().SetFloat("velocity", 1f); // Faz com que o "animator" do objeto do Personagem que olha para a esquerda, troque de animação através do parâmetro "velocity"
        }
        else
        {
            leftVision.GetComponent<Animator>().SetFloat("velocity", 0f); // Faz com que o "animator" do objeto do Personagem que olha para a esquerda, troque de animação através do parâmetro "velocity"
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) && canMoveRight) // Caso eu aperte "Seta para a direita" no teclado e o Personagem possa se mover para a direita
        {
            gameObject.transform.position = new Vector3(transform.position.x + displacement, transform.position.y, transform.position.z); // determina uma nova posição positiva na Horizontal
            gameManager.currentPlayerMoviments--; // Faz com que diminua a quantidade de movimentos do Personagem

            moveSoundFX.Play(); //Determina que o som do movimento do personagem deve tocar

            rightVision.SetActive(true); //Faz com o objeto do Personagem que olha para a direita fique ativo na cena
            backVision.SetActive(false); //Faz com o objeto do Personagem que olha para frente fique inativo na cena
            leftVision.SetActive(false); //Faz com o objeto do Personagem que olha para a esquerda fique inativo na cena
            frontVision.SetActive(false); //Faz com o objeto do Personagem que olha para tras fique inativo na cena
            rightVision.GetComponent<Animator>().SetFloat("velocity", 1f); // Faz com que o "animator" do objeto do Personagem que olha para a direita, troque de animação através do parâmetro "velocity"
        }
        else
        {
            rightVision.GetComponent<Animator>().SetFloat("velocity", 0f); // Faz com que o "animator" do objeto do Personagem que olha para a direita, troque de animação através do parâmetro "velocity"
        }
    }

    //Usado quando o Personagem entra em uma determinada área de colisão
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Objective") //Caso o Personagem entre em uma área marcada como "Objective"
        {
            gameManager.currentObjectivesCompleted++; //Faz com que aumente a quantidade de objetivos concluídos
            collectSoundFX.Play();
            Destroy(collision.gameObject); //Destroi o Objeto com o qual o Personagem colidiu
        }

        if(collision.gameObject.tag == "Exit") //Caso o Personagem entre em uma área marcada como "Exit"
        {
            if (missionsManager.currentMoviments <= gameManager.currentPlayerMoviments && missionsManager.currentObjectives == gameManager.currentObjectivesCompleted //Caso a quantidade de Movimentos for maior ou igual ao total necessário para ganhar a Estrela e a quantidade de Objetivos for igual ao total necessário para ganhar a Estrela
                && missionsManager.currentTime >= gameManager.currentTime && missionsManager.currentMoviments > 0 //E a quantidade de Tempo for maior ou igual a quantidade necessária para ganhar a Estrela e a quantidade de Movimentos for maior que zero
                && missionsManager.currentObjectives > 0 && missionsManager.currentTime > 0 && !missionsManager.isPassed) //E a quantidade de Objetivos for maior que zero e a quantidade de Tempo por maior que zero
            {
                ApplicationController.UnlockedStar(ApplicationController.GetCurrentStar() + 1); //A Estrela da atual fase deve ser desbloqueada
            }

            ApplicationController.UnlockedLevel(ApplicationController.GetCurrentLevel() + 1); //O próximo Level deve ser desbloqueado
            gameObject.SetActive(false); //O Objeto do Personagem será desativado na cena
            Cursor.visible = true; //Faz com que o cursor do mouse apareça na tela
            gameManager.isFinished = true; //Determina que o jogo se encerrou
            gameManager.gameWinPanel.SetActive(true); //Ativa o painel de Vitória na cena
            successSoundFX.Play(); //Determina que o som de fase concluida deve tocar
            backgroundMusic.Stop(); //Determina que a musica de fundo deve parar
        }

        if (collision.gameObject.tag == "Enemy") //Caso o Personagem entre em uma área marcada como "Enemy"
        {
            gameObject.SetActive(false); //O Objeto do Personagem será desativado na cena
            isDead = true; //Determina que o personagem morreu
            Cursor.visible = true; //Faz com que o cursor do mouse apareça na tela
            gameManager.isFinished = true; //Determina que o jogo se encerrou
            gameManager.gameOverPanel.SetActive(true); //Ativa o painel de Derrota na cena
            failSoundFX.Play(); //Determina que o som de fracasso deve tocar
            backgroundMusic.Stop(); //Determina que a musica de fundo deve parar

        }



        //Determina para que lado o personagem pode se mover
        
        if(collision.gameObject.tag == "Up_Block" && canMoveUp) //Caso o Personagem entre em uma área marcada com "Up_Block" e ele possa se mover para cima
        {
            canMoveUp = false; //Determina que o Personagem não pode se mover para cima
        }

        if (collision.gameObject.tag == "Down_Block" && canMoveDown) //Caso o Personagem entre em uma área marcada com "Down_Block" e ele possa se mover para baixo
        {
            canMoveDown = false; //Determina que o Personagem não pode se mover para baixo
        }

        if (collision.gameObject.tag == "Left_Block" && canMoveLeft) //Caso o Personagem entre em uma área marcada com "Left_Block" e ele possa se mover para a esquerda
        {
            canMoveLeft = false; //Determina que o Personagem não pode se mover para a esquerda
        }

        if (collision.gameObject.tag == "Right_Block" && canMoveRight) //Caso o Personagem entre em uma área marcada com "Right_Block" e ele possa se mover para a direita
        {
            canMoveRight = false; //Determina que o Personagem não pode se mover para a direita
        }



        if (collision.gameObject.tag == "Up_Down_Block" && canMoveUp && canMoveDown) //Caso o Personagem entre em uma área marcada com "Up_Down_Block" e ele possa se mover para cima e para baixo
        {
            canMoveUp = false; //Determina que o Personagem não pode se mover para cima
            canMoveDown = false; //Determina que o Personagem não pode se mover para baixo
        }

        if (collision.gameObject.tag == "Up_Left_Block" && canMoveUp && canMoveLeft) //Caso o Personagem entre em uma área marcada com "Up_Left_Block" e ele possa se mover para cima e para a esquerda
        {
            canMoveUp = false; //Determina que o Personagem não pode se mover para cima
            canMoveLeft = false; //Determina que o Personagem não pode se mover para a esquerda
        }

        if (collision.gameObject.tag == "Up_Right_Block" && canMoveUp && canMoveRight) //Caso o Personagem entre em uma área marcada com "Up_Right_Block" e ele possa se mover para cima e para a direita
        {
            canMoveUp = false; //Determina que o Personagem não pode se mover para cima
            canMoveRight = false; //Determina que o Personagem não pode se mover para a direita
        }



        if (collision.gameObject.tag == "Down_Left_Block" && canMoveDown && canMoveLeft) //Caso o Personagem entre em uma área marcada com "Down_Left_Block" e ele possa se mover para baixo e para a esquerda
        {
            canMoveDown = false; //Determina que o Personagem não pode se mover para baixo
            canMoveLeft = false; //Determina que o Personagem não pode se mover para a direita
        }

        if (collision.gameObject.tag == "Down_Right_Block" && canMoveDown && canMoveRight) //Caso o Personagem entre em uma área marcada com "Down_Right_Block" e ele possa se mover para baixo e para a direita
        {
            canMoveDown = false; //Determina que o Personagem não pode se mover para baixo
            canMoveRight = false; //Determina que o Personagem não pode se mover para a direita
        }



        if (collision.gameObject.tag == "Left_Right_Block" && canMoveLeft && canMoveRight) //Caso o Personagem entre em uma área marcada com "Left_Right_Block" e ele possa se mover para a esquerda e para a direita
        {
            canMoveLeft = false; //Determina que o Personagem não pode se mover para a direita
            canMoveRight = false; //Determina que o Personagem não pode se mover para a direita
        }



        if (collision.gameObject.tag == "Up_Down_Left_Block" && canMoveUp && canMoveDown && canMoveLeft) //Caso o Personagem entre em uma área marcada com "Up_Down_Left_Block" e ele possa se mover para cima, para baixo e para a esquerda
        {
            canMoveUp = false; //Determina que o Personagem não pode se mover para cima
            canMoveDown = false; //Determina que o Personagem não pode se mover para baixo
            canMoveLeft = false; //Determina que o Personagem não pode se mover para a direita
        }

        if (collision.gameObject.tag == "Up_Down_Right_Block" && canMoveUp && canMoveDown && canMoveRight) //Caso o Personagem entre em uma área marcada com "Up_Down_Right_Block" e ele possa se mover para cima, para baixo e para a direita
        {
            canMoveUp = false; //Determina que o Personagem não pode se mover para cima
            canMoveDown = false; //Determina que o Personagem não pode se mover para baixo
            canMoveRight = false; //Determina que o Personagem não pode se mover para a direita
        }

        if (collision.gameObject.tag == "Up_Left_Right_Block" && canMoveUp && canMoveLeft && canMoveRight) //Caso o Personagem entre em uma área marcada com "Up_Left_Right_Block" e ele possa se mover para cima, para a esquerda e para a direita
        {
            canMoveUp = false; //Determina que o Personagem não pode se mover para cima
            canMoveLeft = false; //Determina que o Personagem não pode se mover para a esquerda
            canMoveRight = false; //Determina que o Personagem não pode se mover para a direita
        }

        if (collision.gameObject.tag == "Down_Left_Right_Block" && canMoveDown && canMoveLeft && canMoveRight) //Caso o Personagem entre em uma área marcada com "Down_Left_Right_Block" e ele possa se mover para baixo, para a esquerda e para a direita
        {
            canMoveDown = false; //Determina que o Personagem não pode se mover para baixo
            canMoveLeft = false; //Determina que o Personagem não pode se mover para a esquerda
            canMoveRight = false; //Determina que o Personagem não pode se mover para a direita
        }



        if (collision.gameObject.tag == "Up_Down_Left_Right_Block" && canMoveUp && canMoveDown && canMoveRight) //Caso o Personagem entre em uma área marcada com "Up_Down_Left_Right_Block" e ele possa se mover para cima, para baixo, para a esquerda e para a direita
        {
            canMoveUp = false; //Determina que o Personagem não pode se mover para cima
            canMoveDown = false; //Determina que o Personagem não pode se mover para baixo
            canMoveLeft = false; //Determina que o Personagem não pode se mover para a esquerda
            canMoveRight = false; //Determina que o Personagem não pode se mover para a direita
        }
    }

    //Usado quando o Personagem sai de uma determinada área de colisão
    private void OnTriggerExit2D(Collider2D collision)
    {
        //Determina para que lado o personagem pode se mover

        if (collision.gameObject.tag == "Up_Block" && !canMoveUp) //Caso o Personagem saia de uma área marcada com "Up_Block" e ele não possa se mover para cima
        {
            canMoveUp = true; //Determina que o Personagem pode se mover para cima
        }

        if (collision.gameObject.tag == "Down_Block" && !canMoveDown) //Caso o Personagem saia de uma área marcada com "Down_Block" e ele não possa se mover para baixo
        {
            canMoveDown = true; //Determina que o Personagem pode se mover para baixo
        }

        if (collision.gameObject.tag == "Left_Block" && !canMoveLeft) //Caso o Personagem saia de uma área marcada com "Left_Block" e ele não possa se mover para a esquerda
        {
            canMoveLeft = true; //Determina que o Personagem pode se mover para a esquerda
        }

        if (collision.gameObject.tag == "Right_Block" && !canMoveRight) //Caso o Personagem saia de uma área marcada com "Right_Block" e ele não possa se mover para a direita
        {
            canMoveRight = true; //Determina que o Personagem pode se mover para a direita
        }



        if (collision.gameObject.tag == "Up_Down_Block" && !canMoveUp && !canMoveDown) //Caso o Personagem saia de uma área marcada com "Up_Down_Block" e ele não possa se mover para cima e para baixo
        {
            canMoveUp = true; //Determina que o Personagem pode se mover para cima
            canMoveDown = true; //Determina que o Personagem pode se mover para baixo
        }

        if (collision.gameObject.tag == "Up_Left_Block" && !canMoveUp && !canMoveLeft) //Caso o Personagem saia de uma área marcada com "Up_Left_Block" e ele não possa se mover para cima e para a esquerda
        {
            canMoveUp = true; //Determina que o Personagem pode se mover para cima
            canMoveLeft = true; //Determina que o Personagem pode se mover para a esquerda
        }

        if (collision.gameObject.tag == "Up_Right_Block" && !canMoveUp && !canMoveRight) //Caso o Personagem saia de uma área marcada com "Up_Right_Block" e ele não possa se mover para cima e para a direita
        {
            canMoveUp = true; //Determina que o Personagem pode se mover para cima
            canMoveRight = true; //Determina que o Personagem pode se mover para a direita
        }



        if (collision.gameObject.tag == "Down_Left_Block" && !canMoveDown && !canMoveLeft) //Caso o Personagem saia de uma área marcada com "Down_Left_Block" e ele não possa se mover para baixo e para a esquerda
        {
            canMoveDown = true; //Determina que o Personagem pode se mover para baixo
            canMoveLeft = true; //Determina que o Personagem pode se mover para a direita
        }

        if (collision.gameObject.tag == "Down_Right_Block" && !canMoveDown && !canMoveRight) //Caso o Personagem saia de uma área marcada com "Down_Right_Block" e ele não possa se mover para baixo e para a direita
        {
            canMoveDown = true; //Determina que o Personagem pode se mover para baixo
            canMoveRight = true; //Determina que o Personagem pode se mover para a direita
        }



        if (collision.gameObject.tag == "Left_Right_Block" && !canMoveLeft && !canMoveRight) //Caso o Personagem saia de uma área marcada com "Left_Right_Block" e ele não possa se mover para a esquerda e para a direita
        {
            canMoveLeft = true; //Determina que o Personagem pode se mover para a direita
            canMoveRight = true; //Determina que o Personagem pode se mover para a direita
        }



        if (collision.gameObject.tag == "Up_Down_Left_Block" && !canMoveUp && !canMoveDown && !canMoveLeft) //Caso o Personagem saia de uma área marcada com "Up_Down_Left_Block" e ele não possa se mover para cima, para baixo e para a esquerda
        {
            canMoveUp = true; //Determina que o Personagem pode se mover para cima
            canMoveDown = true; //Determina que o Personagem pode se mover para baixo
            canMoveLeft = true; //Determina que o Personagem pode se mover para a direita
        }

        if (collision.gameObject.tag == "Up_Down_Right_Block" && !canMoveUp && !canMoveDown && !canMoveRight) //Caso o Personagem saia de uma área marcada com "Up_Down_Right_Block" e ele não possa se mover para cima, para baixo e para a direita
        {
            canMoveUp = true; //Determina que o Personagem pode se mover para cima
            canMoveDown = true; //Determina que o Personagem pode se mover para baixo
            canMoveRight = true; //Determina que o Personagem pode se mover para a direita
        }

        if (collision.gameObject.tag == "Up_Left_Right_Block" && !canMoveUp && !canMoveLeft && !canMoveRight) //Caso o Personagem saia de uma área marcada com "Up_Left_Right_Block" e ele não possa se mover para cima, para a esquerda e para a direita
        {
            canMoveUp = true; //Determina que o Personagem pode se mover para cima
            canMoveLeft = true; //Determina que o Personagem pode se mover para a esquerda
            canMoveRight = true; //Determina que o Personagem pode se mover para a direita
        }

        if (collision.gameObject.tag == "Down_Left_Right_Block" && !canMoveDown && !canMoveLeft && !canMoveRight) //Caso o Personagem saia de uma área marcada com "Down_Left_Right_Block" e ele não possa se mover para baixo, para a esquerda e para a direita
        {
            canMoveDown = true; //Determina que o Personagem pode se mover para baixo
            canMoveLeft = true; //Determina que o Personagem pode se mover para a esquerda
            canMoveRight = true; //Determina que o Personagem pode se mover para a direita
        }



        if (collision.gameObject.tag == "Up_Down_Left_Right_Block" && !canMoveUp && !canMoveDown && !canMoveRight) //Caso o Personagem saia de uma área marcada com "Up_Down_Left_Right_Block" e ele não possa se mover para cima, para baixo, para a esquerda e para a direita
        {
            canMoveUp = true; //Determina que o Personagem pode se mover para cima
            canMoveDown = true; //Determina que o Personagem pode se mover para baixo
            canMoveLeft = true; //Determina que o Personagem pode se mover para a direita
            canMoveRight = true; //Determina que o Personagem pode se mover para a direita
        }
    }
}