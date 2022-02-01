using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private BoxCollider2D boxCollider;
    private Vector3 moveDelta;

    public void Start()
    {
        //Assim que o game inicia, uma caixa de colisão é criada
        boxCollider = GetComponent<BoxCollider2D>();
    }

    //FixedUpdate() funciona bem com o uso de physics
    public void FixedUpdate()
    {
        //A função retorna -1, 0 ou 1, dependendo se o personagem se move, respectivamente, para a esquerda, para lugar nenhum ou para a direita
        float x = Input.GetAxisRaw("Horizontal");

        //A função retorna -1, 0 ou 1, dependendo se o personagem se move, respectivamente, para baixo, para lugar nenhum ou para cima
        float y = Input.GetAxisRaw("Vertical");

        //Reset move delta
        moveDelta = new Vector3(x,y,0);

        //Muda a direção do sprite dependendo se está indo para a esquerda ou para a direita
        if (moveDelta.x > 0)
        {
            //Isso é o mesmo que: "transform.localScale = new Vector3(1,1,1);". Cuidado para não colocar como Vector3(1,0,0), pois assim irá encolher o sprite horizontalmente, fazendo-o desaparecer do mapa
            transform.localScale = Vector3.one;
        }else if (moveDelta.x < 0)
        {
            transform.localScale = new Vector3(-1,1,1);
        }

        //Movendo o personagem
        transform.Translate(moveDelta * Time.deltaTime);
    }
}
