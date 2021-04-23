using System;

namespace Dominio.Argumentos.Base
{
    public class ArgumentoBase
    {
        public int Id { get; set; }
        public DateTime DataInclusao { get; set; }
        public DateTime DataAlteracao { get; set; }
        public bool? Ativo { get; set; }
    }
}
