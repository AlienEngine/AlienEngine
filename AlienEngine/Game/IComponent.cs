using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlienEngine
{
    internal interface IComponent
    {
        void Start();

        void BeforeUpdate();

        void Update();

        void AfterUpdate();

        void Stop();
    }
}
