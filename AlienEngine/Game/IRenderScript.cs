using System;

namespace AlienEngine.Core.Game
{
    public interface IRenderScript: IDisposable
    {
        void Load();
        
        void BeforeRender();

        void AfterRender();

        void Unload();
    }
}