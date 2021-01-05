using System;
using System.Collections.Generic;

#nullable disable

namespace APIgerir.Dominios
{
    public partial class Tarefa
    {
        public Guid IdTarefa { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Categoria { get; set; }
        public DateTime? DataEntrega { get; set; }
        public bool? Status { get; set; }
        public Guid? IdUsuario { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
