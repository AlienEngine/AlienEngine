using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlienEngine
{
    public class ListBox: UIComponent
    {
        private List<Label2D> _lines;

        public ListBox()
        {
            _lines = new List<Label2D>();
        }
    }
}
