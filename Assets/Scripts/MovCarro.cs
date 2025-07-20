using UnityEngine;

public class MovCarro : MonoBehaviour
{
    Vector3 pos = new Vector3(0f, 0f, 0f);
    [SerializeField] private float velocidade = 0.02f;
    [SerializeField] private bool movimentoHorizontal = true; // true = vermelho (horizontal)

    private bool esperando = false;
    private bool atravessando = false;

    private static bool cruzamentoOcupado = false;

    private void Start()
    {
        pos = transform.position;
        transform.position = pos;
    }

    void Update()
    {
        if (!atravessando && esperando)
        {
            if (!cruzamentoOcupado)
            {
                esperando = false;
                atravessando = true;
                cruzamentoOcupado = true;
            }
            else return;
        }

        if (!atravessando && !esperando && !cruzamentoOcupado)
        {
            atravessando = true;
            cruzamentoOcupado = true;
        }

        if (atravessando)
        {
            if (movimentoHorizontal)
                pos.x += velocidade;
            else
                pos.y -= velocidade;

            transform.position = pos;
        }
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Intersecao")
        {
            if (cruzamentoOcupado && !atravessando)
            {
                esperando = true;
            }
        }
    }


    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Intersecao")
        {
            atravessando = false;
            esperando = false;
            cruzamentoOcupado = false;
        }
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Final")
        {
            if (movimentoHorizontal)
                pos.x = -13f;
            else
                pos.y = 9f;

            transform.position = pos;
        }
    }
}

//using UnityEngine;
//using static UnityEditor.PlayerSettings;

//public class MovCarro : MonoBehaviour
//{
//    Vector3 pos = new Vector3 (0f, 0f, 0f);
//    [SerializeField] private float velocidade = 0.02f;
//    [SerializeField] private bool movimentoHorizontal = true; 

//    private bool esperando = false;
//    private bool atravessando = false;

//    private static bool cruzamentoOcupado = false;

//    private void Start()
//    {
//        pos = transform.position;
//        transform.position = pos;
//    }
//    void Update()
//    {
//        if (esperando) return;

//        if (!atravessando && !cruzamentoOcupado)
//        {
//            cruzamentoOcupado = true;
//            atravessando = true;
//        }

//        if (atravessando || !cruzamentoOcupado)
//        {
//            if (movimentoHorizontal)
//                pos.x += velocidade;
//            else
//                pos.y -= velocidade;

//            transform.position = pos;
//        }
//    }

//    void OnTriggerEnter2D(Collider2D collision)
//    {
//        if (collision.gameObject.tag == "Intersecao")
//        {
//            if (cruzamentoOcupado && !atravessando)
//                esperando = true;
//        }

//    }
//    void OnCollisionEnter2D(Collision2D collision)
//    { 
//        if (collision.gameObject.tag == "Final")
//        {
//            if (movimentoHorizontal)
//                pos.x = -13f;
//            else
//                pos.y = 9f;

//            transform.position = pos;
//        }
//    }
//        void OnTriggerExit2D(Collider2D collision)
//    {
//        if (collision.gameObject.tag == "Intersecao")
//        {
//            atravessando = false;
//            esperando = false;
//            cruzamentoOcupado = false;
//        }
//    }
//}
