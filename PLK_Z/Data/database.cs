using PLK_Z.Models;
using SQLite;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace NumbersApi.Data
{
    public class Database
    {
        private readonly SQLiteAsyncConnection DBL;

        public Database(string connectionString)
        {
            DBL = new SQLiteAsyncConnection(connectionString);

            DBL.CreateTableAsync<Note>().Wait();
        }

        public Task<List<Note>> GetNotesAsync()
        {
            return DBL.Table<Note>().ToListAsync();
        }

        public Task<Note> GetNoteAsync(int id)
        {
            return DBL.Table<Note>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public async Task<int> AddNoteAsync(Note note)
        {
            await DBL.InsertAsync(note);

            var client = new HttpClient();
            note.Fact = await client.GetStringAsync($"https://numbersapi.com/{note.ID}");

            return await UpdateNoteAsync(note);
        }

        public Task<int> UpdateNoteAsync(Note note)
        {
            return DBL.UpdateAsync(note);
        }

        public Task<int> DeleteNoteAsync(Note note)
        {
            return DBL.DeleteAsync(note);
        }
    }
}
