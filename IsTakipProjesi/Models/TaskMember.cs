using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IsTakipProjesi.Models
{
    public class TaskMember
    {
        [Key]
        public int TaskMemberID { get; set; }
        public int TaskID { get; set; }
        public int UserID { get; set; }
        public bool OnayDurum { get; set; }
        public bool IsDeleted { get; set; }

        [ForeignKey("TaskID")]
        public TaskList TaskList { get; set; }

    }
}
