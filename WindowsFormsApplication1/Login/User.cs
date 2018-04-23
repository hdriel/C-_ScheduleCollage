namespace ProjectAandB
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    public class User
    {
        // הגדרה של מפתח , בצורה שלא ימולא אוטומטית על ידי השרת שלנו
        private int _UserID; 
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public virtual int ID
        {
            get { return _UserID; }
            set
            {
                if (value != _UserID)
                {
                    _UserID = value;
                }
            }
        }

        // דרך לא נכונה זה להגדיר באופן הבא: 
        // [Key] // יקבל ערכים אוטמטים בסדר עולה, ולא יהיה ניתן לשינוי
        // public int id { get; set; }


        [Required] // אומר שזהו שדה חובה , כלומר לא מאפשר שיהיה בעמודה/בשדה NULL
        [StringLength(25)]
        public virtual string password { get; set; }

        //[EmailAddress]
        public virtual string email { get; set; } = null;
        


        [Required]
        // אפשר להזין רק את אחת מהמחרוזות האלה
        [RegularExpression("Secretary|Admin|Lecturer|Practitioner|StudentCoordinator|Student|Registrar|Grader")]
        public virtual string permission { get; set; }

        // !!!בנאי דיפולטיבי - חובה 
        public User() { password = "0000"; }

        // בנאים אחרים
        public User(int id, string _permission)
        {
            ID = id;
            password = "0000";
            permission = _permission;
        }

        public User(int id, string _password, string _permission, string _email)
        {
            ID = id;
            password = _password;
            permission = _permission;
            email = _email;
        }
    }
}