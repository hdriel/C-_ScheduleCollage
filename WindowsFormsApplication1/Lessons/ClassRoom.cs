namespace ProjectAandB
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class ClassRoom
    {
        private string _building;
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column(Order = 0)]
        public string building
        {
            get { return _building; }
            set
            {
                if (value != _building)
                {
                    _building = value;
                }
            }
        }

        private int _number;
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column(Order = 1)]
        public int number
        {
            get { return _number; }
            set
            {
                if (value != _number)
                {
                    _number = value;
                }
            }
        }

        [Required]
        public int maxStudents { get; set; }

        [Required]
        public bool hasProjector { get; set; }

        public string getNameClass()
        {
            return "" + building + number.ToString();
        }
    }
}