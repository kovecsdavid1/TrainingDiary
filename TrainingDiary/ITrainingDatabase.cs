namespace TrainingDiary;

internal class ITrainingDatabase
{
    Task<List<Pet>> GetPetsAsync();
    Task<Pet> GetPetAsync(int id);
    Task CreatePetAsync(Pet pet);
    Task UpdatePetAsync(Pet pet);
    Task DeletePetAsync(Pet pet);

}
