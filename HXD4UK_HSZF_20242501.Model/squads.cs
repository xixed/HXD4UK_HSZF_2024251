using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXD4UK_HSZF_20242501.Model
{
    public class Squads
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set;  }
        public string Name { get; set; }
        public string Commander { get; set; }

        public ICollection<Clones> Clones { get; set; }

        public Squads(int id, string name, string commander)
        {
            Id = id;
            Name = name;
            Commander = commander;

            
        }
        public Squads()
        {
            
        }
    }
}
