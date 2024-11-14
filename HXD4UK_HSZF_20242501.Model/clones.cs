using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HXD4UK_HSZF_20242501.Model
{
    public class Clones
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Designation { get; set; }

        public string Rank { get; set; }

        public int Squad_id { get; set;}

        public Squads Squad { get; set; }

        public static int Id_counter { get; set; }
        
        public ICollection<Battlestoclones> Battles { get; set; }

        public Clones(int id, string name, string designation, string rank, int squad_Id)
        {
            Id = id;
            Name = name;
            Designation = designation;
            Rank = rank;
            Squad_id = squad_Id;
            Id_counter++;
        }
        public Clones( string name, string designation, string rank, int squad_Id)
        {
            
            Name = name;
            Designation = designation;
            Rank = rank;
            Squad_id = squad_Id;
            Id_counter++;
            Id = Id_counter;
        }

        public Clones()
        {
            Id_counter++;
            Id = Id_counter;
        }
    }
}
