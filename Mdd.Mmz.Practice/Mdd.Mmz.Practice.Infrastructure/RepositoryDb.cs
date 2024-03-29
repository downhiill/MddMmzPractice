﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Linq;


using Microsoft.Data.Sqlite;

using Mdd.Mmz.Practice.Core;

namespace Mdd.Mmz.Practice.Infrastructure
{
    public class RepositoryDb : IRepository
    {
        private static readonly string fileName = "Db.db";
        private readonly string connectionString = "DataSource=" + fileName; 
        private static readonly string tableName = "person";
        private string error1 = "SQLite Error 1: 'no such table: " + tableName + "'.";

        private readonly RepositoryDbSql sql = new RepositoryDbSql();
        
        public List<Person> Get()
        {
            var data = new List<Person>();

            try
            {
                var connection = new SqliteConnection(connectionString);

                connection.Open();

                
                var command = new SqliteCommand(sql.Select(), connection);

                var reader = command.ExecuteReader();


                var dataTable = new DataTable();
                dataTable.Load(reader);

                data = dataTable.AsEnumerable()
                    .Select(row =>
                        new Person
                        {
                            Id = Convert.ToInt32(row[0]),
                            Score = Convert.ToInt32(row[1]),
                            NameEvents = Convert.ToString(row[2]),
                            Status = Convert.ToString(row[3]),
                            CountryAndCity = Convert.ToString(row[4])
                        }
                    )
                    .ToList()
                ;

                return data;
                
            }
            catch (Exception e)
            {
                if (e.Message == error1)
                {
                    try
                    {
                        CreateTable();
                        return data;
                        
                    }
                    catch 
                    {
                        throw;
                    }
                }
                else
                {
                    throw;
                }
            }
        }

        public Person Get(int personId)
        {
            var data = new Person();

            var connection = new SqliteConnection(connectionString);

            try
            {

                connection.Open();

                var command = new SqliteCommand(sql.Select(personId), connection);

                var reader = command.ExecuteReader();


                if (reader.HasRows)
                {
                    reader.Read();
                    data.Id = reader.GetInt32(0);
                    data.Score = reader.GetInt32(1);
                    data.NameEvents = reader.GetString(2);
                    data.Status = reader.GetString(3);
                    data.CountryAndCity = reader.GetString(4);

                }


                return data;

            }
            catch (Exception e)
            {
                if (e.Message == error1)
                {
                    try
                    {
                        CreateTable();
                        return data;

                    }
                    catch
                    {
                        throw;
                    }
                }
                else
                {
                    throw;
                }
            }
            finally
            {
                connection.Close();
            }

        }

        public void Save(Person person)
        {
            var connection = new SqliteConnection(connectionString);

            try
            {

                connection.Open();


                var command = new SqliteCommand(person.Id == null ? sql.Insert(person) : sql.Update(person), connection);

                command.ExecuteNonQuery();


            }
            catch (Exception e)
            {
                if (e.Message == error1)
                {
                    try
                    {
                        CreateTable();
                        Save(person);

                    }
                    catch
                    {
                        throw;
                    }
                }
                else
                {
                    throw;
                }
            }
            finally
            {
                connection.Close();
            }


        }

        public void Delete(Person person)
        {
            var connection = new SqliteConnection(connectionString);

            try
            {
                connection.Open();

                var command = new SqliteCommand(sql.Delete(person), connection);

                command.ExecuteNonQuery();

            }
            catch
            {
                throw;
            }
            finally
            {
                connection.Close();
            }


        }

        private void CreateTable()
        {
            var connection = new SqliteConnection(connectionString);

            try
            {
                connection.Open();

                var command = new SqliteCommand(sql.CreateTable(), connection);

                command.ExecuteNonQuery();

            }
            catch 
            {
                throw;
            }
            finally
            {
                connection.Close();
            }



        }


    }
}
