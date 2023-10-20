using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LarQ.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FavoriteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubscriptionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UploadedFiles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OriginalFileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContentType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileSize = table.Column<long>(type: "bigint", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UploadedFiles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Favorites",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favorites", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Favorites_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Owners",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Owners", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Owners_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Playlists",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Playlists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Playlists_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Subscriptions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subscriptions_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    IconId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_UploadedFiles_IconId",
                        column: x => x.IconId,
                        principalTable: "UploadedFiles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Hosts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Bio = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    PictureId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OwnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hosts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hosts_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Hosts_Owners_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Owners",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Hosts_UploadedFiles_PictureId",
                        column: x => x.PictureId,
                        principalTable: "UploadedFiles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Podcasts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    Name = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2500)", maxLength: 2500, nullable: false),
                    HostId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CoverId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Podcasts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Podcasts_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Podcasts_Hosts_HostId",
                        column: x => x.HostId,
                        principalTable: "Hosts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Podcasts_UploadedFiles_CoverId",
                        column: x => x.CoverId,
                        principalTable: "UploadedFiles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Episodes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(700)", maxLength: 700, nullable: false),
                    AudioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PodcastId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TranscriptId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Episodes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Episodes_Podcasts_PodcastId",
                        column: x => x.PodcastId,
                        principalTable: "Podcasts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Episodes_UploadedFiles_AudioId",
                        column: x => x.AudioId,
                        principalTable: "UploadedFiles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Episodes_UploadedFiles_TranscriptId",
                        column: x => x.TranscriptId,
                        principalTable: "UploadedFiles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FavoriteItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    PodcastId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FavoriteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoriteItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FavoriteItems_Favorites_FavoriteId",
                        column: x => x.FavoriteId,
                        principalTable: "Favorites",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FavoriteItems_Podcasts_PodcastId",
                        column: x => x.PodcastId,
                        principalTable: "Podcasts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PlaylistItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    PlaylistId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PodcastsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlaylistItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlaylistItems_Playlists_PlaylistId",
                        column: x => x.PlaylistId,
                        principalTable: "Playlists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlaylistItems_Podcasts_PodcastsId",
                        column: x => x.PodcastsId,
                        principalTable: "Podcasts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Subscribes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    PodcastId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubscriptionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscribes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subscribes_Podcasts_PodcastId",
                        column: x => x.PodcastId,
                        principalTable: "Podcasts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Subscribes_Subscriptions_SubscriptionId",
                        column: x => x.SubscriptionId,
                        principalTable: "Subscriptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(700)", maxLength: 700, nullable: false),
                    EpisodeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_Episodes_EpisodeId",
                        column: x => x.EpisodeId,
                        principalTable: "Episodes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Guests",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Nationality = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PictureId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EpisodesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BornDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Guests_Episodes_EpisodesId",
                        column: x => x.EpisodesId,
                        principalTable: "Episodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Guests_UploadedFiles_PictureId",
                        column: x => x.PictureId,
                        principalTable: "UploadedFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reacts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReactType = table.Column<int>(type: "int", nullable: false),
                    EpisodeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reacts_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reacts_Episodes_EpisodeId",
                        column: x => x.EpisodeId,
                        principalTable: "Episodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FavoriteId", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "SubscriptionId", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("0224e690-3760-4304-9e00-7bf9aa53da1c"), 0, "770f8493-5cea-405f-a86d-3a9ad356b3ab", "me@admin.com", true, new Guid("00000000-0000-0000-0000-000000000000"), false, null, "Admin", "ME@ADMIN.COM", "ME@ADMIN.COM", "AQAAAAIAAYagAAAAEJ0WUGjWLkXmaVyV0EnSrWRDet25PXRkSEnVU86myV7I9TX0yTNXGnzF/k526PbUvw==", null, false, null, new Guid("00000000-0000-0000-0000-000000000000"), false, "me@admin.com" },
                    { new Guid("4e803c56-02f4-44b6-bc20-4a20df7d9698"), 0, "2b25269a-3064-4d47-bdab-ac8d9eaa0260", "me@owner.com", true, new Guid("00000000-0000-0000-0000-000000000000"), false, null, "Owner", "ME@OWNER.COM", "ME@OWNER.COM", "AQAAAAIAAYagAAAAEKQUUeY73uwRgGGOnEkek6GZrlYAr3+x4et65iROJrlqpnMwmOJjsj3t8E2EZS13fQ==", null, false, null, new Guid("00000000-0000-0000-0000-000000000000"), false, "me@owner.com" },
                    { new Guid("5c058293-f259-4407-8c2c-a27742e53769"), 0, "593fdaab-94f5-425f-9231-65bcb99ab278", "twice@owner.com", true, new Guid("00000000-0000-0000-0000-000000000000"), false, null, "Twice", "TWICE@OWNER.COM", "TWICe@OWNER.COM", "AQAAAAIAAYagAAAAENo3J7Rp5kaTLfCYGEANGCVl2Ttn+6UwZloP6atg5nj3mW67AxGJiM1hYJTUsyewiA==", null, false, null, new Guid("00000000-0000-0000-0000-000000000000"), false, "twice@owner.com" }
                });

            migrationBuilder.InsertData(
                table: "UploadedFiles",
                columns: new[] { "Id", "ContentType", "CreateAt", "FileName", "FilePath", "FileSize", "OriginalFileName" },
                values: new object[] { new Guid("3a30f028-12b6-4187-84de-df5ac5d838be"), "jpg", new DateTime(2023, 10, 17, 15, 58, 46, 951, DateTimeKind.Local).AddTicks(5273), "GuestImage", "/home/modsyan/projects/", 0L, "23511317.jpg" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreateAt", "IconId", "Name" },
                values: new object[,]
                {
                    { new Guid("02278eb6-ba51-47cc-bee0-19bf10f1a4f6"), new DateTime(2023, 10, 17, 15, 58, 46, 951, DateTimeKind.Local).AddTicks(5779), new Guid("3a30f028-12b6-4187-84de-df5ac5d838be"), "History" },
                    { new Guid("0a3c9e29-9db0-492d-9991-a284ff8e0593"), new DateTime(2023, 10, 17, 15, 58, 46, 951, DateTimeKind.Local).AddTicks(5813), new Guid("3a30f028-12b6-4187-84de-df5ac5d838be"), "War" },
                    { new Guid("0ab8e44e-3b98-4d74-a6c0-3cabc5761fa7"), new DateTime(2023, 10, 17, 15, 58, 46, 951, DateTimeKind.Local).AddTicks(5799), new Guid("3a30f028-12b6-4187-84de-df5ac5d838be"), "Romance" },
                    { new Guid("192929bf-54d8-48a0-a6af-22a4fb9b83b6"), new DateTime(2023, 10, 17, 15, 58, 46, 951, DateTimeKind.Local).AddTicks(5746), new Guid("3a30f028-12b6-4187-84de-df5ac5d838be"), "Comedy" },
                    { new Guid("28f2efd4-1fb0-4ffa-bac4-c7650458319e"), new DateTime(2023, 10, 17, 15, 58, 46, 951, DateTimeKind.Local).AddTicks(5789), new Guid("3a30f028-12b6-4187-84de-df5ac5d838be"), "Music" },
                    { new Guid("2e56062d-9385-4d14-9ddb-4b54631a9e37"), new DateTime(2023, 10, 17, 15, 58, 46, 951, DateTimeKind.Local).AddTicks(5794), new Guid("3a30f028-12b6-4187-84de-df5ac5d838be"), "Mystery" },
                    { new Guid("35be6686-0dcb-47f2-93a6-b25e73b2d625"), new DateTime(2023, 10, 17, 15, 58, 46, 951, DateTimeKind.Local).AddTicks(5784), new Guid("3a30f028-12b6-4187-84de-df5ac5d838be"), "Horror" },
                    { new Guid("472b87a8-1591-41a7-af4a-256dc850cdf5"), new DateTime(2023, 10, 17, 15, 58, 46, 951, DateTimeKind.Local).AddTicks(5768), new Guid("3a30f028-12b6-4187-84de-df5ac5d838be"), "Family" },
                    { new Guid("48a0b837-b0a6-49d9-81fa-fa451060d48c"), new DateTime(2023, 10, 17, 15, 58, 46, 951, DateTimeKind.Local).AddTicks(5819), new Guid("3a30f028-12b6-4187-84de-df5ac5d838be"), "Western" },
                    { new Guid("491ac550-eb74-4700-8a41-0b867566abf9"), new DateTime(2023, 10, 17, 15, 58, 46, 951, DateTimeKind.Local).AddTicks(5736), new Guid("3a30f028-12b6-4187-84de-df5ac5d838be"), "Adventure" },
                    { new Guid("5f109560-b718-4645-a3e3-fcffe05f6bd6"), new DateTime(2023, 10, 17, 15, 58, 46, 951, DateTimeKind.Local).AddTicks(5752), new Guid("3a30f028-12b6-4187-84de-df5ac5d838be"), "Crime" },
                    { new Guid("9a52f097-a77b-4957-9cd4-2f9aec8d3274"), new DateTime(2023, 10, 17, 15, 58, 46, 951, DateTimeKind.Local).AddTicks(5803), new Guid("3a30f028-12b6-4187-84de-df5ac5d838be"), "ScienceFiction" },
                    { new Guid("a6371e38-0011-4874-8c10-ecf32e05827d"), new DateTime(2023, 10, 17, 15, 58, 46, 951, DateTimeKind.Local).AddTicks(5763), new Guid("3a30f028-12b6-4187-84de-df5ac5d838be"), "Drama" },
                    { new Guid("a827ea3e-6ed4-42cf-91a0-a5fd151c0315"), new DateTime(2023, 10, 17, 15, 58, 46, 951, DateTimeKind.Local).AddTicks(5808), new Guid("3a30f028-12b6-4187-84de-df5ac5d838be"), "Thriller" },
                    { new Guid("b21efb42-b546-4a6d-b101-07c96a6ed8b1"), new DateTime(2023, 10, 17, 15, 58, 46, 951, DateTimeKind.Local).AddTicks(5741), new Guid("3a30f028-12b6-4187-84de-df5ac5d838be"), "Animation" },
                    { new Guid("efe5f17c-7c07-4044-856d-330d17a67c03"), new DateTime(2023, 10, 17, 15, 58, 46, 951, DateTimeKind.Local).AddTicks(5758), new Guid("3a30f028-12b6-4187-84de-df5ac5d838be"), "Documentary" },
                    { new Guid("f1b96a7b-8603-497e-a119-24dfd971fc13"), new DateTime(2023, 10, 17, 15, 58, 46, 951, DateTimeKind.Local).AddTicks(5724), new Guid("3a30f028-12b6-4187-84de-df5ac5d838be"), "Action" },
                    { new Guid("f78ea7f3-f350-49ff-8c51-2299b99f45c8"), new DateTime(2023, 10, 17, 15, 58, 46, 951, DateTimeKind.Local).AddTicks(5773), new Guid("3a30f028-12b6-4187-84de-df5ac5d838be"), "Fantasy" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_IconId",
                table: "Categories",
                column: "IconId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_EpisodeId",
                table: "Comments",
                column: "EpisodeId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Episodes_AudioId",
                table: "Episodes",
                column: "AudioId");

            migrationBuilder.CreateIndex(
                name: "IX_Episodes_PodcastId",
                table: "Episodes",
                column: "PodcastId");

            migrationBuilder.CreateIndex(
                name: "IX_Episodes_TranscriptId",
                table: "Episodes",
                column: "TranscriptId");

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteItems_FavoriteId",
                table: "FavoriteItems",
                column: "FavoriteId");

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteItems_PodcastId",
                table: "FavoriteItems",
                column: "PodcastId");

            migrationBuilder.CreateIndex(
                name: "IX_Favorites_UserId",
                table: "Favorites",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Guests_EpisodesId",
                table: "Guests",
                column: "EpisodesId");

            migrationBuilder.CreateIndex(
                name: "IX_Guests_PictureId",
                table: "Guests",
                column: "PictureId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Hosts_OwnerId",
                table: "Hosts",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Hosts_PictureId",
                table: "Hosts",
                column: "PictureId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Hosts_UserId",
                table: "Hosts",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Owners_UserId",
                table: "Owners",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PlaylistItems_PlaylistId",
                table: "PlaylistItems",
                column: "PlaylistId");

            migrationBuilder.CreateIndex(
                name: "IX_PlaylistItems_PodcastsId",
                table: "PlaylistItems",
                column: "PodcastsId");

            migrationBuilder.CreateIndex(
                name: "IX_Playlists_UserId",
                table: "Playlists",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Podcasts_CategoryId",
                table: "Podcasts",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Podcasts_CoverId",
                table: "Podcasts",
                column: "CoverId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Podcasts_HostId",
                table: "Podcasts",
                column: "HostId");

            migrationBuilder.CreateIndex(
                name: "IX_Reacts_EpisodeId",
                table: "Reacts",
                column: "EpisodeId");

            migrationBuilder.CreateIndex(
                name: "IX_Reacts_UserId",
                table: "Reacts",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Subscribes_PodcastId",
                table: "Subscribes",
                column: "PodcastId");

            migrationBuilder.CreateIndex(
                name: "IX_Subscribes_SubscriptionId",
                table: "Subscribes",
                column: "SubscriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_UserId",
                table: "Subscriptions",
                column: "UserId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "FavoriteItems");

            migrationBuilder.DropTable(
                name: "Guests");

            migrationBuilder.DropTable(
                name: "PlaylistItems");

            migrationBuilder.DropTable(
                name: "Reacts");

            migrationBuilder.DropTable(
                name: "Subscribes");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Favorites");

            migrationBuilder.DropTable(
                name: "Playlists");

            migrationBuilder.DropTable(
                name: "Episodes");

            migrationBuilder.DropTable(
                name: "Subscriptions");

            migrationBuilder.DropTable(
                name: "Podcasts");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Hosts");

            migrationBuilder.DropTable(
                name: "Owners");

            migrationBuilder.DropTable(
                name: "UploadedFiles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
