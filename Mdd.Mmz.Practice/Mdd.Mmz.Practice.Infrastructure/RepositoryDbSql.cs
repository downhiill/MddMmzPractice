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
                "SELECT id, score, nameEvents, status, countryAndCity " +
                "FROM " + tableName
            ;

            return sql;

        }

        public string Select(int personId)
        {
            var sql =
                "SELECT id, score, nameEvents, status, countryAndCity" +
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
                    " score," +
                    " nameEvents," +
                    " status," +
                    " countryAndCity" +
                ")" +
                "VALUES" +
                "(" +
                    "(SELECT coalesce(max(id), 0) + 1 FROM " + tableName + ")," +
                    " " + person.Score + "," +
                    " '" + person.NameEvents + "'," +
                    " '" + person.Status + "'," +
                    " '" + person.CountryAndCity + "'" +
                ")"
            ;

            return sql;

        }

        public string Update(Person person)
        {
            var sql =
                "UPDATE " + tableName +
                " SET" +
                    " score = " + person.Score + "," +
                    " nameEvents = '" + person.NameEvents + "'," +
                    " status = '" + person.Status + "'," +
                    " countryAndCity = '" + person.CountryAndCity + "'" +
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
                    "Score INTEGER," +
                    "NameEvents TEXT," +
                    "Status TEXT," +
                    "CountryAndCity TEXT" +
                ")"
            ;

            return sql;
        }

    }

}
