using Services.Interfaces;
using Domain;
using Microsoft.Extensions.Options;

namespace Services
{
    public class MetadataService : IMetadataService
    {
        private readonly Config _config;

        public MetadataService(IOptions<Config> config)
        {
            _config = config.Value;
        }

        public string GetCodeRepositoryUrl()
        {
            return $"{_config.BaseCodeRepositoryUrl}/{_config.CodeRepositoryUrl}";
        }
    }
}