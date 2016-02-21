﻿namespace Scripts
{
    using System;
    using UnityEngine;

    public class AnimatedSprites : MonoBehaviour
    {
        //Here you can place the number of columns of your sheet.
        public int uvAnimationTileX = 0;

        //Here you can place the number of rows of your sheet.
        public int uvAnimationTileY = 0;
        public float framesPerSecond = 10.0f;

        public float offsetY = 0.75f;
        public int rowImages = 3;
        
        public void Update()
        {
            //Calculate index.
            int index = (int)(Time.time * framesPerSecond);
            
            //Repeat when exhausting all frames.
            index = index % (rowImages * 1);

            //Size of every tile.
            Vector2 size = new Vector2((1.0f / uvAnimationTileX), (1.0f / uvAnimationTileY));

            //Split into horizontal and vertical index.
            float uIndex = index % uvAnimationTileX;
            //float vIndex = index / uvAnimationTileX;

            //Build offset.
            //Vector2 offset = new Vector2(uIndex * size.x, 1.0f - size.y - vIndex * size.y);
            Vector2 offset = new Vector2(uIndex * size.x, offsetY);

            renderer.material.SetTextureOffset("_MainTex", offset);
            renderer.material.SetTextureScale("_MainTex", size);
        }
    }
}
