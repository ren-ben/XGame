﻿using System.Collections;
using UnityEngine;

public class PUWalk : MonoBehaviour
{
    [SerializeField] float walkMultiplier;
    PlayerController player;
    [SerializeField] Animator[] animators;

    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        walkMultiplier = 1f;
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
            player.moveSpeed += walkMultiplier;
        }
        else if (PlayerController.howManyPowerUps == 0)
        {
            player.moveSpeed += walkMultiplier;
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
