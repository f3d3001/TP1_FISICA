using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tejo : MonoBehaviour
{
    public GameObject Disparo;
    public float potencia;
    public float angulo;
    public ForceMode2D modo;

    private void Start()
    {
        StartCoroutine(Disparar());
    }

    private IEnumerator Disparar()
    {
        while (true)
        {
            GameObject disparo = Instantiate(Disparo);
            disparo.transform.position = transform.position + new Vector3(1,1);
            var rbMisil = disparo.GetComponent<Rigidbody2D>();
            AddForceAtAngle(potencia, angulo, rbMisil, modo);

            yield break;
        }
    }

    private void AddForceAtAngle(float potencia, float angulo, Rigidbody2D rb, ForceMode2D modo)
    {
        Vector3 direccion = Quaternion.AngleAxis(angulo, Vector3.forward) * Vector3.right;
        rb.AddForce(direccion * potencia, modo);
    }
}
