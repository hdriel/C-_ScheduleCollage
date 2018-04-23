namespace ProjectAandB
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    public class User
    {
        // ����� �� ���� , ����� ��� ����� �������� �� ��� ���� ����
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

        // ��� �� ����� �� ������ ����� ���: 
        // [Key] // ���� ����� ������� ���� ����, ��� ���� ���� ������
        // public int id { get; set; }


        [Required] // ���� ���� ��� ���� , ����� �� ����� ����� ������/���� NULL
        [StringLength(25)]
        public virtual string password { get; set; }

        //[EmailAddress]
        public virtual string email { get; set; } = null;
        


        [Required]
        // ���� ����� �� �� ��� ��������� ����
        [RegularExpression("Secretary|Admin|Lecturer|Practitioner|StudentCoordinator|Student|Registrar|Grader")]
        public virtual string permission { get; set; }

        // !!!���� ��������� - ���� 
        public User() { password = "0000"; }

        // ����� �����
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