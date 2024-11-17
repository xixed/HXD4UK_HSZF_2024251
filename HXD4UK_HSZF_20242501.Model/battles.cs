using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXD4UK_HSZF_20242501.Model
{
    public class Battles
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Location { get; set; }

        public string? Date { get; set; }

        public int[] Clones { get; set; }

        public static int Id_Counter { get; set; }

        public virtual ICollection<Battlestoclones> Battlestoclones { get; set; }

        public Battles(int id, string name, string location, string date, int[] clones)
        {
            Id = id;
            Name = name;
            Location = location;
            Date = date;
            Clones = clones;
            Id_Counter++;
        }
        public Battles(string name, string location, string date, int[] clones)
        {
            
            Name = name;
            Location = location;
            Date = date;
            Clones = clones;
            Id_Counter++;
            Id = Id_Counter;


        }

        public Battles()
        {
            Id_Counter++;
            Id = Id_Counter;


        }
        
    }
}
