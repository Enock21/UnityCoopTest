using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private BoxCollider2D boxCollider;

    private Vector3 moveDelta;

    //Útil para chamar a caixa de colisão quando não quisermos que um personagem atravesse um objeto
    private RaycastHit2D hit;

    //Velocidade do player, usada no calculo de movimento. [SerializeField] permite que o atributo privado speedMove possa se tornar visível na interface gráfica da Unity
    [SerializeField]
    private float speedMove;

    public void Start()
    {
        //Assim que o game inicia, uma caixa de colisão é criada
        boxCollider = GetComponent<BoxCollider2D>();
    }

    //FixedUpdate() funciona bem com o uso de physics
    public void FixedUpdate()
    {
        mover();

        colisao();
    }

    //Função que implementa o movimento do personagem principal
    public void mover()
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
    }

    //Função que implementa o sistema de colisão. Impedirá o personagem de se mover quando este entrar em contato com uma caixa de colisão que se encontra em ao menos uma das layers especificadas.
    public void colisao()
    {
        //ATENÇÃO! Lembrar de desabilitar a opção "Querries Start in Colliders" em Edit > Project Settings > Physics2D. Caso esteja habilitado o player irá colidir consigo próprio, e portanto não irá se mover

        //Invoca a caixa de colisão do player a cada frame. Indicará se houve ou não colisão no eixo y. Se a caixa retornar null, o personagem pode se mover na direção apontada. Caso contrário, não.
        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(0,moveDelta.y), Mathf.Abs(moveDelta.y * Time.deltaTime * speedMove), LayerMask.GetMask("Actor", "Blocking"));

        //Faz o sprite se mover (apenas no eixo y). Time.deltaTime serve para atualizar a posição no eixo com base no tempo que se passou desde o último frame até o atual. Lembrar que este tempo varia.
        if(hit.collider == null)
        {
            transform.Translate(0, moveDelta.y * Time.deltaTime * speedMove, 0);
        }


        //Invoca a caixa de colisão do player a cada frame. Indicará se houve ou não colisão no eixo x. Se a caixa retornar null, o personagem pode se mover na direção apontada. Caso contrário, não.
        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(moveDelta.x,0), Mathf.Abs(moveDelta.x * Time.deltaTime * speedMove), LayerMask.GetMask("Actor", "Blocking"));

        //Faz o sprite se mover (apenas no eixo x). Time.deltaTime serve para atualizar a posição no eixo com base no tempo que se passou desde o último frame até o atual. Lembrar que este tempo varia.
        if(hit.collider == null)
        {
            transform.Translate(moveDelta.x * Time.deltaTime * speedMove, 0, 0);
        }
        
    }
}
