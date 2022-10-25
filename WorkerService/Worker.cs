namespace WorkerService
{
    using RestSharp;
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly RestClient _client = new RestClient("http://webapi");

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var request = new RestRequest("status", Method.GET);
                var response = await _client.ExecuteAsync(request);
                _logger.LogInformation($"RESPONSE: {response.StatusCode}, {response.Content}");
                _logger.LogInformation($"ContentType: {response.ContentType}, ContentLength: {response.ContentLength}");
                _logger.LogInformation($"Exception: {response.ErrorException}, {response.ErrorMessage}");
                _logger.LogInformation($"Headers: {response.Headers}, Is Successful: {response.IsSuccessful}");
                _logger.LogInformation($"Satatus: {response.ResponseStatus}, {response.StatusDescription}");
                _logger.LogInformation($"ToString: {response.ToString()}");
                
                await Task.Delay(500, stoppingToken);
            }
        }
    }
}