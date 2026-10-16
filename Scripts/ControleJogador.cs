using UnityEngine;

public class ControleJogador : MonoBehaviour
{

    private CharacterController controller;
    private Transform myCamera; 
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controller = GetComponent<CharacterController>(); //garante que o script tenha acesso ao CharacterController do jogador
        myCamera = Camera.main.transform; //pega a camera principal da cena
    }

    // Update is called once per frame
    void Update()
    {
        float vertical = Input.GetAxis("Vertical"); //movimentação vertical(W/S ou setas)
        float horizontal = Input.GetAxis("Horizontal"); //movimentação horizonal(A/D ou setas)

        Vector3 movimento = new Vector3(horizontal, 0, vertical); //faz a movimentação do personagem
        movimento = myCamera.TransformDirection(movimento); //coloca o personagem na direção da camera para a movimentação
        movimento.y = 0f; //garante que o eixo Y seja 0, para não conflitar com a direção da camera

        controller.Move(movimento * Time.deltaTime * 5f); //cuida do movimento do jogador

        controller.Move(new Vector3(0, -9.81f, 0) * Time.deltaTime); //cuida da gravidade

        if(movimento != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movimento), Time.deltaTime * 10f); //faz o personagem olhar para a direção que ele está se movendo de forma suave
        }
    }
}
