namespace TrainingDiary.Service;

internal class ITrainingDatabase
{
    Task<List<Training>> GetTrainingssAsync();
    Task<Training> GetTrainingAsync(int id);
    Task CreateTrainingAsync(Training raining);
    Task UpdateTrainingAsync(Training raining);
    Task DeleteTrainingAsync(Training raining);
}
