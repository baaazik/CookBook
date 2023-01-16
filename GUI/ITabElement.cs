using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI
{
    /// <summary>
    /// Интерфейс для возможности сообщить компоненту, что он выбран
    /// </summary>
    internal interface ITabElement
    {
        void Selected();
    }
}
