namespace TrainingDiary.Service;

public interface ITrainingDatabase
{
    Task<List<Training>> GetTrainingsAsync();
    Task<Training> GetTrainingAsync(int id);
    Task CreateTrainingAsync(Training raining);
    Task UpdateTrainingAsync(Training raining);
    Task DeleteTrainingAsync(Training raining);
}
