using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI
{
    /// <summary>
    /// Класс, позволяющий всем компонентам программы получить доступ
    /// к одному экземпляру IDataSource.
    /// Реализует паттерн Singleton.
    /// </summary>
    internal class DataSourceProvider
    {
        private static DataSourceProvider _instance;
        private IDataSource _source;

        private DataSourceProvider()
        {
            _source = new FakeData();
        }

        /// <summary>
        /// Возвращает ссылку на себя
        /// </summary>
        public static DataSourceProvider GetInstance()
        {
            if (_instance == null )
            {
                _instance = new DataSourceProvider();
            }
            return _instance;
        }

        /// <summary>
        /// Возвращает источник данных
        /// </summary>
        /// <returns></returns>
        public IDataSource GetSource()
        {
            return _source;
        }
    }
}
