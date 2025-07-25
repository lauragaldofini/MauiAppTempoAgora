﻿﻿using MauiAppTempoSQLite.Models;
using SQLite;

namespace MauiAppTempoSQLite.Helpers
{
    public class SQLiteDatabaseHelper
    {
        readonly SQLiteDatabaseHelper _conn;

        public SQLiteDatabaseHelper(string path)
        {
            _conn = new SQLiteDatabaseHelper(path);
            _conn.CreateTable<Tempo>().Wait();
        }

        public Task<int> Insert(Tempo p)
        {
            return _conn.InsertAsync(p);
        }

        public Task<int> Delete(int id)
        {
            return _conn.Table<Tempo>().DeleteAsync(i => i.Id == id);
        }

        public Task<List<Tempo>> GetAll()
        {
            return _conn.Table<Tempo>().ToListAsync();
        }

        public Task<List<Tempo>> Search(string q)
        {
            string sql = "SELECT * FROM Tempo " +
                         "WHERE description LIKE '%" + q + "%'";

            return _conn.QueryAsync<Tempo>(sql);
        }
    } // Fecha classe SQLiteDatabaseHelper
}