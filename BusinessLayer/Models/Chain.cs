using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessLayer.Models
{
    [Table("Chain")]
    public class Chain : EditableObject
    {

        public Chain()
        {

        }

        public string Code { get; set; }
        public string Name { get; set; }

        private void test()
        {
            
        }
    }
}
