using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CMStool.data.Entity
{
    [Table("AIData_table")] // Specify the table name
    public class AI_Data
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Auto-generated primary key
        public int Id { get; set; }

        [Column("Title")] // Specify column name
        public string Title { get; set; }

        [Column("Content")] // Specify column name
        public string Content { get; set; }

        [Column("CreatedAt")] // Specify column name
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Column("ImageCreated")] // Specify column name
        public string ImageCreated { get; set; } = "NO";
    }
}
