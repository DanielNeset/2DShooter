using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PostProcessController : MonoBehaviour
{

    public Volume globalVolume;

    private Bloom bloom;
    private Vignette vignette;

    void Start()
    {
        if (globalVolume.profile.TryGet<Bloom>(out bloom))
        {
            Debug.Log("Bloom loaded");
        }
        if (globalVolume.profile.TryGet<Vignette>(out vignette))
        {
            Debug.Log("Vignette loaded");
        }

    }

    public void SetAndDecayIntensity(Color color,float initialBloomIntensity, float initialVignetteIntensity, float duration)
    {
        if (bloom != null && vignette != null)
        {
            bloom.tint.value = color;
            vignette.color.value = color;
            StartCoroutine(DecayIntensity(initialBloomIntensity, initialVignetteIntensity, duration));
        }
    }

    private IEnumerator DecayIntensity(float initialBloomIntensity, float initialVignetteIntensity, float duration)
    {
        float currentTime = 0f;
        while (currentTime < duration)
        {
            // Adjust Bloom and Vignette intensities over time
            if (bloom != null)
            {
                bloom.intensity.value = Mathf.Lerp(initialBloomIntensity, 0f, currentTime / duration);
            }
            if (vignette != null)
            {
                vignette.intensity.value = Mathf.Lerp(initialVignetteIntensity, 0f, currentTime / duration);
            }

            currentTime += Time.deltaTime;
            yield return null; // Wait until the next frame
        }
        if (bloom != null)
        {
            bloom.intensity.value = 0f;
        }
        if (vignette != null)
        {
            vignette.intensity.value = 0f;
        }
    }

}
