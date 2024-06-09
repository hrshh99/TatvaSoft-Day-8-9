using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Data_Access_Layer.Repository.Entities
{
    [Table("MissionSkill")] 
    public class MissionSkill : BaseEntity
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("skill_name")]
        public string SkillName { get; set; }

        [Column("status")]
        public string Status { get; set; }
    }
}
