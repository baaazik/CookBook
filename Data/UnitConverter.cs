using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Model;

namespace Data
{
    /// <summary>
    /// Преобразует тип единицы измерения из БД (enum) в дочерние классы BaseUnit
    /// </summary>
    internal static class UnitConverter
    {
        const string GRAMM = "gramm";
        const string MILLILITER = "milliliter";
        const string PIECE = "piece";

        public static BaseUnit StrToType(string type)
        {
            switch (type)
            {
                case GRAMM:
                    return new Gramm();
                case MILLILITER:
                    return new Milliliter();
                case PIECE:
                    return new Piece();
                default:
                    throw new ArgumentException();
            }
        }

        public static string TypeToStr(BaseUnit unit)
        {
            // Долбанная рефлексия
            if (unit.GetType() == typeof(Gramm))
                return GRAMM;
            if (unit.GetType() == typeof(Milliliter))
                return MILLILITER;
            if (unit.GetType() == typeof(Piece))
                return PIECE;

            throw new ArgumentException();
        }
    }
}
