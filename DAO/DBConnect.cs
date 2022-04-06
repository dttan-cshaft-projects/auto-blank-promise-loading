using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace DAO
{
    public class DBConnect
    {

        // 147.121.55.227 (AU_AVERY)
        protected MySqlConnection _conn = new MySqlConnection("server=147.121.56.227;user=planning;pwd=PELS&Auto@{2020};database=au_avery;Connect Timeout=10000;charset=utf8;convertzerodatetime=true;");

        // 147.121.73.3 (AVERY)
        protected MySqlConnection _connMain = new MySqlConnection("server=147.121.56.227;user=planning;pwd=PELS&Auto@{2020};database=au_avery;Connect Timeout=10000;charset=utf8;convertzerodatetime=true;");

    }
}