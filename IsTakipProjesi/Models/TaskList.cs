using System.ComponentModel.DataAnnotations;

namespace IsTakipProjesi.Models
{
    public class TaskList
    {
        [Key]
        public int TaskID { get; set; }
        public string IsAdi { get; set; }
        public string Durum { get; set; }
        public string Aciklama { get; set; }
        public int? CreateUserID { get; set; }
        public DateTime OlusturmaTarihi { get; set; }
        public DateTime BaslangicTarihi { get; set; }
        public DateTime? BitisTarihi { get; set; }  // BitisTarihi null olabilir
        public string? SonDurumDegistiren { get; set; }
        public int? OnemDerecesi { get; set; }  // OnemDerecesi null olabilir
        public bool isDeleted { get; set; }

        public ICollection<TaskMember> TaskMembers { get; set; } = new List<TaskMember>();
        public ICollection<TaskComment> Comments { get; set; } = new List<TaskComment>();
    }
}
