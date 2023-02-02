using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class LensDiss : MonoBehaviour
{
    Volume ppvolume;
    private LensDistortion ld;

    private bool startGame;

    // Start is called before the first frame update
    void Start()
    {
        ppvolume = gameObject.GetComponent<Volume>();
        ppvolume.profile.TryGet(out ld);
    }

    public void StartGame()
    {
        startGame = true;
    }

    public void EndGame()
    {
        startGame = false;
    }

    void Update()
    {
        if (startGame)
        {
            float target = 0f;

            float delta = target - ld.intensity.value;
            delta *= 1 * Time.deltaTime;

            ld.intensity.value += delta;
        }
        else
        {
            float target = -1f;

            float delta = target - ld.intensity.value;
            delta *= 1 * Time.deltaTime;

            ld.intensity.value += delta;
        }

    }
}
