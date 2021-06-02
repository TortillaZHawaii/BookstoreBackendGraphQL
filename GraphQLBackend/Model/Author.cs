using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GraphQLBackend.Model
{
    public class Author
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AuthorId { get; set; }

        [Required]
        [MaxLength(60)]
        public string Name { get; set; }

        public virtual ICollection<Book> Books { get; set; } = new List<Book>();

        public override string ToString() => $"Author {AuthorId}: {Name}";
    }
}
