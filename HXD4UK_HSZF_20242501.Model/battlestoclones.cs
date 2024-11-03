using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXD4UK_HSZF_20242501.Model
{
    public class battlestoclones
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; } 
        public ICollection<Battles> Battles { get; set; }

        public ICollection<clones> Clones { get; set; }

        public battlestoclones()
        {
        }
    }
}
