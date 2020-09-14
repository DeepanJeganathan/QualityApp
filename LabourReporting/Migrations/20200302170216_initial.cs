using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LabourReporting.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Operators",
                columns: table => new
                {
                    OperatorID = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operators", x => x.OperatorID);
                });

            migrationBuilder.CreateTable(
                name: "WorkStations",
                columns: table => new
                {
                    WorkStationId = table.Column<int>(nullable: false),
                    WorkStationName = table.Column<string>(nullable: false),
                    Department = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkStations", x => x.WorkStationId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
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
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
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
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
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
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
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
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
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
                name: "LabourReports",
                columns: table => new
                {
                    LabourReportId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    ShopOrder = table.Column<int>(nullable: false),
                    ItemNo = table.Column<string>(nullable: false),
                    AllowedTime = table.Column<float>(nullable: false),
                    TotalTime = table.Column<float>(nullable: false),
                    Quantity = table.Column<double>(nullable: false),
                    Scrap = table.Column<double>(nullable: true),
                    Comments = table.Column<string>(nullable: true),
                    SupervisorComments = table.Column<string>(nullable: true),
                    OperatorID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LabourReports", x => x.LabourReportId);
                    table.ForeignKey(
                        name: "FK_LabourReports_Operators_OperatorID",
                        column: x => x.OperatorID,
                        principalTable: "Operators",
                        principalColumn: "OperatorID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NcrTags",
                columns: table => new
                {
                    Tag_No = table.Column<double>(nullable: false),
                    Date_Rej = table.Column<DateTime>(nullable: false),
                    Disposition = table.Column<string>(nullable: false),
                    Item = table.Column<string>(nullable: false),
                    Colour = table.Column<string>(nullable: true),
                    Put_Up = table.Column<int>(nullable: true),
                    Qty = table.Column<double>(nullable: false),
                    Order_number = table.Column<int>(nullable: true),
                    Defect = table.Column<string>(nullable: true),
                    NcrComments = table.Column<string>(nullable: true),
                    SupervisorSignature = table.Column<string>(nullable: true),
                    OperationNumber = table.Column<int>(nullable: true),
                    OperatorId = table.Column<int>(nullable: false),
                    WorkStationId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NcrTags", x => x.Tag_No);
                    table.ForeignKey(
                        name: "FK_NcrTags_Operators_OperatorId",
                        column: x => x.OperatorId,
                        principalTable: "Operators",
                        principalColumn: "OperatorID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NcrTags_WorkStations_WorkStationId",
                        column: x => x.WorkStationId,
                        principalTable: "WorkStations",
                        principalColumn: "WorkStationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OperatorWorkstations",
                columns: table => new
                {
                    OperatorID = table.Column<int>(nullable: false),
                    WorkStationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperatorWorkstations", x => new { x.OperatorID, x.WorkStationId });
                    table.ForeignKey(
                        name: "FK_OperatorWorkstations_Operators_OperatorID",
                        column: x => x.OperatorID,
                        principalTable: "Operators",
                        principalColumn: "OperatorID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OperatorWorkstations_WorkStations_WorkStationId",
                        column: x => x.WorkStationId,
                        principalTable: "WorkStations",
                        principalColumn: "WorkStationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Operators",
                columns: new[] { "OperatorID", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 3494, "Adam", "Macdonald" },
                    { 3481, "Richard", "Cook" },
                    { 3330, "Ray", "Stanley" },
                    { 3014, "Randy", "Anderson" },
                    { 3011, "Randal", "Conley" },
                    { 3578, "Rachel", "Bell" },
                    { 2945, "Paul", "Raycraft" },
                    { 3135, "Paul", "Moynes" },
                    { 2265, "Paul", "Lagrois" },
                    { 3670, "Nathan", "Dickinson" },
                    { 3651, "Nadine", "Owen" },
                    { 3621, "Mitchel", "Foster" },
                    { 3351, "Mindy", "Baechler" },
                    { 3160, "Michael", "Sevigny" },
                    { 3568, "Michael", "Purdy" },
                    { 3518, "Matthew", "Crumb" },
                    { 3620, "Mathew", "Richards" },
                    { 3221, "Mark", "Mcgaughey" },
                    { 3586, "Kenneth", "Jones" },
                    { 2941, "Kenny", "Herron" },
                    { 3450, "Kevin", "Cork" },
                    { 3166, "Korwyn", "Jones" },
                    { 3132, "Kristine", "Cunha" },
                    { 2981, "Kriston", "Spagnolo" },
                    { 2855, "Richard", "Toomey" },
                    { 3420, "Lee", "Linton" },
                    { 3613, "Linda", "Weatherup" },
                    { 3121, "Lisa", "Gosselin" },
                    { 2899, "Lisa", "Haley" },
                    { 3520, "Lloyd", "Weedman" },
                    { 3673, "Lori", "Robinson" },
                    { 3288, "Mark", "Bucciarelli" },
                    { 3575, "Leo", "Caissie" },
                    { 3055, "Kenneth", "Abbott" },
                    { 2887, "RonVan", "Dorp" },
                    { 3569, "Russell", "Simpson" },
                    { 3615, "Zachary", "Pandoff" },
                    { 3039, "William", "Eccleston" },
                    { 3678, "William", "Ball" },
                    { 3497, "Warren", "Dickinson" },
                    { 3601, "Tyler", "Harnden" },
                    { 3610, "Tyler", "Davey" },
                    { 3556, "Travis", "Bailey" },
                    { 3007, "Tom", "Dillabough" },
                    { 3677, "Thomas", "Hogg" },
                    { 3648, "Thomas", "Coupland" },
                    { 3577, "Terry", "Robins" },
                    { 3462, "Teresa", "Richardson" },
                    { 3326, "Tammy", "Godfrey" },
                    { 2831, "Steven", "Vandenberg" },
                    { 3064, "Steve", "Weekes" },
                    { 3676, "Stephen", "King" },
                    { 2828, "Stephen", "Ferguson" },
                    { 3480, "Sally", "Shearer" },
                    { 2929, "Sam", "Botrie" },
                    { 3155, "Scott", "Eldridge" },
                    { 3106, "Sean", "Walford" },
                    { 3478, "Shannon", "Ferguson" },
                    { 3109, "Shawn", "Lane" },
                    { 3618, "Rosemary", "Buttar" },
                    { 3459, "Shawn", "Roy" },
                    { 2850, "Shawn", "Turland" },
                    { 3463, "Shelley", "Elliott" },
                    { 3353, "Sherry", "Downes" },
                    { 3482, "Stephanie", "Huffman" },
                    { 3607, "Stephanie", "Pratt" },
                    { 3416, "Stephen", "Dawson" },
                    { 3639, "Shawn", "Sidle" },
                    { 3414, "Keith", "Tripp" },
                    { 2712, "Mike", "Lamers" },
                    { 3638, "Justin", "Vandenberg" },
                    { 3572, "Chris", "Gilmour" },
                    { 3053, "Chris", "Hall" },
                    { 3496, "Chris", "Lee" },
                    { 3495, "Chris", "Pot" },
                    { 3626, "Christopher", "Jones" },
                    { 2700, "Claude", "Alunni" },
                    { 3571, "Carmel", "Scott" },
                    { 3428, "Colleen", "Walsh" },
                    { 3119, "Cory", "Warner" },
                    { 3605, "Courtney", "Sutton" },
                    { 3611, "Dale", "Spencer" },
                    { 3655, "Daniel", "Beasley" },
                    { 3503, "Daniel", "Sonier" },
                    { 3542, "David", "Kort" },
                    { 3543, "Connor", "Turland" },
                    { 2849, "David", "Mitchell" },
                    { 3672, "Carlos", "HerreraHimeliz" },
                    { 3183, "Brian", "Davey" },
                    { 2873, "Albert", "Postma" },
                    { 3460, "Alex", "Begg" },
                    { 3679, "Alexander", "Thomas" },
                    { 3449, "Ali", "Sharifi" },
                    { 3510, "Andrew", "Scott" },
                    { 3485, "Angela", "Boudreau" },
                    { 3559, "Bryan", "Thorpe" },
                    { 3417, "Angus", "Young" },
                    { 2834, "Barry", "Alexander" },
                    { 3049, "Benson", "Downes" },
                    { 2745, "Bill", "Scott" },
                    { 3604, "Brandon", "Abbott" },
                    { 3650, "Karen", "Wright" },
                    { 3154, "Brian", "Baggaley" },
                    { 3058, "Ashley", "Mcbride" },
                    { 2980, "David", "Steves" },
                    { 3654, "Brent", "Hargreaves" },
                    { 3171, "Deanne", "Dobney" },
                    { 3668, "Hayle", "Gill" },
                    { 3579, "Ivan", "Cooper" },
                    { 3499, "James", "Young" },
                    { 3083, "Jason", "Dingman" },
                    { 3608, "Jason", "Wood" },
                    { 2972, "Jeff", "Morris" },
                    { 2756, "Gregory", "Vandenberg" },
                    { 3661, "Jennifer", "O'Connor" },
                    { 3616, "John", "Karmazyn" },
                    { 2705, "John", "Sedgwick" },
                    { 3602, "Joseph", "Dawson" },
                    { 3469, "Joshua", "Herron" },
                    { 3628, "Justin", "Graham" },
                    { 3091, "Dayrell", "Bate" },
                    { 3515, "Jesse", "Knott" },
                    { 2982, "Gregory", "Bresett" },
                    { 3635, "Jeremy", "Crawford" },
                    { 3120, "Glenn", "Bluemel" },
                    { 3013, "Don", "Chartier" },
                    { 3522, "Gordon", "Battersby" },
                    { 3175, "Donald", "Davis" },
                    { 2914, "Doug", "Beattie" },
                    { 3343, "Douglas", "Zehr" },
                    { 3059, "Dwayne", "Schwantz" },
                    { 3108, "Edward", "O'Brien" },
                    { 3687, "Dustin", "Stillman" },
                    { 3649, "Eric", "Barnes" },
                    { 3065, "Erik", "Jensen" },
                    { 3291, "Ernest", "Delong" },
                    { 3161, "Fabian", "Austin" },
                    { 3617, "Finn", "Jorgensen" },
                    { 2593, "Gary", "Long" }
                });

            migrationBuilder.InsertData(
                table: "WorkStations",
                columns: new[] { "WorkStationId", "Department", "WorkStationName" },
                values: new object[,]
                {
                    { 3502, 3, "3502 Armour" },
                    { 2802, 2, "2802 Rewinder" },
                    { 3102, 3, "3102 Extruder" },
                    { 3301, 3, "3301 Twinner" },
                    { 3302, 3, "3302 Twinner" },
                    { 3401, 3, "3401 cabler" },
                    { 3501, 3, "3501 Armour" },
                    { 3101, 3, "3101 Extruder" },
                    { 3701, 3, "3701 Jacket" },
                    { 4702, 4, "4702 Jacket" },
                    { 3801, 3, "3801 Rewinder" },
                    { 3901, 3, "3901 Tester" },
                    { 4101, 4, "4101 Extruder" },
                    { 4401, 4, "4401 Cabler" },
                    { 4701, 4, "4701 Jacket" },
                    { 4501, 4, "4501 Armour" },
                    { 4502, 4, "4502 Armour" },
                    { 2801, 2, "2801 Rewinder" },
                    { 4801, 4, "4801 Rewinder" },
                    { 3702, 3, "3702 Jacket" },
                    { 2901, 2, "Tester" },
                    { 2102, 2, "2102 Extruder" },
                    { 133, 2, "133 Armour" },
                    { 4901, 4, "4901 Tester" },
                    { 1801, 1, "1801 Buncher" },
                    { 1100, 1, "1100 Breakdown" },
                    { 1180, 1, "1180 Planetary" },
                    { 1110, 1, "1110 Intermediate" },
                    { 2101, 2, "2101 Extruder" },
                    { 2301, 2, "2301 Twinner" },
                    { 2302, 2, "2302 Twinner" },
                    { 2401, 2, "2401 Cabler" },
                    { 2503, 2, "Myrtle" },
                    { 2402, 2, "2402 Cabler" },
                    { 2404, 2, "2404 Cabler" },
                    { 2405, 2, "2405 Cabler" },
                    { 2701, 2, "2701 Jacket" },
                    { 2702, 2, "2702 Jacket" },
                    { 2703, 2, "2703 Jacket" },
                    { 163, 2, "163 Armour" },
                    { 162, 2, "162 Armour" },
                    { 77, 2, "77 Armour" },
                    { 78, 2, "78 Armour" },
                    { 2403, 2, "2403 Cabler" },
                    { 5501, 2, "5501 Armour" }
                });

            migrationBuilder.InsertData(
                table: "OperatorWorkstations",
                columns: new[] { "OperatorID", "WorkStationId" },
                values: new object[,]
                {
                    { 2745, 1801 },
                    { 2849, 3401 },
                    { 2756, 3401 },
                    { 3635, 3401 },
                    { 3616, 3401 },
                    { 3469, 3401 },
                    { 3055, 3401 },
                    { 3463, 3401 },
                    { 3478, 3302 },
                    { 3353, 3401 },
                    { 2972, 3501 },
                    { 3568, 3501 },
                    { 3460, 3701 },
                    { 3604, 3701 },
                    { 3013, 3701 },
                    { 3520, 3701 },
                    { 3621, 3701 },
                    { 3091, 3501 },
                    { 3175, 3302 },
                    { 3605, 3302 },
                    { 3571, 3302 },
                    { 3053, 2802 },
                    { 3343, 2802 },
                    { 3121, 2802 },
                    { 3618, 2802 },
                    { 3679, 3101 },
                    { 3572, 3101 },
                    { 3291, 3101 },
                    { 3613, 3101 },
                    { 3673, 3101 },
                    { 3654, 3102 },
                    { 3620, 3102 },
                    { 3610, 3102 },
                    { 3678, 3102 },
                    { 3571, 3301 },
                    { 3605, 3301 },
                    { 3175, 3301 },
                    { 3478, 3301 },
                    { 3459, 3701 },
                    { 2850, 2801 },
                    { 3543, 3702 },
                    { 3155, 3702 },
                    { 3109, 4701 },
                    { 3687, 4702 },
                    { 3522, 4702 },
                    { 3602, 4702 },
                    { 3450, 4702 },
                    { 3575, 4702 },
                    { 3495, 4501 },
                    { 2929, 4701 },
                    { 3611, 4501 },
                    { 3497, 4501 },
                    { 3495, 4502 },
                    { 3611, 4502 },
                    { 3601, 4502 },
                    { 3497, 4502 },
                    { 3428, 4801 },
                    { 3160, 4801 },
                    { 3601, 4501 },
                    { 3579, 4701 },
                    { 3510, 4701 },
                    { 3648, 4401 },
                    { 3676, 3702 },
                    { 2982, 3801 },
                    { 3515, 3801 },
                    { 3628, 3801 },
                    { 2899, 3801 },
                    { 3670, 3801 },
                    { 3577, 3801 },
                    { 3661, 3901 },
                    { 3650, 3901 },
                    { 3132, 3901 },
                    { 3496, 4101 },
                    { 3106, 4101 },
                    { 3416, 4101 },
                    { 3039, 4101 },
                    { 3503, 4401 },
                    { 3011, 4401 },
                    { 3639, 4401 },
                    { 3120, 3702 },
                    { 2981, 4901 },
                    { 2712, 2801 },
                    { 3480, 2901 },
                    { 3059, 2102 },
                    { 3288, 2102 },
                    { 3617, 2301 },
                    { 3351, 2301 },
                    { 3578, 2301 },
                    { 3617, 2302 },
                    { 3351, 2302 },
                    { 3542, 2102 },
                    { 3578, 2302 },
                    { 3608, 2401 },
                    { 3462, 2401 },
                    { 3485, 2403 },
                    { 3649, 2403 },
                    { 2593, 2403 },
                    { 3607, 2403 },
                    { 3049, 2701 },
                    { 3668, 2401 },
                    { 3615, 2101 },
                    { 3586, 2101 },
                    { 3638, 2101 },
                    { 3559, 1801 },
                    { 3499, 1801 },
                    { 3183, 1100 },
                    { 2700, 1100 },
                    { 3065, 1100 },
                    { 3166, 1100 },
                    { 3449, 1180 },
                    { 2914, 1180 },
                    { 3108, 1180 },
                    { 3014, 1180 },
                    { 2873, 1110 },
                    { 3417, 1110 },
                    { 3420, 1110 },
                    { 3677, 1110 },
                    { 3556, 1110 },
                    { 3154, 2101 },
                    { 3161, 2101 },
                    { 3655, 2701 },
                    { 3326, 2901 },
                    { 2887, 2701 },
                    { 2941, 2702 },
                    { 3414, 78 },
                    { 3481, 78 },
                    { 3482, 78 },
                    { 2831, 78 },
                    { 3494, 133 },
                    { 3672, 133 },
                    { 3569, 133 },
                    { 3626, 78 },
                    { 2828, 133 },
                    { 3672, 2503 },
                    { 3569, 2503 },
                    { 2828, 2503 },
                    { 2980, 2901 },
                    { 3171, 2901 },
                    { 2705, 2901 },
                    { 3651, 2901 },
                    { 3494, 2503 },
                    { 2831, 77 },
                    { 3482, 77 },
                    { 3481, 77 },
                    { 3221, 2702 },
                    { 2265, 2702 },
                    { 2945, 2702 },
                    { 3058, 2703 },
                    { 3119, 2703 },
                    { 3518, 2703 },
                    { 3330, 2703 },
                    { 2834, 163 },
                    { 3083, 163 },
                    { 2855, 163 },
                    { 3007, 163 },
                    { 2834, 162 },
                    { 3083, 162 },
                    { 2855, 162 },
                    { 3007, 162 },
                    { 3626, 77 },
                    { 3414, 77 },
                    { 3064, 2701 },
                    { 3135, 4901 }
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
                name: "IX_LabourReports_OperatorID",
                table: "LabourReports",
                column: "OperatorID");

            migrationBuilder.CreateIndex(
                name: "IX_NcrTags_OperatorId",
                table: "NcrTags",
                column: "OperatorId");

            migrationBuilder.CreateIndex(
                name: "IX_NcrTags_WorkStationId",
                table: "NcrTags",
                column: "WorkStationId");

            migrationBuilder.CreateIndex(
                name: "IX_OperatorWorkstations_WorkStationId",
                table: "OperatorWorkstations",
                column: "WorkStationId");
        }

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
                name: "LabourReports");

            migrationBuilder.DropTable(
                name: "NcrTags");

            migrationBuilder.DropTable(
                name: "OperatorWorkstations");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Operators");

            migrationBuilder.DropTable(
                name: "WorkStations");
        }
    }
}
