using Server.DTOs;
using Server.Models;
using UBB_SE_2024_Gaborment.Server.Models;

namespace Server.Utils
{
    public class DTOToBaseConverters
    {
        public static RetardedUser Converter_DTOToUser(UserDTO userDTO) => new RetardedUser { Id = userDTO.Id, Username = userDTO.Username, ProfilePicturePath = userDTO.ProfilePicturePath };
        public static Media Converter_DTOToMedia(MediaDTO mediaDTO) => new Media { Id = mediaDTO.Id, FilePath = mediaDTO.FilePath };
        public static Location Converter_DTOToLocation(LocationDTO locationDTO) => new Location { Id = locationDTO.Id, Name = locationDTO.Name, Latitude = locationDTO.Latitude, Longitude = locationDTO.Longitude };
    
        public static Post Converter_DTOToPost(PostDTO postDTO) => new Post { Post_Id = postDTO.Post_Id, Owner_User_Id = postDTO.Owner_User_Id, Description = postDTO.Description, Commented_Post_Id = postDTO.Commented_Post_Id, Original_Post_Id = postDTO.Original_Post_Id, Media_Path = postDTO.Media_Path, Post_Type = postDTO.Post_Type, Location_Id = postDTO.Location_Id, Created_Date = postDTO.Created_Date };

        public static PostArchived Converter_DTOToPostArchived(PostArchivedDTO postArchivedDTO) => new PostArchived { post_id = postArchivedDTO.post_id, archive_id = postArchivedDTO.archive_id };
        public static PostSaved Converter_DTOToPostSaved(PostSavedDTO postSavedDTO) => new PostSaved { save_id = postSavedDTO.save_id, post_id = postSavedDTO.post_id, user_id = postSavedDTO.user_id };
    
        public static PostReportedDTO Converter_PostReportedToDTO(PostReported postReported) => new PostReportedDTO { Report_Id = postReported.Report_Id, Reason = postReported.Reason, Description = postReported.Description, Post_Id = postReported.Post_Id, Reporter_Id = postReported.Reporter_Id };
        public static Block Converter_DTOToBlock(BlockDTO blockDTO) => new Block { Id = blockDTO.Id, sender = blockDTO.sender, receiver = blockDTO.receiver, startingTimeStamp = blockDTO.startingTimeStamp, reason = blockDTO.reason };
        public static Follow Converter_DTOToFollow(FollowDTO followDTO) => new Follow { Id = followDTO.Id, sender = followDTO.sender, receiver = followDTO.receiver, isCloseFriend = followDTO.isCloseFriend, expirationTimeStamp = followDTO.expirationTimeStamp, description = followDTO.description };
        public static FeedConfiguration Converter_DTOToFeedConfiguration(FeedConfigurationDTO feedConfigurationDTO) => new FeedConfiguration { ID = feedConfigurationDTO.ID, Name = feedConfigurationDTO.Name, ReactionThreshold = feedConfigurationDTO.ReactionThreshold };

        public static ControversialFeed Converter_DTOToControversialFeed(ControversialFeedDTO controversialFeedDTO) => new ControversialFeed { ID = controversialFeedDTO.ID, Name = controversialFeedDTO.Name, ReactionThreshold = controversialFeedDTO.ReactionThreshold, MinimumReactionCount = controversialFeedDTO.MinimumReactionCount, MinimumCommentCount = controversialFeedDTO.MinimumCommentCount };
        public static TrendingFeed Converter_DTOToTrendingFeed(TrendingFeedDTO trendingFeedDTO) => new TrendingFeed { ID = trendingFeedDTO.ID, Name = trendingFeedDTO.Name, ReactionThreshold = trendingFeedDTO.ReactionThreshold, LikeCount = trendingFeedDTO.LikeCount, ViewCount = trendingFeedDTO.ViewCount, CommentCount = trendingFeedDTO.CommentCount };

        public static FollowedFeedFollowedUsers Converter_DTOToFollowedFeedFollowedUsers(FollowedFeedFollowedUsersDTO followedFeedFollowedUsersDTO) => new FollowedFeedFollowedUsers { ID = followedFeedFollowedUsersDTO.ID, FollowedFeedID = followedFeedFollowedUsersDTO.FollowedFeedID, FollowedUserID = followedFeedFollowedUsersDTO.FollowedUserID };
        public static FollowingFeed Converter_DTOToFollowingFeed(FollowingFeedDTO followingFeedDTO) => new FollowingFeed { ID = followingFeedDTO.ID, Name = followingFeedDTO.Name, ReactionThreshold = followingFeedDTO.ReactionThreshold };
        public static Comment Converter_DTOToComment(CommentDTO commentDTO) => new Comment { Id = commentDTO.Id, Post_Id = commentDTO.Post_Id, Owner_User_Id = commentDTO.Owner_User_Id, Description = commentDTO.Description };
        public static FollowSuggestion Converter_DTOToFollowSuggestion(FollowSuggestionDTO followSuggestionDTO) => new FollowSuggestion { Id = followSuggestionDTO.Id, userId = followSuggestionDTO.userId, username = followSuggestionDTO.username, numberOfCommonFriends = followSuggestionDTO.numberOfCommonFriends, numberOfCommonGroups = followSuggestionDTO.numberOfCommonGroups, numberOfCommonOrganizations = followSuggestionDTO.numberOfCommonOrganizations, numberOfCommonTags = followSuggestionDTO.numberOfCommonTags, location = followSuggestionDTO.location };

        public static Request Converter_DTOToRequest(RequestDTO requestDTO) => new Request { Id = requestDTO.Id, ReceiverId = requestDTO.ReceiverId, SenderId = requestDTO.SenderId };
    }

}
