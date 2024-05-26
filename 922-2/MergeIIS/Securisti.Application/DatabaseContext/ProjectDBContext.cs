using Microsoft.EntityFrameworkCore;
using Server.Models;
using System.Collections.Generic;
using UBB_SE_2024_Gaborment.Server.Models;

namespace Server.DatabaseContext
{
    public class ProjectDBContext : DbContext
    {
        public ProjectDBContext(DbContextOptions<ProjectDBContext> options) : base(options)
        {
        }

        public DbSet<Location> Locations { get; set; } = null!;
        public DbSet<Media> Medias { get; set; } = null!;
        public DbSet<RetardedUser> Users { get; set; } = null!;
        public DbSet<Post> Posts { get; set; } = null!;
        public DbSet<PostArchived> PostArchived { get; set; } = null!;
        public DbSet<PostSaved> PostSaved { get; set; } = null!;
        public DbSet<PostReported> PostReported { get; set; } = null!;
        public DbSet<Block> Block { get; set; } = null!;
        public DbSet<Follow> Follow { get; set; } = null!;
        public DbSet<FeedConfiguration> FeedConfigurations { get; set; } = null!;
        public DbSet<ControversialFeed> ControversialFeeds { get; set; } = null!;
        public DbSet<TrendingFeed> TrendingFeeds { get; set; } = null!;
        public DbSet<FollowedFeedFollowedUsers> FollowedFeedFollowedUsers { get; set; } = null!;
        public DbSet<FollowingFeed> FollowingFeeds { get; set; } = null!;
        public DbSet<Comment> Comments { get; set; } = null!;
        public DbSet<FollowSuggestion> FollowSuggestions { get; set; } = null!;

        public DbSet<Request> Requests { get; set; } = null!;
    }
}