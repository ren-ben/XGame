﻿using System.Collections;
using UnityEngine;

public class PULight : MonoBehaviour
{
    [SerializeField] float LightIntensityMultiplier;
    PlayerController player;
    LightMultiplier lightMultiplier;
    [SerializeField] Animator[] animators;

    void Start()
    {
        lightMultiplier = FindObjectOfType<LightMultiplier>();
        player = FindObjectOfType<PlayerController>();
        LightIntensityMultiplier = 0.1f;
        if (gameObject.activeSelf)
        {
            player.canPowerUp = true;
        }
    }

    public void Click()
    {
        if (PlayerController.howManyPowerUps > 0)
        {
            PlayerController.howManyPowerUps--;
            lightMultiplier.globalLight.intensity += LightIntensityMultiplier;
        }
        else if (PlayerController.howManyPowerUps == 0)
        {
            lightMultiplier.globalLight.intensity += LightIntensityMultiplier;
            StartCoroutine(AnimatorOut());
        }
    }


    IEnumerator AnimatorOut()
    {
        foreach (Animator anim in animators)
        {
            anim.SetBool("anim", false);
        }
        player.canPowerUp = false;
        yield return null;
    }
}
