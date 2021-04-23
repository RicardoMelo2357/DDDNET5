using prmToolkit.NotificationPattern;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.Entidades.Base
{
    public class EntidadeBase : Notifiable
    {
        public EntidadeBase()
        {
            Ativo = true;
        }
        
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime DataInclusao { get; set; }
        public DateTime? DataAlteracao { get; set; }
        public bool? Ativo { get; set; }
    }
}
