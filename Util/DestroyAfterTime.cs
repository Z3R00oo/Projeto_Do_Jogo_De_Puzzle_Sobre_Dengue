using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour {

    public float timeToDestroy; //Quantidade de tempo até destruir

    private float currentTimeToDestroy; //Quantidade atual de tempo até destruir
	
	//Usado a cada frame
	void Update () {

        currentTimeToDestroy += Time.deltaTime; //A quantidade atual de tempo até destruir começa a contar durante os frames

        if(currentTimeToDestroy >= timeToDestroy) //Caso a quantidade atual de tempo até destruir for maior ou igual à quantidade de tempo até destruir
        {
            currentTimeToDestroy = 0; //A quantidade atual de tempo até destruir recebe zero
            Destroy(gameObject); //O objeto associado a este código é destruído
        }
		
	}
}
