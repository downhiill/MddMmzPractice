using Mdd.Mmz.Practice.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mdd.Mmz.Practice.Infrastructure
{
    internal class RepositoryDbSql
    {
        private readonly string tableName = "person";

        public string Select()
        { 
            var sql = 
                "SELECT id, age, phone, name, city, country " +
                "FROM " + tableName
            ;

            return sql;

        }

        public string Select(int personId)
        {
            var sql = 
                "SELECT id, age, phone, name, city, country" +
                " FROM " + tableName +
                " WHERE id = " + personId.ToString()
            ;

            return sql;

        }

        public string Insert(Person person)
        {
            var sql =
                "INSERT INTO " + tableName +
                "(" +
                    "id," +
                    " age," +
                    " phone," +
                    " name," +
                    " city," +
                    " country" +
                ")" +
                "VALUES" +
                "(" +
                    "(SELECT coalesce(max(id), 0) + 1 FROM " + tableName + ")," +
                    " " + person.Age + "," +
                    " " + person.Phone + "," +
                    " '" + person.Name + "'," +
                    " '" + person.City + "'," +
                    " '" + person.Country + "'" +
                ")"
            ;

            return sql;

        }

        public string Update(Person person)
        {
            var sql =
                "UPDATE " + tableName +
                " SET" +
                    " age = " + person.Age + "," +
                    " ,phone = " + person.Phone + "," +
                    " name = '" + person.Name + "'," +
                    " city = '" + person.City + "'," +
                    " country = '" + person.Country + "'" +
                " WHERE " +
                    "id = " + person.Id
            ;

            return sql;

        }

        public string Delete(Person person)
        {
            var sql = 
                "DELETE FROM " + tableName + 
                " WHERE id = " + person.Id
            ;

            return sql;

        }
        public string CreateTable()
        {
            var sql = "CREATE TABLE " + tableName + 
                " (" +
                    "Id INTEGER PRIMARY KEY," +
                    "Age INTEGER," +
                    "Phone INTEGER," +
                    "Name TEXT," +
                    "City TEXT," +
                    "Country TEXT" +
                ")"
            ;

            return sql;
        }

    }

}
