using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Recipe
{
    /// <summary>
    /// Базовый класс единицы измерения количества ингредиентов.
    /// Этот класс описывает количество ингредиента. Он используется, потому
    /// что количество ингредиента определяется не только численным параметром,
    /// но и единицей измерения (граммы, штуки и т.п.)
    /// </summary>
    public abstract class BaseUnit
    {
        /// <summary>
        /// Название единицы измерения
        /// </summary>
        public abstract string Name { get; }

        /// <summary>
        /// Пересчитывает количество игредиента при изменении объема готового блюда
        /// </summary>
        /// <param name="amount">Исходное количество</param>
        /// <param name="gain">Коэффициент изменения (0; +inf)</param>
        /// <returns></returns>
        public abstract int ChangeAmount(uint amount, double gain);
    }

    /// <summary>
    /// Граммы
    /// </summary>
    public class Gramm : BaseUnit
    {
        public override string Name => "г.";

        public override int ChangeAmount(uint amount, double gain)
        {
            if (gain <= 0)
            {
                throw new ArgumentException();
            }
            return (int)(amount * gain);
        }
    }

    /// <summary>
    /// Миллилитр
    /// </summary>
    public class Milliliter : BaseUnit
    {
        public override string Name => "мл.";

        public override int ChangeAmount(uint amount, double gain)
        {
            if (gain <= 0)
            {
                throw new ArgumentException();
            }
            return (int)(amount * gain);
        }
    }

    /// <summary>
    /// Штука
    /// </summary>
    public class Piece : BaseUnit
    {
        public override string Name => "шт.";

        public override int ChangeAmount(uint amount, double gain)
        {
            if (gain <= 0)
            {
                throw new ArgumentException();
            }
            return (int)Math.Ceiling(amount * gain);
        }
    }
}
