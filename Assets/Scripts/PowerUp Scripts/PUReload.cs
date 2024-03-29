﻿using System.Collections;
using UnityEngine;

public class PUReload : MonoBehaviour
{
    [SerializeField] float reloadMultiplier;
    PlayerController player;
    [SerializeField] Animator[] animators;

    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        reloadMultiplier = 0.1f;
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
            player.timeBetweenShots -= reloadMultiplier;
        }
        else if (PlayerController.howManyPowerUps == 0)
        {
            player.timeBetweenShots -= reloadMultiplier;
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
