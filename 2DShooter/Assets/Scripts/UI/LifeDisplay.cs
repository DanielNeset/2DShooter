using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeDisplay : MonoBehaviour
{

    public int lives = 5;
    public Image lifeImagePrefab;
    private List<Image> lifeImages = new List<Image>();

    void Start()
    {
        CreateLifeImages();
    }

    void UpdateLifeDisplay()
    {
        for (int i = 0; i < lifeImages.Count; i++)
        {
            lifeImages[i].enabled = i < lives;
        }
    }

        void CreateLifeImages()
    {
        for (int i = 0; i < lives; i++)
        {
            Image newLifeImage = Instantiate(lifeImagePrefab, transform);
            float posX = -((lifeImagePrefab.rectTransform.sizeDelta.x + 10) * i);
            newLifeImage.rectTransform.anchoredPosition = new Vector2(posX + 100, 0);
            lifeImages.Add(newLifeImage);
        }

    }

    public void SetLives(int newLives)
    {
        lives = newLives;
        UpdateLifeDisplay();
    }

}


