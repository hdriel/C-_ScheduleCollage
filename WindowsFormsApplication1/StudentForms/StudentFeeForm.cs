using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectAandB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    public class StudentFeeForm
    {
        private int _StudentID;
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column(Order = 0)]
        public int ID
        {
            get { return _StudentID; }
            set
            {
                if (value != _StudentID)
                {
                    _StudentID = value;
                }
            }
        }

        public float? anualFee { get; set; }

        public DateTime ValidationDate { get; set; }

        public DateTime FormCreateDate { get; set; }

    }
}
