using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Command.Abstract
{
    /// <summary>
    /// Интерфейс выполнения команды
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ICommandHandler<T>
    {
        void Execute(T command);
    }
}
