using System.Collections;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public static CameraShake Instance;

    public Vector3 ShakeOffset { get; private set; }

    void Awake()
    {
        Instance = this;
    }

    public void Sacudir(float duracion, float intensidad)
    {
        StopAllCoroutines();
        StartCoroutine(Shake(duracion, intensidad));
    }

    IEnumerator Shake(float duracion, float intensidad)
    {
        float tiempo = 0f;

        while (tiempo < duracion)
        {
            ShakeOffset = (Vector3)Random.insideUnitCircle * intensidad;
            tiempo += Time.deltaTime;
            yield return null;
        }

        ShakeOffset = Vector3.zero;
    }
}