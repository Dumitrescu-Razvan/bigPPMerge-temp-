using Server.DTOs;
using Server.Models;
using UBB_SE_2024_Gaborment.Server.Models;

namespace Server.Utils
{
    public class BaseToDTOConverters
    {
        public static UserDTO Converter_UserToDTO(RetardedUser user) => new UserDTO { Id = user.Id, Username = user.Username, ProfilePicturePath = user.ProfilePicturePath };
        public static MediaDTO Converter_MediaToDTO(Media media) => new MediaDTO { Id = media.Id, FilePath = media.FilePath };
        public static LocationDTO Converter_LocationToDTO(Location location) => new LocationDTO { Id = location.Id, Name = location.Name, Latitude = location.Latitude, Longitude = location.Longitude };

        public static PostArchivedDTO Converter_PostArchivedToDTO(PostArchived postArchived) => new PostArchivedDTO { post_id = postArchived.post_id, archive_id = postArchived.archive_id };
        public static PostSavedDTO Converter_PostSavedToDTO(PostSaved postSaved) => new PostSavedDTO { save_id = postSaved.save_id, post_id = postSaved.post_id, user_id = postSaved.user_id };

        public static PostDTO Converter_PostToDTO(Post post) => new PostDTO { Post_Id = post.Post_Id, Owner_User_Id = post.Owner_User_Id, Description = post.Description, Commented_Post_Id = post.Commented_Post_Id, Original_Post_Id = post.Original_Post_Id, Media_Path = post.Media_Path, Post_Type = post.Post_Type, Location_Id = post.Location_Id, Created_Date = post.Created_Date };

        public static PostReported Converter_PostReportedDTO(PostReportedDTO postReportedDTO) => new PostReported { Report_Id = postReportedDTO.Report_Id, Reason = postReportedDTO.Reason, Description = postReportedDTO.Description, Post_Id = postReportedDTO.Post_Id, Reporter_Id = postReportedDTO.Reporter_Id };
        public static BlockDTO Converter_BlockToDTO(Block block) => new BlockDTO { Id = block.Id, sender = block.sender, receiver = block.receiver, startingTimeStamp = block.startingTimeStamp, reason = block.reason };
        public static FollowDTO Converter_FollowToDTO(Follow follow) => new FollowDTO { Id = follow.Id, sender = follow.sender, receiver = follow.receiver, isCloseFriend = follow.isCloseFriend, expirationTimeStamp = follow.expirationTimeStamp, description = follow.description };
        public static FeedConfigurationDTO Converter_FeedConfigurationToDTO(FeedConfiguration feedConfiguration) => new FeedConfigurationDTO { ID = feedConfiguration.ID, Name = feedConfiguration.Name, ReactionThreshold = feedConfiguration.ReactionThreshold };

        public static ControversialFeedDTO Converter_ControversialFeedToDTO(ControversialFeed controversialFeed) => new ControversialFeedDTO { ID = controversialFeed.ID, Name = controversialFeed.Name, ReactionThreshold = controversialFeed.ReactionThreshold, MinimumReactionCount = controversialFeed.MinimumReactionCount, MinimumCommentCount = controversialFeed.MinimumCommentCount };
        public static TrendingFeedDTO Converter_TrendingFeedToDTO(TrendingFeed trendingFeed) => new TrendingFeedDTO { ID = trendingFeed.ID, Name = trendingFeed.Name, ReactionThreshold = trendingFeed.ReactionThreshold, LikeCount = trendingFeed.LikeCount, ViewCount = trendingFeed.ViewCount, CommentCount = trendingFeed.CommentCount };

        public static FollowedFeedFollowedUsersDTO Converter_FollowedFeedFollowedUsersToDTO(FollowedFeedFollowedUsers followedFeedFollowedUsers) => new FollowedFeedFollowedUsersDTO { ID = followedFeedFollowedUsers.ID, FollowedFeedID = followedFeedFollowedUsers.FollowedFeedID, FollowedUserID = followedFeedFollowedUsers.FollowedUserID };
        public static FollowingFeedDTO Converter_FollowingFeedToDTO(FollowingFeed followingFeed) => new FollowingFeedDTO { ID = followingFeed.ID, Name = followingFeed.Name, ReactionThreshold = followingFeed.ReactionThreshold };
        public static CommentDTO Converter_CommentToDTO(Comment comment) => new CommentDTO { Id = comment.Id, Post_Id = comment.Post_Id, Owner_User_Id = comment.Owner_User_Id, Description = comment.Description };


        public static FollowSuggestionDTO Converter_FollowSuggestionDTO(FollowSuggestion followSuggestion) => new FollowSuggestionDTO { Id = followSuggestion.Id, userId = followSuggestion.userId, username = followSuggestion.username, numberOfCommonFriends = followSuggestion.numberOfCommonFriends, numberOfCommonGroups = followSuggestion.numberOfCommonGroups, numberOfCommonOrganizations = followSuggestion.numberOfCommonOrganizations, numberOfCommonTags = followSuggestion.numberOfCommonTags, location = followSuggestion.location };

        public static RequestDTO Converter_RequestToDTO(Request request) => new RequestDTO { Id = request.Id, ReceiverId = request.ReceiverId, SenderId = request.SenderId };
    }
}