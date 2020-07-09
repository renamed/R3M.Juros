using Microsoft.Extensions.Options;
using Services;
using Services.Interfaces;
using Domain;
using Xunit;

namespace tests
{
    public class CodeMetadataTest
    {
        [Fact]
        public void DeveRetornarRespostaNaoNull()
        {
            var options = Options.Create<Config>(new Config { BaseCodeRepositoryUrl = "Parte_1", CodeRepositoryUrl = "Parte_2" });
            IMetadataService metadataService = new MetadataService(options);

            Assert.NotNull(metadataService.GetCodeRepositoryUrl());
        }

        [Fact]
        public void DeveRetornarUrlMontada()
        {
            var options = Options.Create<Config>(new Config { BaseCodeRepositoryUrl = "Parte_1", CodeRepositoryUrl = "Parte_2" });
            IMetadataService metadataService = new MetadataService(options);

            var response = metadataService.GetCodeRepositoryUrl();

            Assert.Equal("Parte_1/Parte_2", response);
        }
    }
}