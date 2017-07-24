using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlienEngine.Core.Game
{
    public class Scene
    {
        public GameElement[] GameElements
        {
            get { return new GameElement[0]; }
        }

        public GameElement[] Lights
        {
            get
            {
                List<GameElement> collection = new List<GameElement>();

                foreach (var element in GameElements)
                    if (element.HasComponent<Light>()) collection.Add(element);

                return collection.ToArray();
            }
        }

        public GameElement[] Cameras
        {
            get
            {
                List<GameElement> collection = new List<GameElement>();

                foreach (var element in GameElements)
                    if (element.HasComponent<Camera>()) collection.Add(element);

                return collection.ToArray();
            }
        }
    }
}
