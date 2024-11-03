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
        public int CloneId { get; set; }
        public clones clones { get; set; }

        public int BattleId { get; set; }

        public Battles battles { get; set; }


        
    }
}
