using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace SerialNumber.Components
{
    public class SerialNumberBase
    {
        /// <summary>
        /// Экземпляр класса
        /// </summary>
        private static SerialNumberBase _instance;
        /// <summary>
        /// Порядковый номер
        /// </summary>
        public int SerialNumber { get; private set; }
    
        private static object syncRoot = new Object();
        /// <summary>
        /// Конструктор
        /// </summary>
        private SerialNumberBase()
        {
            SerialNumber = 1;
        }

        /// <summary>
        /// ПОлучаем единственный экземпляр.
        /// </summary>
        /// <returns></returns>
        private static SerialNumberBase GetInst()
        {
            if (_instance == null)
            {
                lock (syncRoot)
                {
                    if (_instance == null)
                        _instance = new SerialNumberBase();
                }
            }
            return _instance;
        }

        /// <summary>
        /// задает начальный номер
        /// </summary>
        /// <param name="startNumber"></param>
        public static void SetStartNumber(int startNumber)
        {
            var inst = GetInst();
           inst.SerialNumber = startNumber;
        }

        /// <summary>
        /// Получает текущий порядковый номер. Делает инкримент порядкового номера
        /// </summary>
        /// <returns>Текущий порядковы й нмоер</returns>
        public static int GetNumber()
        {
            var inst = GetInst();
            var result = inst.SerialNumber;
            inst.SerialNumber++;
            return result;
        }
    }
}
