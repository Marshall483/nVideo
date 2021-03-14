using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Locating
{
    /// <summary>
    /// Определение геолокации
    /// </summary>
    public interface IDetector
    {
        /// <summary>
        /// Асинхронный метод определение геолокации
        /// </summary>
        /// <returns>Город</returns>
        public Task<string> GetyCityAsync();
    }
}
