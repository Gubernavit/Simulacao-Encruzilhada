using UnityEngine;

public class MovHorizontal : MonoBehaviour
{
    bool Colisao = false;
    float Velocidade = 0.02f;
    Vector3 pos = new Vector3(0f, 0f, 0f);
    void Start()
    {
        pos = transform.position;
        transform.position = pos;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Final")
        {
            pos.x = -13f;
            transform.position = pos;
            Colisao = false;
        }
        else if (collision.gameObject.tag == "CarVertical" && transform.position.x >= -1.47f )
        {
            Colisao = false;
        }
        else
        {
            Colisao = true;
        }
        if (collision.gameObject.tag == "CarHorizontal")
        {
            Colisao = true;
        }
        
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        Colisao = false;
    }
    void Update()
    {
        transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        if (!Colisao)
        {
            pos.x += Velocidade;
            pos.y = 0f;
            transform.position = pos;          
        }
    }
}