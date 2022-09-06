using System.ComponentModel.DataAnnotations;

namespace Store.Models
{
    public class Animal
    {
        public int? AnimalId { get; set; }
        [StringLength (8) ]
        public string? Name { get; set; }
      [Range(0, 10)]
        public int? Age { get; set; }
        public string? PictureSrc { get; set; }
        [StringLength(200)]

        public string? Description { get; set; }
        public int? CategoryId { get; set; }

        public ICollection<Comment>? Comments { get; set; }

        public Category? Categories { get; set; }



    }
}
