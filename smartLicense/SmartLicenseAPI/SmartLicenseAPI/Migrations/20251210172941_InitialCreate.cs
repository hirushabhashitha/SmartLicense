using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SmartLicenseAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Exams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    DurationMinutes = table.Column<int>(type: "INTEGER", nullable: false),
                    TotalQuestions = table.Column<int>(type: "INTEGER", nullable: false),
                    PassingScore = table.Column<int>(type: "INTEGER", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    QuestionText = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: false),
                    Options = table.Column<string>(type: "TEXT", nullable: false),
                    CorrectAnswer = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    Category = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Points = table.Column<int>(type: "INTEGER", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExamSessions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    ExamId = table.Column<int>(type: "INTEGER", nullable: false),
                    StartedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EndedAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Score = table.Column<int>(type: "INTEGER", nullable: false),
                    TotalQuestions = table.Column<int>(type: "INTEGER", nullable: false),
                    CorrectAnswers = table.Column<int>(type: "INTEGER", nullable: false),
                    IsPassed = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsCompleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    AssignedQuestions = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamSessions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExamSessions_Exams_ExamId",
                        column: x => x.ExamId,
                        principalTable: "Exams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExamAnswers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ExamSessionId = table.Column<int>(type: "INTEGER", nullable: false),
                    QuestionId = table.Column<int>(type: "INTEGER", nullable: false),
                    SelectedAnswer = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    IsCorrect = table.Column<bool>(type: "INTEGER", nullable: false),
                    AnsweredAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamAnswers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExamAnswers_ExamSessions_ExamSessionId",
                        column: x => x.ExamSessionId,
                        principalTable: "ExamSessions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExamAnswers_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Exams",
                columns: new[] { "Id", "CreatedAt", "Description", "DurationMinutes", "IsActive", "PassingScore", "Title", "TotalQuestions" },
                values: new object[] { 1, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Theory examination for driving license", 60, true, 35, "Driving License Theory Exam", 50 });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "Category", "CorrectAnswer", "CreatedAt", "IsActive", "Options", "Points", "QuestionText" },
                values: new object[,]
                {
                    { 1, "Traffic Signs", "Stop", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, "[\"Stop\", \"Go\", \"Slow down\", \"Turn right\"]", 1, "What does a red traffic light mean?" },
                    { 2, "Road Rules", "30 km/h", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, "[\"20 km/h\", \"30 km/h\", \"40 km/h\", \"50 km/h\"]", 1, "What is the speed limit in a school zone?" },
                    { 3, "Road Rules", "Before turning or changing lanes", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, "[\"Only on highways\", \"Before turning or changing lanes\", \"Only at night\", \"Never\"]", 1, "When should you use your turn signal?" },
                    { 4, "Traffic Signs", "Stop if safe", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, "[\"Speed up\", \"Stop if safe\", \"Go\", \"Turn left\"]", 1, "What does a yellow traffic light mean?" },
                    { 5, "Road Rules", "0.08%", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, "[\"0.00%\", \"0.05%\", \"0.08%\", \"0.10%\"]", 1, "What is the legal blood alcohol limit for drivers?" },
                    { 6, "Road Rules", "Stop for pedestrians", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, "[\"Speed up\", \"Honk\", \"Stop for pedestrians\", \"Ignore it\"]", 1, "What should you do at a pedestrian crossing?" },
                    { 7, "Traffic Signs", "Come to complete stop", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, "[\"Slow down\", \"Yield\", \"Come to complete stop\", \"Go if clear\"]", 1, "What does a stop sign mean?" },
                    { 8, "Road Rules", "When safe and legal", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, "[\"On curves\", \"When safe and legal\", \"In tunnels\", \"At intersections\"]", 1, "When can you overtake another vehicle?" },
                    { 9, "Road Rules", "3 seconds", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, "[\"1 second\", \"2 seconds\", \"3 seconds\", \"5 seconds\"]", 1, "What is the minimum following distance?" },
                    { 10, "Traffic Signs", "Mandatory instruction", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, "[\"Warning\", \"Prohibition\", \"Mandatory instruction\", \"Information\"]", 1, "What does a circular blue sign indicate?" },
                    { 11, "Road Rules", "Both A and B", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, "[\"Only at night\", \"In fog and rain\", \"Both A and B\", \"Never during day\"]", 1, "When should headlights be used?" },
                    { 12, "Road Rules", "Give way to vehicles already in roundabout", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, "[\"Give way to vehicles already in roundabout\", \"Speed up\", \"Go straight\", \"Stop completely\"]", 1, "What is the correct way to enter a roundabout?" },
                    { 13, "Road Markings", "You may overtake if safe", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, "[\"No overtaking\", \"You may overtake if safe\", \"Stop\", \"Pedestrian crossing\"]", 1, "What does a broken white line mean?" },
                    { 14, "Emergency", "Pump brakes and use handbrake", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, "[\"Jump out\", \"Pump brakes and use handbrake\", \"Speed up\", \"Close eyes\"]", 1, "What should you do if your brakes fail?" },
                    { 15, "Vehicle Knowledge", "Prevent wheel lock during braking", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, "[\"Increase speed\", \"Prevent wheel lock during braking\", \"Save fuel\", \"Cool engine\"]", 1, "What is the purpose of ABS?" },
                    { 16, "Road Rules", "Before changing lanes or turning", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, "[\"Only when reversing\", \"Before changing lanes or turning\", \"Once per trip\", \"Never\"]", 1, "When should you check your mirrors?" },
                    { 17, "Traffic Signs", "Warning", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, "[\"Information\", \"Warning\", \"Mandatory\", \"Prohibition\"]", 1, "What does a triangular road sign indicate?" },
                    { 18, "Road Rules", "Turn wheels and use handbrake", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, "[\"Leave in neutral\", \"Turn wheels and use handbrake\", \"Leave engine running\", \"Park in middle of road\"]", 1, "What is the safe way to park on a hill?" },
                    { 19, "Road Markings", "No parking or overtaking", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, "[\"Parking allowed\", \"No parking or overtaking\", \"School zone\", \"Bus lane\"]", 1, "What does a double yellow line mean?" },
                    { 20, "Road Rules", "At all times by all passengers", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, "[\"Only on highways\", \"Only in front seats\", \"At all times by all passengers\", \"Only by driver\"]", 1, "When should seat belts be worn?" },
                    { 21, "Vehicle Knowledge", "Tires losing contact with wet road", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, "[\"Engine overheating\", \"Tires losing contact with wet road\", \"Brake failure\", \"Steering problem\"]", 1, "What is aquaplaning?" },
                    { 22, "Road Rules", "Stop, look, and listen", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, "[\"Speed up\", \"Stop, look, and listen\", \"Honk\", \"Ignore signals\"]", 1, "What should you do at a railway crossing?" },
                    { 23, "Traffic Signs", "Proceed in arrow direction", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, "[\"Stop\", \"Proceed in arrow direction\", \"Yield\", \"No entry\"]", 1, "What does a green arrow traffic light mean?" },
                    { 24, "Vehicle Knowledge", "Weekly or before long trips", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, "[\"Once a year\", \"Weekly or before long trips\", \"Never\", \"Only when flat\"]", 1, "How often should tire pressure be checked?" },
                    { 25, "Vehicle Knowledge", "Area not visible in mirrors", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, "[\"Area visible in mirrors\", \"Area not visible in mirrors\", \"Front windscreen\", \"Dashboard\"]", 1, "What is the blind spot?" },
                    { 26, "Road Rules", "Only in heavy fog", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, "[\"At night always\", \"Only in heavy fog\", \"In rain\", \"All the time\"]", 1, "When should fog lights be used?" },
                    { 27, "Traffic Signs", "Slow down and yield to traffic", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, "[\"Stop completely\", \"Slow down and yield to traffic\", \"Speed up\", \"No entry\"]", 1, "What does 'Give Way' sign mean?" },
                    { 28, "Road Rules", "9 and 3 o'clock", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, "[\"12 o'clock\", \"9 and 3 o'clock\", \"Bottom of wheel\", \"One hand only\"]", 1, "What is the correct position for hands on steering wheel?" },
                    { 29, "Emergency", "Hold steering firmly and slow gradually", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, "[\"Brake hard\", \"Hold steering firmly and slow gradually\", \"Accelerate\", \"Jump out\"]", 1, "What should you do if a tire blows out?" },
                    { 30, "Traffic Signs", "No entry", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, "[\"Stop\", \"No entry\", \"Give way\", \"Speed limit\"]", 1, "What does a red circle with white bar mean?" },
                    { 31, "Road Rules", "Only with hands-free device", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, "[\"Anytime\", \"Only with hands-free device\", \"At traffic lights\", \"On highways\"]", 1, "When is it legal to use a mobile phone while driving?" },
                    { 32, "Vehicle Knowledge", "Warn others of emergency or hazard", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, "[\"To look cool\", \"Warn others of emergency or hazard\", \"For parking\", \"To signal turn\"]", 1, "What is the purpose of hazard lights?" },
                    { 33, "Road Rules", "Check for traffic and cyclists", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, "[\"Open quickly\", \"Check for traffic and cyclists\", \"Honk\", \"Flash lights\"]", 1, "What should you do before opening car door?" },
                    { 34, "Traffic Signs", "Proceed with caution", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, "[\"Stop\", \"Proceed with caution\", \"Speed up\", \"Turn around\"]", 1, "What does a flashing amber light mean?" },
                    { 35, "Road Rules", "Anticipating hazards and driving safely", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, "[\"Driving aggressively\", \"Anticipating hazards and driving safely\", \"Speeding\", \"Ignoring rules\"]", 1, "What is defensive driving?" },
                    { 36, "Road Rules", "When approaching another vehicle", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, "[\"Never\", \"When approaching another vehicle\", \"Only in city\", \"Only on highways\"]", 1, "When should you dip your headlights?" },
                    { 37, "Traffic Signs", "Maximum legal speed", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, "[\"Minimum speed\", \"Maximum legal speed\", \"Recommended speed\", \"Average speed\"]", 1, "What does a speed limit sign indicate?" },
                    { 38, "Road Safety", "Human error", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, "[\"Weather\", \"Human error\", \"Road conditions\", \"Vehicle defects\"]", 1, "What is the primary cause of road accidents?" },
                    { 39, "Road Rules", "To warn others of danger", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, "[\"To greet friends\", \"To warn others of danger\", \"In traffic jams\", \"At night\"]", 1, "When should you use horn?" },
                    { 40, "Road Rules", "Slow down and check all directions", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, "[\"Speed through\", \"Slow down and check all directions\", \"Close eyes\", \"Honk continuously\"]", 1, "What is the safest way to cross an intersection?" },
                    { 41, "Emergency", "Stop, assist, and report", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, "[\"Drive away\", \"Stop, assist, and report\", \"Ignore it\", \"Take photos only\"]", 1, "What should you do in case of an accident?" },
                    { 42, "Road Markings", "Reserved lane marking", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, "[\"Bus stop\", \"Reserved lane marking\", \"Parking\", \"Speed bump\"]", 1, "What does a white diamond road marking indicate?" },
                    { 43, "Road Rules", "Look over shoulder and use mirrors", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, "[\"Use mirrors only\", \"Look over shoulder and use mirrors\", \"Close eyes\", \"Speed up\"]", 1, "What is the correct procedure for reversing?" },
                    { 44, "Road Rules", "Near pedestrian crossings", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, "[\"On open road\", \"Near pedestrian crossings\", \"On highways\", \"During daytime\"]", 1, "When is it illegal to overtake?" },
                    { 45, "Vehicle Knowledge", "Fuel, tires, lights, mirrors", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, "[\"Nothing\", \"Fuel, tires, lights, mirrors\", \"Radio\", \"Air freshener\"]", 1, "What should you check before starting a journey?" },
                    { 46, "Traffic Signs", "Stop", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, "[\"Yield\", \"Stop\", \"Warning\", \"Information\"]", 1, "What does an octagonal sign indicate?" },
                    { 47, "Road Rules", "Pull over and stop", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, "[\"Speed up\", \"Pull over and stop\", \"Follow it\", \"Block it\"]", 1, "What is the correct action when emergency vehicle approaches?" },
                    { 48, "Road Safety", "Below speed limit", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, "[\"Speed limit\", \"Below speed limit\", \"Above speed limit\", \"Maximum speed\"]", 1, "What is the safest speed in adverse weather?" },
                    { 49, "Road Safety", "For children under specified age/weight", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, "[\"Never\", \"For children under specified age/weight\", \"Only on highways\", \"Only in back seat\"]", 1, "When should child seats be used?" },
                    { 50, "Traffic Signs", "Guide, warn, and regulate traffic", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, "[\"Decoration\", \"Guide, warn, and regulate traffic\", \"For birds\", \"No purpose\"]", 1, "What is the purpose of road signs?" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExamAnswers_ExamSessionId",
                table: "ExamAnswers",
                column: "ExamSessionId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamAnswers_QuestionId",
                table: "ExamAnswers",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamSessions_ExamId",
                table: "ExamSessions",
                column: "ExamId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExamAnswers");

            migrationBuilder.DropTable(
                name: "ExamSessions");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Exams");
        }
    }
}
