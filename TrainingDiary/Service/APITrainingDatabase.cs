using TrainingDiary.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingDiary.Service
{
    public class APITrainingDatabase
    {
        private readonly SQLiteAsyncConnection _database;

        HttpClient client;
        JsonSerializerOptions serializerOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };
        string localhost = DeviceInfo.Platform == DevicePlatform.Android ? "10.0.2.2" : "localhost";
        Uri uri;


        public APITrainingDatabase()
        {
            uri = new Uri($"http://{localhost}:5247/training");
            client = new HttpClient();
        }
        public async Task<List<Training>> GetTrainingsAsync()
        {
            List<Training> trainingList = new List<Training>();
            try
            {
                HttpResponseMessage response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    trainingList = JsonSerializer.Deserialize<List<Training>>(content, serializerOptions);
                }
            }
            catch (Exception ex)
            {
                WeakReferenceMessenger.Default.Send("Error getting trainings: " + ex.Message);
            }

            return trainingList;
        }

        public async Task<Training> GetTrainingAsync(int id)
        {
            Training training = null;
            try
            {
                HttpResponseMessage response = await client.GetAsync(uri + "/" + id);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    training = JsonSerializer.Deserialize<Training>(content, serializerOptions);
                }
                else
                {
                    WeakReferenceMessenger.Default.Send("Error getting training, ID: " + id);
                }
            }
            catch (Exception ex)
            {
                WeakReferenceMessenger.Default.Send("Error getting training: " + ex.Message);
            }

            return training;
        }

        public async Task CreateTrainingAsync(Training training)
        {
            try
            {
                string json = JsonSerializer.Serialize(training, serializerOptions);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(uri, content);

                if (response.IsSuccessStatusCode)
                {
                    string s = await response.Content.ReadAsStringAsync();
                    int newid = JsonSerializer.Deserialize<int>(s, serializerOptions);
                    training.Id = newid;
                }
                else
                {
                    WeakReferenceMessenger.Default.Send("Error saving training");
                }

            }
            catch (Exception ex)
            {
                WeakReferenceMessenger.Default.Send("Error saving training: " + ex.Message);
            }
        }

        public async Task UpdateTrainingAsync(Training training)
        {
            try
            {
                string json = JsonSerializer.Serialize(training, serializerOptions);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PutAsync(uri, content);

                if (!response.IsSuccessStatusCode)
                {
                    WeakReferenceMessenger.Default.Send("Error saving training");
                }

            }
            catch (Exception ex)
            {
                WeakReferenceMessenger.Default.Send("Error saving training: " + ex.Message);
            }
        }

        public async Task DeleteTrainingAsync(Training training)
        {
            try
            {
                HttpResponseMessage response = await client.DeleteAsync(uri + "/" + training.Id);
                if (!response.IsSuccessStatusCode)
                {
                    WeakReferenceMessenger.Default.Send("Error deleting training");
                }

            }
            catch (Exception ex)
            {
                WeakReferenceMessenger.Default.Send("Error deleting training: " + ex.Message);
            }
        }

    }
}
