using FluentAssertions;
using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using Said.RestApi.Client.Actions;
using Said.RestApi.Client.Models.PetModel;
using System.Net;

namespace Said.RestApi.Tests.Tests.Pets
{
    [TestFixture]
    public class GetPetByIdApiTest : PetApiTestsBase
    {
        [Test]
        public void GetFirstPet_IdExists_ShouldBeReturned()
        {
            // Arrange
            PetApiModelV2 expectedResponse = PetActionsRequests.CreateNewPet(_baseUrl!);

            // Act
            RestResponse response = _petApiRequests!.ExecuteApiGetPetByIdRequest(expectedResponse.Id!.Value);

            // Assert
            response
                .StatusCode
                .Should()
                .Be(HttpStatusCode.OK);
            var responseBody = JsonConvert.DeserializeObject<PetApiModelV2>(response.Content!);
            responseBody.Should().NotBeNull();
            responseBody
                .Should()
                .BeEquivalentTo(expectedResponse);
        }
    }
}