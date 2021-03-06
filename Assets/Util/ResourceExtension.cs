﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ResourceExtension
{
    private const string EffectPathFormat = @"Effect\{0}";
    private const string PlayerAnimationPathFormat = @"PlayerAnimation\{0}";
    private const string AudioClipPathFormat = @"AudioClip\{0}";
    private const string CardSpritePathFormat = @"CardSprite\{0}";

    private const string HeartSpritePathFormat = @"HeartSprite\{0}";

    public static Card.CardFXData LoadCardFXData(string fileName)
    {
        var fxData = new Card.CardFXData(
            LoadEffect(fileName),
            LoadPlayerAnimation(fileName),
            LoadAudioClip(fileName),
            LoadCardSprite(fileName));

        return fxData;
    }

    private static Animation LoadEffect(string fileName)
    {
        var path = string.Format(EffectPathFormat, fileName);
        return Resources.Load<Animation>(path);
    }

    private static Animation LoadPlayerAnimation(string fileName)
    {
        var path = string.Format(PlayerAnimationPathFormat, fileName);
        return Resources.Load<Animation>(path);
    }

    private static AudioClip LoadAudioClip(string fileName)
    {
        var path = string.Format(AudioClipPathFormat, fileName);
        return Resources.Load<AudioClip>(path);
    }

    private static Sprite LoadCardSprite(string fileName)
    {
        var path = string.Format(CardSpritePathFormat, fileName);
        return Resources.Load<Sprite>(path);
    }

    public static Sprite LoadHeartSprite(string fileName)
    {
        var path = string.Format(HeartSpritePathFormat, fileName);
        return Resources.Load<Sprite>(path);
    }
}
