using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP1101 {
    public class Database {
        public static Entities Instance { get; set; } = new Entities();

        public static void save() {
            Instance.SaveChanges();
        }

        public static List<string> getAllNameTables() {
            return new List<string> { 
                "График работы", 
                "Должности", 
                "Заработная плата", 
                "История работы",
                "Контакты",
                "Навыки",
                "Образование",
                "Отделы",
                "Пользователи",
                "Сертификаты",
                "Сотрудники"
            };
        }
    }
}
