﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace DAL_QLBanHang
{
    public class DBConnect
    {
        protected SqlConnection _conn = new SqlConnection(@"Data Source=DESKTOP-KMNS09Q;Initial Catalog=QLyBanHang;Integrated Security=True");
    }
}
