using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrolBehaviour : MonoBehaviour {

    public float speed; //Determina a velocidade de deslocamento do Inimigo

    //Inimigo que faz patrulha na Horizontal

    public float maxHorizontalPatrolDistance; //Determina o deslocamento mínimo do Inimgo na Horizontal
    public float minHorizontalPatrolDistance; //Determina o deslocamento máximo do Inimigo na Horizontal

    public GameObject leftDirection; //Determina um objeto que mostra se o Inimigo está olhando para a esquerda
    public GameObject rightDirection; //Determina um objeto que mostra se o Inimigo está olhando para a direita

    private bool isLookingRight = false; //Determina se o Inimigo está olhando para a direita ou não

    private Vector3 currentHorizontalPatrolDistance; //Determina a posição atual do Inimigo na Horizontal

    //

    public bool isVerticalPatrol = false; //Determina se o Inimigo fará a putrulha na Vertical ou não

    //Inimigo que faz patrulha na Vertical

    public float maxVerticalPatrolDistance; //Determina o deslocamento mínimo do Inimgo na Vertical
    public float minVerticalPatrolDistance; //Determina o deslocamento máximo do Inimigo na Vertical

    public GameObject frontVision; //Determina um objeto que mostra se o Inimigo está olhando para tras
    public GameObject backVision; //Determina um objeto que mostra se o Inimigo está olhando para frente

    private bool isLookingToFront = false; //Determina se o Inimigo está olhando para a frente ou não

    private Vector3 currentVerticalPatrolDistance; //Determina a posição atual do Inimigo na Vertical

    //

    //Usado a cada frame
    void Update () {

        currentVerticalPatrolDistance = transform.position; //Determina a posição atual do Inimigo na Vertical

        currentHorizontalPatrolDistance = transform.position; //Determina a posição atual do Inimigo na Horizontal

        if (isVerticalPatrol)
        {
            EnemyVerticalMoviment(); //Permite que o Inimigo se movimente na Vertical durante o jogo
        }
        else
        {
            EnemyHorizontalMoviment(); //Permite que o Inimigo se movimente na Horizontal durante o jogo
        }
    }

    //Usado para movimentar o Inimigo na Horizontal
    private void EnemyHorizontalMoviment()
    {
        if (currentHorizontalPatrolDistance.x >= maxHorizontalPatrolDistance) //Caso a posição atual do Inimigo seja maior ou igual ao deslocamento máximo do Inimigo na Horizontal
        {
            isLookingRight = false; //Determina que o Inimigo não está olhando para a direita
            rightDirection.SetActive(false); //Faz o objeto ficar inativo e o Inimigo não olhar para a direita
            leftDirection.SetActive(true); //Faz o objeto ficar ativo e o Inimigo olhar para a esquerda
        }
        else if (currentHorizontalPatrolDistance.x <= minHorizontalPatrolDistance) //Caso a atual posição do Inimigo seja menor ou igual ao deslocamento mínimo do Inimigo na Horizontal
        {
            isLookingRight = true; //Determina que o Inimigo está olhando para a direita
            rightDirection.SetActive(true); //Faz o objeto ficar ativo e o Inimigo olhar para a direita
            leftDirection.SetActive(false); //Faz o objeto ficar inativo e o Inimigo não olhar para a esquerda
        }

        if (isLookingRight) //Caso o Inimigo esteja olhando para a direita
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime); //Determina que o Inimigo se mova para a direita diante de uma determinada velocidade
        }
        else //Caso o Inimigo não esteja olhando para a direita
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime); //Determina que o Inimigo se mova para a esquerda diante de uma determinada velocidade
        }
    }

    //Usado para movimentar o Inimigo na Vertical
    private void EnemyVerticalMoviment()
    {
        if (currentVerticalPatrolDistance.y >= maxVerticalPatrolDistance) //Caso a posição atual do Inimigo seja maior ou igual ao deslocamento máximo do Inimigo na Vertical
        {
            isLookingToFront = false; //Determina que o Inimigo não está olhando para frente
            frontVision.SetActive(true); //Faz o objeto ficar ativo e o Inimigo olhar para tras
            backVision.SetActive(false); //Faz o objeto ficar inativo e o Inimigo não olhar para frente
        }
        else if (currentVerticalPatrolDistance.y <= minVerticalPatrolDistance) //Caso a posição atual do Inimigo seja menor ou igual ao deslocamento mínimo do Inimigo na Vertical
        {
            isLookingToFront = true; //Determina que o Inimigo está olhando para frente
            frontVision.SetActive(false); //Faz o objeto ficar inativo e o Inimigo não olhar para tras
            backVision.SetActive(true); //Faz o objeto ficar ativo e o Inimigo olhar para frente
        }

        if (isLookingToFront) //Caso o Inimigo esteja olhando para frente
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime); //Determina que o Inimigo se mova para cima diante de uma determinada velocidade
        }
        else //Caso o Inimigo não esteja olhando para frente
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime); //Determina que o Inimigo se mova para baixo diante de uma determinada velocidade
        }
    }
}
