using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingDiary.Models;
namespace TrainingDiary.Service;
public class SQLiteTrainingDatabase
{
    private readonly SQLiteAsyncConnection _database;

    public SQLiteTrainingDatabase(string dbPath)
    {
        _database = new SQLiteAsyncConnection(dbPath);
        _database.CreateTableAsync<Training>().Wait();
    }
    public Task<List<Training>> GetTrainingsAsync()
    {
        return _database.Table<Training>().ToListAsync();
    }

    public Task<int> SaveTrainingAsync(Training training)
    {
        if (training.Id != 0)
            return _database.UpdateAsync(training);
        else
            return _database.InsertAsync(training);
    }

    public Task<int> DeleteTrainingAsync(Training training)
    {
        return _database.DeleteAsync(training);
    }

}
