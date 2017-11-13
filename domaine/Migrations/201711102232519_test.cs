namespace domaine.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo._event",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        End = c.DateTime(precision: 0),
                        Image = c.String(maxLength: 255, unicode: false),
                        city = c.String(maxLength: 255, unicode: false),
                        latidue = c.Double(),
                        longitude = c.Double(),
                        country = c.String(maxLength: 255, unicode: false),
                        street = c.String(maxLength: 255, unicode: false),
                        zipCode = c.Int(),
                        Start = c.DateTime(nullable: false, precision: 0),
                        description = c.String(maxLength: 255, unicode: false),
                        maxPlace = c.Int(),
                        name = c.String(nullable: false, maxLength: 255, unicode: false),
                        statue = c.Int(),
                        user = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.users", t => t.user)
                .Index(t => t.user);
            
            CreateTable(
                "dbo.event_invitation",
                c => new
                    {
                        eventId = c.Int(nullable: false),
                        userInvitedId = c.Int(nullable: false),
                        userInviterId = c.Int(nullable: false),
                        _event_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.eventId, t.userInvitedId, t.userInviterId })
                .ForeignKey("dbo.users", t => t.userInviterId)
                .ForeignKey("dbo.users", t => t.userInvitedId)
                .ForeignKey("dbo._event", t => t._event_id)
                .Index(t => t.userInvitedId)
                .Index(t => t.userInviterId)
                .Index(t => t._event_id);
            
            CreateTable(
                "dbo.users",
                c => new
                    {
                        id = c.Int(nullable: false),
                        city = c.String(maxLength: 255, unicode: false),
                        latidue = c.Double(),
                        longitude = c.Double(),
                        country = c.String(maxLength: 255, unicode: false),
                        street = c.String(maxLength: 255, unicode: false),
                        zipCode = c.Int(),
                        confirmationCode = c.String(maxLength: 255, unicode: false),
                        email = c.String(maxLength: 255, unicode: false),
                        firstName = c.String(maxLength: 255, unicode: false),
                        isBanned = c.Int(),
                        isConfirmed = c.Int(),
                        lastName = c.String(maxLength: 255, unicode: false),
                        login = c.String(maxLength: 255, unicode: false),
                        password = c.String(maxLength: 255, unicode: false),
                        phoneNumber = c.String(maxLength: 255, unicode: false),
                        role = c.Int(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.access_tokens",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        expiresAt = c.DateTime(precision: 0),
                        value = c.String(maxLength: 255, unicode: false),
                        user_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.users", t => t.user_id)
                .Index(t => t.user_id);
            
            CreateTable(
                "dbo.ad_area_purchase_request",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        confirmation = c.Int(),
                        end_date = c.DateTime(nullable: false, precision: 0),
                        startDate = c.DateTime(precision: 0),
                        adArea_id = c.Int(),
                        user_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.ad_area", t => t.adArea_id)
                .ForeignKey("dbo.users", t => t.user_id)
                .Index(t => t.adArea_id)
                .Index(t => t.user_id);
            
            CreateTable(
                "dbo.ad_area",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        number = c.Int(),
                        price = c.Double(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.agencies",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        description = c.String(maxLength: 255, unicode: false),
                        name = c.String(maxLength: 255, unicode: false),
                        agent_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.users", t => t.agent_id)
                .Index(t => t.agent_id);
            
            CreateTable(
                "dbo.establishments",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        DTYPE = c.String(nullable: false, maxLength: 31, unicode: false),
                        description = c.String(maxLength: 255, unicode: false),
                        name = c.String(maxLength: 255, unicode: false),
                        latidue = c.Double(),
                        longitude = c.Double(),
                        classification = c.Int(),
                        nbrLit = c.Int(),
                        nbrPers = c.Int(),
                        nomResort = c.String(maxLength: 255, unicode: false),
                        prixNuit = c.Int(),
                        nbrchambres = c.Int(),
                        nomChalet = c.String(maxLength: 255, unicode: false),
                        agency = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.agencies", t => t.agency)
                .Index(t => t.agency);
            
            CreateTable(
                "skiworld.job_offer",
                c => new
                    {
                        id = c.Int(nullable: false),
                        description = c.String(maxLength: 255, unicode: false),
                        endDate = c.DateTime(precision: 0),
                        numberOfPlaces = c.Int(),
                        salary = c.Double(),
                        startDate = c.DateTime(precision: 0),
                        validity = c.Int(),
                        agency_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.agencies", t => t.agency_id)
                .Index(t => t.agency_id);
            
            CreateTable(
                "dbo.job_apply",
                c => new
                    {
                        id = c.Int(nullable: false),
                        applicationDate = c.DateTime(precision: 0),
                        message = c.String(maxLength: 255, unicode: false),
                        offer_id = c.Int(),
                        user_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("skiworld.job_offer", t => t.offer_id)
                .ForeignKey("dbo.users", t => t.user_id)
                .Index(t => t.offer_id)
                .Index(t => t.user_id);
            
            CreateTable(
                "dbo.course_notification",
                c => new
                    {
                        id = c.Int(nullable: false),
                        msg = c.String(maxLength: 255, unicode: false),
                        course_courseID = c.Int(),
                        user_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.courses", t => t.course_courseID)
                .ForeignKey("dbo.users", t => t.user_id)
                .Index(t => t.course_courseID)
                .Index(t => t.user_id);
            
            CreateTable(
                "dbo.courses",
                c => new
                    {
                        courseID = c.Int(nullable: false, identity: true),
                        courseLevel = c.String(maxLength: 255, unicode: false),
                        courseName = c.String(maxLength: 255, unicode: false),
                        courseState = c.String(maxLength: 255, unicode: false),
                        date = c.DateTime(storeType: "date"),
                        location = c.String(maxLength: 255, unicode: false),
                        maxParticipants = c.Int(nullable: false),
                        price = c.Double(),
                        guide_id = c.Int(),
                        notification_id = c.Int(),
                    })
                .PrimaryKey(t => t.courseID)
                .ForeignKey("dbo.course_notification", t => t.notification_id)
                .ForeignKey("dbo.users", t => t.guide_id)
                .Index(t => t.guide_id)
                .Index(t => t.notification_id);
            
            CreateTable(
                "dbo.courseparticipations",
                c => new
                    {
                        courseId = c.Int(nullable: false),
                        nbrPlaces = c.Int(nullable: false),
                        userID = c.Int(nullable: false),
                        idP = c.Int(),
                    })
                .PrimaryKey(t => new { t.courseId, t.nbrPlaces, t.userID })
                .ForeignKey("dbo.courses", t => t.courseId)
                .ForeignKey("dbo.users", t => t.userID)
                .Index(t => t.courseId)
                .Index(t => t.userID);
            
            CreateTable(
                "dbo.coursereviews",
                c => new
                    {
                        courseID = c.Int(nullable: false),
                        reviewID = c.Int(nullable: false),
                        userID = c.Int(nullable: false),
                        content = c.String(maxLength: 255, unicode: false),
                        rate = c.Single(nullable: false),
                    })
                .PrimaryKey(t => new { t.courseID, t.reviewID, t.userID })
                .ForeignKey("dbo.courses", t => t.courseID)
                .ForeignKey("dbo.users", t => t.userID)
                .Index(t => t.courseID)
                .Index(t => t.userID);
            
            CreateTable(
                "dbo.offermessages",
                c => new
                    {
                        id = c.Int(nullable: false),
                        date = c.DateTime(storeType: "date"),
                        mContent = c.String(maxLength: 255, unicode: false),
                        offer_id = c.Int(),
                        user_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.offers", t => t.offer_id)
                .ForeignKey("dbo.users", t => t.user_id)
                .Index(t => t.offer_id)
                .Index(t => t.user_id);
            
            CreateTable(
                "dbo.offers",
                c => new
                    {
                        id = c.Int(nullable: false),
                        type = c.String(nullable: false, maxLength: 31, unicode: false),
                        description = c.String(maxLength: 255, unicode: false),
                        label = c.String(maxLength: 255, unicode: false),
                        price = c.Double(),
                        quantity = c.Int(),
                        endDate = c.DateTime(storeType: "date"),
                        etat = c.String(maxLength: 255, unicode: false),
                        startDate = c.DateTime(storeType: "date"),
                        typ = c.String(maxLength: 255, unicode: false),
                        difficulty = c.Int(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.offerratings",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        date = c.DateTime(precision: 0),
                        description = c.String(maxLength: 255, unicode: false),
                        value = c.Int(),
                        offer_id = c.Int(),
                        user_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.offers", t => t.offer_id)
                .ForeignKey("dbo.users", t => t.user_id)
                .Index(t => t.offer_id)
                .Index(t => t.user_id);
            
            CreateTable(
                "dbo.reservations",
                c => new
                    {
                        id = c.Int(nullable: false),
                        offer_id = c.Int(),
                        user_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.offers", t => t.offer_id)
                .ForeignKey("dbo.users", t => t.user_id)
                .Index(t => t.offer_id)
                .Index(t => t.user_id);
            
            CreateTable(
                "dbo.testlevels",
                c => new
                    {
                        idTest = c.Int(nullable: false, identity: true),
                        date = c.DateTime(storeType: "date"),
                        score = c.Int(nullable: false),
                        test_idTest = c.Int(),
                        user_id = c.Int(),
                    })
                .PrimaryKey(t => t.idTest)
                .ForeignKey("dbo.tests", t => t.test_idTest)
                .ForeignKey("dbo.users", t => t.user_id)
                .Index(t => t.test_idTest)
                .Index(t => t.user_id);
            
            CreateTable(
                "dbo.tests",
                c => new
                    {
                        idTest = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.idTest);
            
            CreateTable(
                "dbo.questions",
                c => new
                    {
                        questionID = c.Int(nullable: false, identity: true),
                        rightAnswer = c.String(maxLength: 255, unicode: false),
                        statement = c.String(maxLength: 255, unicode: false),
                        wrongAnwer1 = c.String(maxLength: 255, unicode: false),
                        wrongAnwer2 = c.String(maxLength: 255, unicode: false),
                    })
                .PrimaryKey(t => t.questionID);
            
            CreateTable(
                "dbo.user_event",
                c => new
                    {
                        User_id = c.Int(nullable: false),
                        myParticipation_id = c.Int(nullable: false),
                        myEvents_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_id, t.myParticipation_id, t.myEvents_id })
                .ForeignKey("dbo.users", t => t.User_id)
                .ForeignKey("dbo._event", t => t.myParticipation_id)
                .ForeignKey("dbo._event", t => t.myEvents_id)
                .Index(t => t.User_id)
                .Index(t => t.myParticipation_id)
                .Index(t => t.myEvents_id);
            
            CreateTable(
                "dbo.keywords",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        content = c.String(nullable: false, maxLength: 255, unicode: false),
                        event_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo._event", t => t.event_id)
                .Index(t => t.event_id);
            
            CreateTable(
                "dbo.recharging_coupon",
                c => new
                    {
                        id = c.Int(nullable: false),
                        amount = c.Int(),
                        code = c.String(maxLength: 255, unicode: false),
                        dateGenerated = c.DateTime(precision: 0),
                        isUsed = c.Boolean(storeType: "bit"),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.sellers",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        latitude = c.Double(nullable: false),
                        longitude = c.Double(nullable: false),
                        email = c.String(maxLength: 255, unicode: false),
                        name = c.String(maxLength: 255, unicode: false),
                        phoneNumber = c.String(maxLength: 255, unicode: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.event_user",
                c => new
                    {
                        users_id = c.Int(nullable: false),
                        Event_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.users_id, t.Event_id })
                .ForeignKey("dbo.users", t => t.users_id, cascadeDelete: true)
                .ForeignKey("dbo._event", t => t.Event_id, cascadeDelete: true)
                .Index(t => t.users_id)
                .Index(t => t.Event_id);
            
            CreateTable(
                "dbo.test_questions",
                c => new
                    {
                        tests_idTest = c.Int(nullable: false),
                        questions_questionID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.tests_idTest, t.questions_questionID })
                .ForeignKey("dbo.tests", t => t.tests_idTest, cascadeDelete: true)
                .ForeignKey("dbo.questions", t => t.questions_questionID, cascadeDelete: true)
                .Index(t => t.tests_idTest)
                .Index(t => t.questions_questionID);
            
            CreateTable(
                "dbo.event_keyword",
                c => new
                    {
                        Event_id = c.Int(nullable: false),
                        keyword_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Event_id, t.keyword_id })
                .ForeignKey("dbo._event", t => t.Event_id, cascadeDelete: true)
                .ForeignKey("dbo.keywords", t => t.keyword_id, cascadeDelete: true)
                .Index(t => t.Event_id)
                .Index(t => t.keyword_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.user_event", "myEvents_id", "dbo._event");
            DropForeignKey("dbo.user_event", "myParticipation_id", "dbo._event");
            DropForeignKey("dbo.event_keyword", "keyword_id", "dbo.keywords");
            DropForeignKey("dbo.event_keyword", "Event_id", "dbo._event");
            DropForeignKey("dbo.keywords", "event_id", "dbo._event");
            DropForeignKey("dbo.event_invitation", "_event_id", "dbo._event");
            DropForeignKey("dbo.user_event", "User_id", "dbo.users");
            DropForeignKey("dbo.testlevels", "user_id", "dbo.users");
            DropForeignKey("dbo.testlevels", "test_idTest", "dbo.tests");
            DropForeignKey("dbo.test_questions", "questions_questionID", "dbo.questions");
            DropForeignKey("dbo.test_questions", "tests_idTest", "dbo.tests");
            DropForeignKey("dbo.reservations", "user_id", "dbo.users");
            DropForeignKey("dbo.offerratings", "user_id", "dbo.users");
            DropForeignKey("dbo.offermessages", "user_id", "dbo.users");
            DropForeignKey("dbo.reservations", "offer_id", "dbo.offers");
            DropForeignKey("dbo.offerratings", "offer_id", "dbo.offers");
            DropForeignKey("dbo.offermessages", "offer_id", "dbo.offers");
            DropForeignKey("dbo.job_apply", "user_id", "dbo.users");
            DropForeignKey("dbo.event_user", "Event_id", "dbo._event");
            DropForeignKey("dbo.event_user", "users_id", "dbo.users");
            DropForeignKey("dbo.event_invitation", "userInvitedId", "dbo.users");
            DropForeignKey("dbo.event_invitation", "userInviterId", "dbo.users");
            DropForeignKey("dbo.courses", "guide_id", "dbo.users");
            DropForeignKey("dbo.coursereviews", "userID", "dbo.users");
            DropForeignKey("dbo.courseparticipations", "userID", "dbo.users");
            DropForeignKey("dbo.course_notification", "user_id", "dbo.users");
            DropForeignKey("dbo.courses", "notification_id", "dbo.course_notification");
            DropForeignKey("dbo.coursereviews", "courseID", "dbo.courses");
            DropForeignKey("dbo.courseparticipations", "courseId", "dbo.courses");
            DropForeignKey("dbo.course_notification", "course_courseID", "dbo.courses");
            DropForeignKey("dbo.agencies", "agent_id", "dbo.users");
            DropForeignKey("skiworld.job_offer", "agency_id", "dbo.agencies");
            DropForeignKey("dbo.job_apply", "offer_id", "skiworld.job_offer");
            DropForeignKey("dbo.establishments", "agency", "dbo.agencies");
            DropForeignKey("dbo.ad_area_purchase_request", "user_id", "dbo.users");
            DropForeignKey("dbo.ad_area_purchase_request", "adArea_id", "dbo.ad_area");
            DropForeignKey("dbo.access_tokens", "user_id", "dbo.users");
            DropForeignKey("dbo._event", "user", "dbo.users");
            DropIndex("dbo.event_keyword", new[] { "keyword_id" });
            DropIndex("dbo.event_keyword", new[] { "Event_id" });
            DropIndex("dbo.test_questions", new[] { "questions_questionID" });
            DropIndex("dbo.test_questions", new[] { "tests_idTest" });
            DropIndex("dbo.event_user", new[] { "Event_id" });
            DropIndex("dbo.event_user", new[] { "users_id" });
            DropIndex("dbo.keywords", new[] { "event_id" });
            DropIndex("dbo.user_event", new[] { "myEvents_id" });
            DropIndex("dbo.user_event", new[] { "myParticipation_id" });
            DropIndex("dbo.user_event", new[] { "User_id" });
            DropIndex("dbo.testlevels", new[] { "user_id" });
            DropIndex("dbo.testlevels", new[] { "test_idTest" });
            DropIndex("dbo.reservations", new[] { "user_id" });
            DropIndex("dbo.reservations", new[] { "offer_id" });
            DropIndex("dbo.offerratings", new[] { "user_id" });
            DropIndex("dbo.offerratings", new[] { "offer_id" });
            DropIndex("dbo.offermessages", new[] { "user_id" });
            DropIndex("dbo.offermessages", new[] { "offer_id" });
            DropIndex("dbo.coursereviews", new[] { "userID" });
            DropIndex("dbo.coursereviews", new[] { "courseID" });
            DropIndex("dbo.courseparticipations", new[] { "userID" });
            DropIndex("dbo.courseparticipations", new[] { "courseId" });
            DropIndex("dbo.courses", new[] { "notification_id" });
            DropIndex("dbo.courses", new[] { "guide_id" });
            DropIndex("dbo.course_notification", new[] { "user_id" });
            DropIndex("dbo.course_notification", new[] { "course_courseID" });
            DropIndex("dbo.job_apply", new[] { "user_id" });
            DropIndex("dbo.job_apply", new[] { "offer_id" });
            DropIndex("skiworld.job_offer", new[] { "agency_id" });
            DropIndex("dbo.establishments", new[] { "agency" });
            DropIndex("dbo.agencies", new[] { "agent_id" });
            DropIndex("dbo.ad_area_purchase_request", new[] { "user_id" });
            DropIndex("dbo.ad_area_purchase_request", new[] { "adArea_id" });
            DropIndex("dbo.access_tokens", new[] { "user_id" });
            DropIndex("dbo.event_invitation", new[] { "_event_id" });
            DropIndex("dbo.event_invitation", new[] { "userInviterId" });
            DropIndex("dbo.event_invitation", new[] { "userInvitedId" });
            DropIndex("dbo._event", new[] { "user" });
            DropTable("dbo.event_keyword");
            DropTable("dbo.test_questions");
            DropTable("dbo.event_user");
            DropTable("dbo.sellers");
            DropTable("dbo.recharging_coupon");
            DropTable("dbo.keywords");
            DropTable("dbo.user_event");
            DropTable("dbo.questions");
            DropTable("dbo.tests");
            DropTable("dbo.testlevels");
            DropTable("dbo.reservations");
            DropTable("dbo.offerratings");
            DropTable("dbo.offers");
            DropTable("dbo.offermessages");
            DropTable("dbo.coursereviews");
            DropTable("dbo.courseparticipations");
            DropTable("dbo.courses");
            DropTable("dbo.course_notification");
            DropTable("dbo.job_apply");
            DropTable("skiworld.job_offer");
            DropTable("dbo.establishments");
            DropTable("dbo.agencies");
            DropTable("dbo.ad_area");
            DropTable("dbo.ad_area_purchase_request");
            DropTable("dbo.access_tokens");
            DropTable("dbo.users");
            DropTable("dbo.event_invitation");
            DropTable("dbo._event");
        }
    }
}
