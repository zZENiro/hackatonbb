using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace hackatonbb.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Cost = table.Column<decimal>(type: "decimal(65,30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "creditCardProfiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    INN = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    SNILS = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    MobilePhone = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_creditCardProfiles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EventLevels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventLevels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EventRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Faculties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faculties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Spheres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spheres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Abiturients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    VkId = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    CreditCardProfileId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Secondname = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    PasswordHash = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Login = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Thirdname = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Abiturients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Abiturients_creditCardProfiles_CreditCardProfileId",
                        column: x => x.CreditCardProfileId,
                        principalTable: "creditCardProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Guests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Login = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    PasswordHash = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Name = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Secondname = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Thirdname = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    CreditCardProfileId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Guests_creditCardProfiles_CreditCardProfileId",
                        column: x => x.CreditCardProfileId,
                        principalTable: "creditCardProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Specs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    FacultyId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Specs_Faculties_FacultyId",
                        column: x => x.FacultyId,
                        principalTable: "Faculties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Priveleges",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    SphereId = table.Column<int>(type: "int", nullable: true),
                    AbiturientId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Priveleges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Priveleges_Abiturients_AbiturientId",
                        column: x => x.AbiturientId,
                        principalTable: "Abiturients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Priveleges_Spheres_SphereId",
                        column: x => x.SphereId,
                        principalTable: "Spheres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GuestsCources",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    GuestId = table.Column<int>(type: "int", nullable: true),
                    CourseId = table.Column<int>(type: "int", nullable: true),
                    SubscriptionDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ExpiringDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuestsCources", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GuestsCources_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GuestsCources_Guests_GuestId",
                        column: x => x.GuestId,
                        principalTable: "Guests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    VkId = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    CreditCardProfileId = table.Column<int>(type: "int", nullable: true),
                    PasswordHash = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Login = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Name = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Secondname = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Thirdname = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    StudentNumber = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Raiting = table.Column<double>(type: "double", nullable: false),
                    IsGoodScores = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    SpecId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_creditCardProfiles_CreditCardProfileId",
                        column: x => x.CreditCardProfileId,
                        principalTable: "creditCardProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Students_Specs_SpecId",
                        column: x => x.SpecId,
                        principalTable: "Specs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Priveleges2Abiturients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AbiturientId = table.Column<int>(type: "int", nullable: true),
                    PrivelegeId = table.Column<int>(type: "int", nullable: true),
                    IsUsed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ExpireTime = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Priveleges2Abiturients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Priveleges2Abiturients_Abiturients_AbiturientId",
                        column: x => x.AbiturientId,
                        principalTable: "Abiturients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Priveleges2Abiturients_Priveleges_PrivelegeId",
                        column: x => x.PrivelegeId,
                        principalTable: "Priveleges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Achievements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ResultPlace = table.Column<int>(type: "int", nullable: false),
                    EventName = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    EventRoleId = table.Column<int>(type: "int", nullable: true),
                    EventLevelId = table.Column<int>(type: "int", nullable: true),
                    StudentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Achievements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Achievements_EventLevels_EventLevelId",
                        column: x => x.EventLevelId,
                        principalTable: "EventLevels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Achievements_EventRoles_EventRoleId",
                        column: x => x.EventRoleId,
                        principalTable: "EventRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Achievements_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Priveleges2Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    StudentId = table.Column<int>(type: "int", nullable: true),
                    PrivelegeId = table.Column<int>(type: "int", nullable: true),
                    IsUsed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ExpireDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Priveleges2Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Priveleges2Students_Priveleges_PrivelegeId",
                        column: x => x.PrivelegeId,
                        principalTable: "Priveleges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Priveleges2Students_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RaitingTimeStamps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RaitingValue = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RaitingTimeStamps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RaitingTimeStamps_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Abiturients_CreditCardProfileId",
                table: "Abiturients",
                column: "CreditCardProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Achievements_EventLevelId",
                table: "Achievements",
                column: "EventLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_Achievements_EventRoleId",
                table: "Achievements",
                column: "EventRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Achievements_StudentId",
                table: "Achievements",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Guests_CreditCardProfileId",
                table: "Guests",
                column: "CreditCardProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_GuestsCources_CourseId",
                table: "GuestsCources",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_GuestsCources_GuestId",
                table: "GuestsCources",
                column: "GuestId");

            migrationBuilder.CreateIndex(
                name: "IX_Priveleges_AbiturientId",
                table: "Priveleges",
                column: "AbiturientId");

            migrationBuilder.CreateIndex(
                name: "IX_Priveleges_SphereId",
                table: "Priveleges",
                column: "SphereId");

            migrationBuilder.CreateIndex(
                name: "IX_Priveleges2Abiturients_AbiturientId",
                table: "Priveleges2Abiturients",
                column: "AbiturientId");

            migrationBuilder.CreateIndex(
                name: "IX_Priveleges2Abiturients_PrivelegeId",
                table: "Priveleges2Abiturients",
                column: "PrivelegeId");

            migrationBuilder.CreateIndex(
                name: "IX_Priveleges2Students_PrivelegeId",
                table: "Priveleges2Students",
                column: "PrivelegeId");

            migrationBuilder.CreateIndex(
                name: "IX_Priveleges2Students_StudentId",
                table: "Priveleges2Students",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_RaitingTimeStamps_StudentId",
                table: "RaitingTimeStamps",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Specs_FacultyId",
                table: "Specs",
                column: "FacultyId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_CreditCardProfileId",
                table: "Students",
                column: "CreditCardProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_SpecId",
                table: "Students",
                column: "SpecId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Achievements");

            migrationBuilder.DropTable(
                name: "GuestsCources");

            migrationBuilder.DropTable(
                name: "Priveleges2Abiturients");

            migrationBuilder.DropTable(
                name: "Priveleges2Students");

            migrationBuilder.DropTable(
                name: "RaitingTimeStamps");

            migrationBuilder.DropTable(
                name: "EventLevels");

            migrationBuilder.DropTable(
                name: "EventRoles");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Guests");

            migrationBuilder.DropTable(
                name: "Priveleges");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Abiturients");

            migrationBuilder.DropTable(
                name: "Spheres");

            migrationBuilder.DropTable(
                name: "Specs");

            migrationBuilder.DropTable(
                name: "creditCardProfiles");

            migrationBuilder.DropTable(
                name: "Faculties");
        }
    }
}
