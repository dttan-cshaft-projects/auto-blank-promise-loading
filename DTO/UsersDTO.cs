using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class UsersDTO
    {
        private int id;
        private string username;
        private string password;
        private string salt;
        private int account_type;
        private string permission;
        private string department;
        private string factory_code;
        private string adModule;
        private string image;
        private string note;
        private string created_by;
        private DateTime created;

        // id
        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        // username
        public string Username
        {
            get
            {
                return username;
            }

            set
            {
                username = value;
            }
        }

        // Password
        public string Password
        {
            get
            {
                return password;
            }

            set
            {
                password = value;
            }
        }

        // salt
        public string Salt
        {
            get
            {
                return salt;
            }

            set
            {
                salt = value;
            }
        }

        // account_type
        public int AccountType
        {
            get
            {
                return account_type;
            }

            set
            {
                account_type = value;
            }
        }

        // permission
        public string Permission
        {
            get
            {
                return permission;
            }

            set
            {
                permission = value;
            }
        }

        // salt
        public string Department
        {
            get
            {
                return department;
            }

            set
            {
                department = value;
            }
        }

        // factory_code
        public string FactoryCode
        {
            get
            {
                return factory_code;
            }

            set
            {
                factory_code = value;
            }
        }

        // adModule
        public string AdModule
        {
            get
            {
                return adModule;
            }

            set
            {
                adModule = value;
            }
        }

        // image
        public string Image
        {
            get
            {
                return image;
            }

            set
            {
                image = value;
            }
        }

        // note
        public string Note
        {
            get
            {
                return note;
            }

            set
            {
                note = value;
            }
        }

        // created_by
        public string CreatedBy
        {
            get
            {
                return created_by;
            }

            set
            {
                created_by = value;
            }
        }

        // created
        public DateTime Created
        {
            get
            {
                return created;
            }

            set
            {
                created = value;
            }
        }

        // constructor
        public UsersDTO()
        {

        }

    }
}
