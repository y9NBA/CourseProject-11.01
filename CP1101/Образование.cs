//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CP1101
{
    using System;
    using System.Collections.Generic;
    
    public partial class Образование
    {
        public int id { get; set; }
        public int id_сотрудника { get; set; }
        public string Учебное_заведение { get; set; }
        public string Специальность { get; set; }
        public Nullable<System.DateTime> Дата_окончания { get; set; }
        public string Квалификация { get; set; }
    
        public virtual Сотрудники Сотрудники { get; set; }
    }
}
