//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProjVendasAula
{
    using System;
    using System.Collections.Generic;
    
    public partial class Venda
    {
        public int Id { get; set; }
        public int IdFornecedor { get; set; }
        public int IdCliente { get; set; }
        public int IdMaterial { get; set; }
        public System.DateTime DataVenda { get; set; }
    
        public virtual Cliente Cliente { get; set; }
        public virtual Fornecedor Fornecedor { get; set; }
        public virtual Material Material { get; set; }
    }
}