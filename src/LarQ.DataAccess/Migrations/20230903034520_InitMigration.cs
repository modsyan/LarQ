using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LarQ.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class InitMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
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
                name: "Actors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nationality = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PictureId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BornDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Actors_UploadedFiles_PictureId",
                        column: x => x.PictureId,
                        principalTable: "UploadedFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    Name = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2500)", maxLength: 2500, nullable: false),
                    CoverId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TrailerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VideoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Movies_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Movies_UploadedFiles_CoverId",
                        column: x => x.CoverId,
                        principalTable: "UploadedFiles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Movies_UploadedFiles_TrailerId",
                        column: x => x.TrailerId,
                        principalTable: "UploadedFiles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Movies_UploadedFiles_VideoId",
                        column: x => x.VideoId,
                        principalTable: "UploadedFiles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ActorMovies",
                columns: table => new
                {
                    ActorsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MoviesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActorMovies", x => new { x.ActorsId, x.MoviesId });
                    table.ForeignKey(
                        name: "FK_ActorMovies_Actors_ActorsId",
                        column: x => x.ActorsId,
                        principalTable: "Actors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActorMovies_Movies_MoviesId",
                        column: x => x.MoviesId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Favorites",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    MovieId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favorites", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Favorites_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Favorites_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "UploadedFiles",
                columns: new[] { "Id", "ContentType", "CreateAt", "FileName", "FilePath", "FileSize", "OriginalFileName", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("7a628b2a-fb48-42d3-9fdc-9ea16bf48e88"), "jpg", new DateTime(2023, 9, 3, 6, 45, 20, 288, DateTimeKind.Local).AddTicks(4984), "ActorImage", "/home/modsyan/projects/", 0L, "23511317.jpg", null },
                    { new Guid("b07b46ea-af97-4b78-8976-3bd112b5a97f"), "jpg", new DateTime(2023, 9, 3, 6, 45, 20, 288, DateTimeKind.Local).AddTicks(6086), "ActorImage", "/home/modsyan/projects/", 0L, "23511317.jpg", null }
                });

            migrationBuilder.InsertData(
                table: "Actors",
                columns: new[] { "Id", "BornDate", "Name", "Nationality", "PictureId" },
                values: new object[,]
                {
                    { new Guid("06dfb56b-b8a2-4956-b281-79629b9a27b1"), new DateTime(1943, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Robert De Niro", "American", new Guid("b07b46ea-af97-4b78-8976-3bd112b5a97f") },
                    { new Guid("0863678b-57f2-4e8c-a59a-af9c4d7e6bef"), new DateTime(1965, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Aamir Khan", "Indian", new Guid("b07b46ea-af97-4b78-8976-3bd112b5a97f") },
                    { new Guid("0d5531e5-086a-46cd-ac90-c90f8d36e318"), new DateTime(1937, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Morgan Freeman", "American", new Guid("b07b46ea-af97-4b78-8976-3bd112b5a97f") },
                    { new Guid("213d3e5e-b3c1-43ed-856d-8d424320472b"), new DateTime(1963, 6, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Johnny Depp", "American", new Guid("b07b46ea-af97-4b78-8976-3bd112b5a97f") },
                    { new Guid("24332a34-a1a8-4729-843e-f2a5df5e7eab"), new DateTime(1949, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ahmed Zaki", "Egyptian", new Guid("b07b46ea-af97-4b78-8976-3bd112b5a97f") },
                    { new Guid("40bc7fc5-eff0-45e3-a78f-d21e66502b62"), new DateTime(1969, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cate Blanchett", "Australian", new Guid("b07b46ea-af97-4b78-8976-3bd112b5a97f") },
                    { new Guid("44d66726-8025-4e5f-b0bd-b9c52f5e87a7"), new DateTime(1940, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Adel Emam", "Egyptian", new Guid("b07b46ea-af97-4b78-8976-3bd112b5a97f") },
                    { new Guid("478fda24-410b-4b8e-9816-3a59d504884b"), new DateTime(1932, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Omar Sharif", "Egyptian", new Guid("b07b46ea-af97-4b78-8976-3bd112b5a97f") },
                    { new Guid("4eeb4185-f6af-4663-bdd2-6f841c72846e"), new DateTime(1966, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Khaled Abol Naga", "Egyptian", new Guid("b07b46ea-af97-4b78-8976-3bd112b5a97f") },
                    { new Guid("73116e1e-fbc4-41f1-ab5a-33a78c85721a"), new DateTime(1949, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Meryl Streep", "American", new Guid("b07b46ea-af97-4b78-8976-3bd112b5a97f") },
                    { new Guid("778be799-ad7f-4fe7-8407-caabbc5f0cd0"), new DateTime(1964, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Keanu Reeves", "Canadian", new Guid("b07b46ea-af97-4b78-8976-3bd112b5a97f") },
                    { new Guid("7f4dc9d0-09ba-4bf7-94bf-170b43244b3c"), new DateTime(1931, 5, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Faten Hamama", "Egyptian", new Guid("b07b46ea-af97-4b78-8976-3bd112b5a97f") },
                    { new Guid("86c342fb-036b-4405-8069-9f6d643aa44a"), new DateTime(1965, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Salman Khan", "Indian", new Guid("b07b46ea-af97-4b78-8976-3bd112b5a97f") },
                    { new Guid("8ec3a827-ff52-4518-87cf-7f9d21dff3a4"), new DateTime(1984, 12, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mahira Khan", "Pakistani", new Guid("b07b46ea-af97-4b78-8976-3bd112b5a97f") },
                    { new Guid("8ed2c14a-6656-4702-a51f-1a5db1f5465b"), new DateTime(1973, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Amr Waked", "Egyptian", new Guid("b07b46ea-af97-4b78-8976-3bd112b5a97f") },
                    { new Guid("8ed78aa7-8f60-4bf2-aae5-102e623e1af8"), new DateTime(1965, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Shah Rukh Khan", "Indian", new Guid("b07b46ea-af97-4b78-8976-3bd112b5a97f") },
                    { new Guid("91655fb3-4d03-473f-88dc-97573e757fc7"), new DateTime(1956, 7, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tom Hanks", "American", new Guid("b07b46ea-af97-4b78-8976-3bd112b5a97f") },
                    { new Guid("9555e95f-2364-4bae-b9f4-68b071b480fc"), new DateTime(1954, 12, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Denzel Washington", "American", new Guid("b07b46ea-af97-4b78-8976-3bd112b5a97f") },
                    { new Guid("9f340754-7f9e-45d0-a0a7-c25ef628fbd5"), new DateTime(1976, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Haifa Wehbe", "Lebanese", new Guid("b07b46ea-af97-4b78-8976-3bd112b5a97f") },
                    { new Guid("b6a1ed4d-2acb-428b-9196-bedbf718570a"), new DateTime(1974, 4, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Penélope Cruz", "Spanish", new Guid("b07b46ea-af97-4b78-8976-3bd112b5a97f") },
                    { new Guid("bd9bce44-c59d-47b5-bd58-dfbf8f57c041"), new DateTime(1974, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nelly Karim", "Egyptian", new Guid("b07b46ea-af97-4b78-8976-3bd112b5a97f") },
                    { new Guid("bed43335-d370-4d4b-9e73-87ea6b11ea47"), new DateTime(1964, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Monica Bellucci", "Italian", new Guid("b07b46ea-af97-4b78-8976-3bd112b5a97f") },
                    { new Guid("c7bea4be-f81a-429e-ae7b-dd90a5cf6c36"), new DateTime(1974, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Leonardo DiCaprio", "American", new Guid("b07b46ea-af97-4b78-8976-3bd112b5a97f") },
                    { new Guid("df48b136-987b-40fc-a9ba-71873ee801fc"), new DateTime(1930, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nawal El Saadawi", "Egyptian", new Guid("b07b46ea-af97-4b78-8976-3bd112b5a97f") },
                    { new Guid("f2d44b55-3292-4742-ab80-cdbb4127a584"), new DateTime(1942, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Amitabh Bachchan", "Indian", new Guid("b07b46ea-af97-4b78-8976-3bd112b5a97f") },
                    { new Guid("f9fcb594-0aa8-43a0-8058-badfe8d81395"), new DateTime(1967, 10, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Julia Roberts", "American", new Guid("b07b46ea-af97-4b78-8976-3bd112b5a97f") }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreateAt", "IconId", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("021dd101-8b97-4087-8279-eecf1dfd5315"), new DateTime(2023, 9, 3, 6, 45, 20, 288, DateTimeKind.Local).AddTicks(5901), new Guid("7a628b2a-fb48-42d3-9fdc-9ea16bf48e88"), "Comedy", null },
                    { new Guid("09d64147-6677-40ec-b88a-11adbb31b1cd"), new DateTime(2023, 9, 3, 6, 45, 20, 288, DateTimeKind.Local).AddTicks(6002), new Guid("7a628b2a-fb48-42d3-9fdc-9ea16bf48e88"), "Romance", null },
                    { new Guid("1f2208aa-0467-437d-bd35-81d0a1bdedbe"), new DateTime(2023, 9, 3, 6, 45, 20, 288, DateTimeKind.Local).AddTicks(6014), new Guid("7a628b2a-fb48-42d3-9fdc-9ea16bf48e88"), "Thriller", null },
                    { new Guid("24842d8b-a7c0-408b-a4ff-8d3fce394a53"), new DateTime(2023, 9, 3, 6, 45, 20, 288, DateTimeKind.Local).AddTicks(5940), new Guid("7a628b2a-fb48-42d3-9fdc-9ea16bf48e88"), "Crime", null },
                    { new Guid("2998fe97-5533-40a5-a441-297c8cddfe6d"), new DateTime(2023, 9, 3, 6, 45, 20, 288, DateTimeKind.Local).AddTicks(5958), new Guid("7a628b2a-fb48-42d3-9fdc-9ea16bf48e88"), "Drama", null },
                    { new Guid("32c673de-4c34-46de-adf1-bab1f8ccfea2"), new DateTime(2023, 9, 3, 6, 45, 20, 288, DateTimeKind.Local).AddTicks(5979), new Guid("7a628b2a-fb48-42d3-9fdc-9ea16bf48e88"), "History", null },
                    { new Guid("509fad61-329f-4ba6-8b52-cc013858c232"), new DateTime(2023, 9, 3, 6, 45, 20, 288, DateTimeKind.Local).AddTicks(5952), new Guid("7a628b2a-fb48-42d3-9fdc-9ea16bf48e88"), "Documentary", null },
                    { new Guid("59df78ae-eb12-484d-b2e4-67c6e5fdb4e1"), new DateTime(2023, 9, 3, 6, 45, 20, 288, DateTimeKind.Local).AddTicks(5888), new Guid("7a628b2a-fb48-42d3-9fdc-9ea16bf48e88"), "Adventure", null },
                    { new Guid("5b8f6067-aeaf-49d3-abba-bf30d9ec0e31"), new DateTime(2023, 9, 3, 6, 45, 20, 288, DateTimeKind.Local).AddTicks(5895), new Guid("7a628b2a-fb48-42d3-9fdc-9ea16bf48e88"), "Animation", null },
                    { new Guid("5ed0e656-8d2a-449c-9171-f55cb5023b59"), new DateTime(2023, 9, 3, 6, 45, 20, 288, DateTimeKind.Local).AddTicks(6008), new Guid("7a628b2a-fb48-42d3-9fdc-9ea16bf48e88"), "ScienceFiction", null },
                    { new Guid("8eded9aa-8568-47d8-92dc-21e68e44fd85"), new DateTime(2023, 9, 3, 6, 45, 20, 288, DateTimeKind.Local).AddTicks(6026), new Guid("7a628b2a-fb48-42d3-9fdc-9ea16bf48e88"), "Western", null },
                    { new Guid("9dceb253-137e-4a55-8d45-d71d97ca63f5"), new DateTime(2023, 9, 3, 6, 45, 20, 288, DateTimeKind.Local).AddTicks(5964), new Guid("7a628b2a-fb48-42d3-9fdc-9ea16bf48e88"), "Family", null },
                    { new Guid("ac50915b-23c9-41df-a878-db74bea1aef3"), new DateTime(2023, 9, 3, 6, 45, 20, 288, DateTimeKind.Local).AddTicks(5997), new Guid("7a628b2a-fb48-42d3-9fdc-9ea16bf48e88"), "Mystery", null },
                    { new Guid("b743f838-4ea7-4522-a015-6657d67a7990"), new DateTime(2023, 9, 3, 6, 45, 20, 288, DateTimeKind.Local).AddTicks(5991), new Guid("7a628b2a-fb48-42d3-9fdc-9ea16bf48e88"), "Music", null },
                    { new Guid("b865f631-af82-470a-9bc5-4d205161bb7e"), new DateTime(2023, 9, 3, 6, 45, 20, 288, DateTimeKind.Local).AddTicks(6020), new Guid("7a628b2a-fb48-42d3-9fdc-9ea16bf48e88"), "War", null },
                    { new Guid("d8e6f56b-a22b-41d3-bfc3-728cb5fd6663"), new DateTime(2023, 9, 3, 6, 45, 20, 288, DateTimeKind.Local).AddTicks(5863), new Guid("7a628b2a-fb48-42d3-9fdc-9ea16bf48e88"), "Action", null },
                    { new Guid("e04e4e4e-4082-499e-939f-6eb13ed297f2"), new DateTime(2023, 9, 3, 6, 45, 20, 288, DateTimeKind.Local).AddTicks(5985), new Guid("7a628b2a-fb48-42d3-9fdc-9ea16bf48e88"), "Horror", null },
                    { new Guid("fa3b6481-56e0-49f3-ad7c-363a7857af5f"), new DateTime(2023, 9, 3, 6, 45, 20, 288, DateTimeKind.Local).AddTicks(5970), new Guid("7a628b2a-fb48-42d3-9fdc-9ea16bf48e88"), "Fantasy", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActorMovies_MoviesId",
                table: "ActorMovies",
                column: "MoviesId");

            migrationBuilder.CreateIndex(
                name: "IX_Actors_PictureId",
                table: "Actors",
                column: "PictureId");

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
                name: "IX_Favorites_MovieId",
                table: "Favorites",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Favorites_UserId",
                table: "Favorites",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_CategoryId",
                table: "Movies",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_CoverId",
                table: "Movies",
                column: "CoverId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Movies_TrailerId",
                table: "Movies",
                column: "TrailerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Movies_VideoId",
                table: "Movies",
                column: "VideoId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActorMovies");

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
                name: "Favorites");

            migrationBuilder.DropTable(
                name: "Actors");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "UploadedFiles");
        }
    }
}
