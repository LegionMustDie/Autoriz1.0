//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace zadanie1.FolderData
{
    using System;
    using System.Collections.Generic;
    
    public partial class Invoice
    {
        public int IdInvoice { get; set; }
        public int IdContract { get; set; }
        public decimal Sum { get; set; }
    
        public virtual IdContract IdContract1 { get; set; }
    }
}
