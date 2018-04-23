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
    public class CollectiveMessage
    {
        private string _title;
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        public string title
        {
            get { return _title; }
            set { if(value != _title)  _title = value; }
        }

        [Required]
        public string senderName { get; set; }

        [Required]
        public string text { get; set; }

    }
}
