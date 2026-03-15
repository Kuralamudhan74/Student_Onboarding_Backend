using System.Net.Http.Headers;
using System.Net.Http.Json;
using StudentOnboardingApp.Models.Common;
using StudentOnboardingApp.Models.Profile;
using StudentOnboardingApp.Services.Interfaces;

namespace StudentOnboardingApp.Services.Implementations;

public class ProfileService : IProfileService
{
    private readonly HttpClient _client;

    public ProfileService(IHttpClientFactory httpClientFactory)
    {
        _client = httpClientFactory.CreateClient(Constants.AuthenticatedApiClient);
    }

    public async Task<ApiResponse<StudentProfileDto>> GetProfileAsync()
    {
        try
        {
            var response = await _client.GetAsync("profile");
            var result = await response.Content.ReadFromJsonAsync<ApiResponse<StudentProfileDto>>();
            return result ?? new ApiResponse<StudentProfileDto> { Success = false, Message = "Failed to parse response" };
        }
        catch (Exception ex)
        {
            return new ApiResponse<StudentProfileDto> { Success = false, Message = ex.Message };
        }
    }

    public async Task<ApiResponse<string>> UpdateProfileAsync(UpdateProfileRequest request)
    {
        try
        {
            var response = await _client.PutAsJsonAsync("profile", request);
            var result = await response.Content.ReadFromJsonAsync<ApiResponse<string>>();
            return result ?? new ApiResponse<string> { Success = false, Message = "Failed to parse response" };
        }
        catch (Exception ex)
        {
            return new ApiResponse<string> { Success = false, Message = ex.Message };
        }
    }

    public async Task<ApiResponse<string>> UploadPhotoAsync(Stream photoStream, string fileName)
    {
        try
        {
            using var content = new MultipartFormDataContent();
            var streamContent = new StreamContent(photoStream);
            streamContent.Headers.ContentType = new MediaTypeHeaderValue("image/jpeg");
            content.Add(streamContent, "photo", fileName);

            var response = await _client.PostAsync("profile/photo", content);
            var result = await response.Content.ReadFromJsonAsync<ApiResponse<string>>();
            return result ?? new ApiResponse<string> { Success = false, Message = "Failed to parse response" };
        }
        catch (Exception ex)
        {
            return new ApiResponse<string> { Success = false, Message = ex.Message };
        }
    }

    public async Task<ApiResponse<string>> UploadDocumentAsync(Stream docStream, string fileName, string documentType)
    {
        try
        {
            using var content = new MultipartFormDataContent();
            var streamContent = new StreamContent(docStream);
            streamContent.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
            content.Add(streamContent, "document", fileName);
            content.Add(new StringContent(documentType), "documentType");

            var response = await _client.PostAsync("profile/document", content);
            var result = await response.Content.ReadFromJsonAsync<ApiResponse<string>>();
            return result ?? new ApiResponse<string> { Success = false, Message = "Failed to parse response" };
        }
        catch (Exception ex)
        {
            return new ApiResponse<string> { Success = false, Message = ex.Message };
        }
    }
}
