using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Models;
using Model.Recipe;

namespace Data
{
    /// <summary>
    /// Преобразует тип единицы измерения из БД (enum) в классы Unit и Amount
    /// </summary>
    internal static class UnitConverter
    {
        public static BaseUnit TypeToUnit(UnitType type)
        {
            switch (type)
            {
                case UnitType.GRAMM:
                    return new Gramm();
                case UnitType.MILLILITER:
                    return new Milliliter();
                case UnitType.PIECE:
                    return new Piece();
                default:
                    throw new ArgumentException();
            }
        }

        public static UnitType StrToType(string str)
        {
            return (UnitType)Enum.Parse(typeof(UnitType), str);
        }

        public static BaseUnit StrToUnit(string str)
        {
            return TypeToUnit(StrToType(str));
        }

        public static UnitType UnitToType(BaseUnit unit)
        {
            // Долбанная рефлексия
            if (unit.GetType() == typeof(Gramm))
                return UnitType.GRAMM;
            if (unit.GetType() == typeof(Milliliter))
                return UnitType.MILLILITER;
            if (unit.GetType() == typeof(Piece))
                return UnitType.PIECE;

            throw new ArgumentException();
        }

        public static string UnitToStr(BaseUnit unit)
        {
            return UnitToType(unit).ToString();
        }
    }

    internal abstract class AmountCreator
    {
        // public 
    }
}
