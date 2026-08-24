namespace StoryAPI.Services
{
    public class FibonacciEstimacion : EstimacionBase
    {
        protected override async Task<int> ObtenerValorAsync()
        {
            using var client = new HttpClient();
            var response = await client.GetAsync($"http://localhost:5188/fibonacci/{new Random().Next(1, 10)}");
            return response.IsSuccessStatusCode
                ? int.Parse(await response.Content.ReadAsStringAsync())
                : 0;
        }
    }
}