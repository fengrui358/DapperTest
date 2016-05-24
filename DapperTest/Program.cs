using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Dapper.FastCrud;
using Dapper.FastCrud.Configuration.StatementOptions.Builders;
using DapperTest.DomainModels;
using MySql.Data.MySqlClient;

namespace DapperTest
{
    class Program
    {
        static void Main(string[] args)
        {
            OrmConfiguration.DefaultDialect = SqlDialect.MySql;

            //创建测试数据库
            using (var con = DbContext.GetConnection(true))
            {
                con.Execute("CREATE DATABASE IF NOT EXISTS `test`;");                
            }

            using (var sqlStream = typeof (Program).Assembly.GetManifestResourceStream("DapperTest.sql.CreateTable.sql")
                )
            {
                using (var streamReader = new StreamReader(sqlStream))
                {
                    var sql = streamReader.ReadToEnd();

                    using (var con = DbContext.GetConnection())
                    {
                        con.Execute(sql);
                    }
                }
            }

            var area = new Area
            {
                AreaName = "测试",
                AreaDes = "测试描述",
                CreateTime = DateTime.Now,
                RowIdentity = Guid.NewGuid(),
                FullName = "全名测试",
                ParentAreaId = 0
            };

            using (var con = DbContext.GetConnection())
            {
                con.Insert(area);
            }


            //删除测试数据库
            using (var con = DbContext.GetConnection())
            {
                con.Execute("DROP DATABASE IF EXISTS `test`;");
            }
        }
    }
}
