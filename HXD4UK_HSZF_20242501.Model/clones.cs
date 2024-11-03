using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HXD4UK_HSZF_20242501.Model
{
    public class clones
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Designation { get; set; }

        public string Rank { get; set; }

        public int Squad_id { get; set;}

        public squads Squad { get; set; }
        
        public ICollection<battlestoclones> Battles { get; set; }

        public clones(int id, string name, string designation, string rank, int squad_Id)
        {
            Id = id;
            Name = name;
            Designation = designation;
            Rank = rank;
            Squad_id = squad_Id;
        }
        public clones()
        { }
    }
}
