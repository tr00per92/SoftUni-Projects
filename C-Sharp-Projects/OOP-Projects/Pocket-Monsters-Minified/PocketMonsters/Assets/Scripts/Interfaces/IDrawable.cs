namespace Interfaces
{
    using System;
    using System.Collections.Generic;

    public interface IDrawable
    {
        void Draw(float posX, float posY, float posZ, string prefabPath);
    }
}
