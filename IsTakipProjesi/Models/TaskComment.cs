using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IsTakipProjesi.Models
{
    public class TaskComment
    {
        [Key]
        public int TaskCommentID { get; set; }
        public int TaskID { get; set; }
        public int UserID { get; set; }
        public string Comment { get; set; }
        public DateTime Datetime { get; set; }
        public bool IsDeleted { get; set; }

        [ForeignKey("TaskID")]
        public TaskList TaskList { get; set; }

        [ForeignKey("UserID")]
        public User User { get; set; }
    }
}
