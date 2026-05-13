using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Champ.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    CompanyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    DateCrete = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.CompanyId);
                });

            migrationBuilder.CreateTable(
                name: "ConfirmationStatuses",
                columns: table => new
                {
                    ConfirmationStatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConfirmationStatuses", x => x.ConfirmationStatusId);
                });

            migrationBuilder.CreateTable(
                name: "EducTypes",
                columns: table => new
                {
                    EducTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EducTypes", x => x.EducTypeId);
                });

            migrationBuilder.CreateTable(
                name: "EmploymentTypes",
                columns: table => new
                {
                    EmploymentTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmploymentTypes", x => x.EmploymentTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Instituts",
                columns: table => new
                {
                    InstitutId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instituts", x => x.InstitutId);
                });

            migrationBuilder.CreateTable(
                name: "IntegrationProviders",
                columns: table => new
                {
                    IntegrationProviderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IntegrationProviders", x => x.IntegrationProviderId);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    SkillId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.SkillId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    Avatar = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    IsActice = table.Column<bool>(type: "bit", nullable: false),
                    DateRegister = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PinCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Vacancies",
                columns: table => new
                {
                    VacancyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    HasRating = table.Column<double>(type: "float", nullable: false),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SkillId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vacancies", x => x.VacancyId);
                    table.ForeignKey(
                        name: "FK_Vacancies_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Vacancies_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "SkillId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Integrations",
                columns: table => new
                {
                    IntegrationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    IntegrationProviderId = table.Column<int>(type: "int", nullable: false),
                    Login = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsConfiguration = table.Column<bool>(type: "bit", nullable: false),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Integrations", x => x.IntegrationId);
                    table.ForeignKey(
                        name: "FK_Integrations_IntegrationProviders_IntegrationProviderId",
                        column: x => x.IntegrationProviderId,
                        principalTable: "IntegrationProviders",
                        principalColumn: "IntegrationProviderId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Integrations_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Logs",
                columns: table => new
                {
                    LogId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Action = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserCreatId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.LogId);
                    table.ForeignKey(
                        name: "FK_Logs_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Notifacations",
                columns: table => new
                {
                    NotifacationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsRead = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifacations", x => x.NotifacationId);
                    table.ForeignKey(
                        name: "FK_Notifacations_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RatingHistories",
                columns: table => new
                {
                    RatingHistoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CompetenceIndex = table.Column<double>(type: "float", nullable: false),
                    TrustLevel = table.Column<double>(type: "float", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DateEdit = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RatingHistories", x => x.RatingHistoryId);
                    table.ForeignKey(
                        name: "FK_RatingHistories_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ratings",
                columns: table => new
                {
                    RatingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ComponentIndex = table.Column<double>(type: "float", nullable: false),
                    TrustLevel = table.Column<double>(type: "float", nullable: false),
                    CountAgree = table.Column<int>(type: "int", nullable: false),
                    SkillCount = table.Column<int>(type: "int", nullable: false),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ratings", x => x.RatingId);
                    table.ForeignKey(
                        name: "FK_Ratings_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Recomendations",
                columns: table => new
                {
                    RecomendationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserCreateId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recomendations", x => x.RecomendationId);
                    table.ForeignKey(
                        name: "FK_Recomendations_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RoleChangeLogs",
                columns: table => new
                {
                    RoleChangeLogId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    NewRoleId = table.Column<int>(type: "int", nullable: false),
                    DateEdit = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleChangeLogs", x => x.RoleChangeLogId);
                    table.ForeignKey(
                        name: "FK_RoleChangeLogs_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RoleChangeLogs_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ShortLists",
                columns: table => new
                {
                    ShortListId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShortLists", x => x.ShortListId);
                    table.ForeignKey(
                        name: "FK_ShortLists_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ShortLists_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserEducations",
                columns: table => new
                {
                    UserEducationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    InstitutId = table.Column<int>(type: "int", nullable: false),
                    EducTypeId = table.Column<int>(type: "int", nullable: false),
                    Speciality = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Result = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DateStart = table.Column<int>(type: "int", nullable: false),
                    DateEnd = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserEducations", x => x.UserEducationId);
                    table.ForeignKey(
                        name: "FK_UserEducations_EducTypes_EducTypeId",
                        column: x => x.EducTypeId,
                        principalTable: "EducTypes",
                        principalColumn: "EducTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserEducations_Instituts_InstitutId",
                        column: x => x.InstitutId,
                        principalTable: "Instituts",
                        principalColumn: "InstitutId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserEducations_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserExpercences",
                columns: table => new
                {
                    UserExpercenceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    EmploymentTypeId = table.Column<int>(type: "int", nullable: false),
                    Postion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    YearStart = table.Column<int>(type: "int", nullable: false),
                    YearEnd = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserExpercences", x => x.UserExpercenceId);
                    table.ForeignKey(
                        name: "FK_UserExpercences_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserExpercences_EmploymentTypes_EmploymentTypeId",
                        column: x => x.EmploymentTypeId,
                        principalTable: "EmploymentTypes",
                        principalColumn: "EmploymentTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserExpercences_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserSkills",
                columns: table => new
                {
                    UserSkillId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Userid = table.Column<int>(type: "int", nullable: false),
                    SkillId = table.Column<int>(type: "int", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    DateUp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSkills", x => x.UserSkillId);
                    table.ForeignKey(
                        name: "FK_UserSkills_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "SkillId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserSkills_Users_Userid",
                        column: x => x.Userid,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ShortListHRs",
                columns: table => new
                {
                    ShortListHRId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShortListId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    DateAdd = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShortListHRs", x => x.ShortListHRId);
                    table.ForeignKey(
                        name: "FK_ShortListHRs_ShortLists_ShortListId",
                        column: x => x.ShortListId,
                        principalTable: "ShortLists",
                        principalColumn: "ShortListId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ShortListHRs_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Confirmations",
                columns: table => new
                {
                    ConfirmationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    AppUserId = table.Column<int>(type: "int", nullable: false),
                    UserSkillId = table.Column<int>(type: "int", nullable: false),
                    UserExpercenceId = table.Column<int>(type: "int", nullable: false),
                    ConfirmationStatusId = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateApp = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Confirmations", x => x.ConfirmationId);
                    table.ForeignKey(
                        name: "FK_Confirmations_ConfirmationStatuses_ConfirmationStatusId",
                        column: x => x.ConfirmationStatusId,
                        principalTable: "ConfirmationStatuses",
                        principalColumn: "ConfirmationStatusId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Confirmations_UserExpercences_UserExpercenceId",
                        column: x => x.UserExpercenceId,
                        principalTable: "UserExpercences",
                        principalColumn: "UserExpercenceId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Confirmations_UserSkills_UserSkillId",
                        column: x => x.UserSkillId,
                        principalTable: "UserSkills",
                        principalColumn: "UserSkillId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Confirmations_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Confirmations_ConfirmationStatusId",
                table: "Confirmations",
                column: "ConfirmationStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Confirmations_UserExpercenceId",
                table: "Confirmations",
                column: "UserExpercenceId");

            migrationBuilder.CreateIndex(
                name: "IX_Confirmations_UserId",
                table: "Confirmations",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Confirmations_UserSkillId",
                table: "Confirmations",
                column: "UserSkillId");

            migrationBuilder.CreateIndex(
                name: "IX_Integrations_IntegrationProviderId",
                table: "Integrations",
                column: "IntegrationProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_Integrations_UserId",
                table: "Integrations",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Logs_UserId",
                table: "Logs",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifacations_UserId",
                table: "Notifacations",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RatingHistories_UserId",
                table: "RatingHistories",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_UserId",
                table: "Ratings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Recomendations_UserId",
                table: "Recomendations",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleChangeLogs_RoleId",
                table: "RoleChangeLogs",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleChangeLogs_UserId",
                table: "RoleChangeLogs",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ShortListHRs_ShortListId",
                table: "ShortListHRs",
                column: "ShortListId");

            migrationBuilder.CreateIndex(
                name: "IX_ShortListHRs_UserId",
                table: "ShortListHRs",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ShortLists_CompanyId",
                table: "ShortLists",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_ShortLists_UserId",
                table: "ShortLists",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserEducations_EducTypeId",
                table: "UserEducations",
                column: "EducTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_UserEducations_InstitutId",
                table: "UserEducations",
                column: "InstitutId");

            migrationBuilder.CreateIndex(
                name: "IX_UserEducations_UserId",
                table: "UserEducations",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserExpercences_CompanyId",
                table: "UserExpercences",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_UserExpercences_EmploymentTypeId",
                table: "UserExpercences",
                column: "EmploymentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_UserExpercences_UserId",
                table: "UserExpercences",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Code",
                table: "Users",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Phone",
                table: "Users",
                column: "Phone",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSkills_SkillId",
                table: "UserSkills",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSkills_Userid",
                table: "UserSkills",
                column: "Userid");

            migrationBuilder.CreateIndex(
                name: "IX_Vacancies_CompanyId",
                table: "Vacancies",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Vacancies_SkillId",
                table: "Vacancies",
                column: "SkillId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Confirmations");

            migrationBuilder.DropTable(
                name: "Integrations");

            migrationBuilder.DropTable(
                name: "Logs");

            migrationBuilder.DropTable(
                name: "Notifacations");

            migrationBuilder.DropTable(
                name: "RatingHistories");

            migrationBuilder.DropTable(
                name: "Ratings");

            migrationBuilder.DropTable(
                name: "Recomendations");

            migrationBuilder.DropTable(
                name: "RoleChangeLogs");

            migrationBuilder.DropTable(
                name: "ShortListHRs");

            migrationBuilder.DropTable(
                name: "UserEducations");

            migrationBuilder.DropTable(
                name: "Vacancies");

            migrationBuilder.DropTable(
                name: "ConfirmationStatuses");

            migrationBuilder.DropTable(
                name: "UserExpercences");

            migrationBuilder.DropTable(
                name: "UserSkills");

            migrationBuilder.DropTable(
                name: "IntegrationProviders");

            migrationBuilder.DropTable(
                name: "ShortLists");

            migrationBuilder.DropTable(
                name: "EducTypes");

            migrationBuilder.DropTable(
                name: "Instituts");

            migrationBuilder.DropTable(
                name: "EmploymentTypes");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
