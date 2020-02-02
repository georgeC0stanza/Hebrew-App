using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HebNavi
{
    public class HebrewDatabase
    {
        readonly SQLiteAsyncConnection database;

        public HebrewDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<AlphabetTable>().Wait();
        }

        public Task<List<AlphabetTable>> GetItemsAsync()
        {
            return database.Table<AlphabetTable>().ToListAsync();
        }

        public Task<List<AlphabetTable>> GetItemsNotDoneAsync()
        {
            return database.QueryAsync<AlphabetTable>("SELECT * FROM [TodoItem] WHERE [Done] = 0");
        }

        public Task<AlphabetTable> GetItemAsync(int id)
        {
            return database.Table<AlphabetTable>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(AlphabetTable item)
        {
            if (item.ID != 0)
            {
                return database.UpdateAsync(item);
            }
            else
            {
                return database.InsertAsync(item);
            }
        }

        public Task<int> DeleteItemAsync(AlphabetTable item)
        {
            return database.DeleteAsync(item);
        }
    }
}
