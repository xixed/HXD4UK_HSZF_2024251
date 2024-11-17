using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXD4UK_HSZF_20242501.Model
{
    public class Battlestoclones
    {
        public int CloneId { get; set; }
        public virtual Clones? Clone { get; set; }

        public int BattleId { get; set; }

        public virtual Battles? Battle { get; set; }



    }
}
