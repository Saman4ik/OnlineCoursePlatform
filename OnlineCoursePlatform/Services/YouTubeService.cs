using Google.Apis.Services;
using Google.Apis.YouTube.v3.Data;

namespace OnlineCoursePlatform.Services;

public class YouTubeService
{
    private readonly string _apiKey;

    public YouTubeService(string apiKey)
    {
        _apiKey = apiKey;
    }

    public async Task<string> UploadVideoAsync(Stream videoStream, string title, string description)
    {
        var youTubeService = new YouTubeService(new BaseClientService.Initializer()
        {
            ApiKey = _apiKey,
            ApplicationName = GetType().ToString()
        });

        var video = new Google.Apis.YouTube.v3.Data.Video
        {
            Snippet = new VideoSnippet
            {
                Title = title,
                Description = description
            },
            Status = new VideoStatus
            {
                PrivacyStatus = "unlisted"
            }
        };

        var videosInsertRequest = youTubeService.Videos.Insert(video, "snippet,status", videoStream, "video/*");

        await videosInsertRequest.UploadAsync();

        return videosInsertRequest.ResponseBody.Id;
    }
}
