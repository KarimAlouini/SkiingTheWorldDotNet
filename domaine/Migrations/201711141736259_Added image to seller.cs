namespace domaine.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addedimagetoseller : DbMigration
    {
        public override void Up()
        {
            
            
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
                        ImageName = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.id);
            
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.products", "sousCategorieProdId", "dbo.souscategories");
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
            DropForeignKey("dbo.access_tokens", "userId", "dbo.users");
            DropForeignKey("dbo._event", "user", "dbo.users");
            DropIndex("dbo.event_keyword", new[] { "keyword_id" });
            DropIndex("dbo.event_keyword", new[] { "Event_id" });
            DropIndex("dbo.test_questions", new[] { "questions_questionID" });
            DropIndex("dbo.test_questions", new[] { "tests_idTest" });
            DropIndex("dbo.event_user", new[] { "Event_id" });
            DropIndex("dbo.event_user", new[] { "users_id" });
            DropIndex("dbo.products", new[] { "sousCategorieProdId" });
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
            DropIndex("dbo.access_tokens", new[] { "userId" });
            DropIndex("dbo.event_invitation", new[] { "_event_id" });
            DropIndex("dbo.event_invitation", new[] { "userInviterId" });
            DropIndex("dbo.event_invitation", new[] { "userInvitedId" });
            DropIndex("dbo._event", new[] { "user" });
            DropTable("dbo.event_keyword");
            DropTable("dbo.test_questions");
            DropTable("dbo.event_user");
            DropTable("dbo.sellers");
            DropTable("dbo.recharging_coupon");
            DropTable("dbo.souscategories");
            DropTable("dbo.products");
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
