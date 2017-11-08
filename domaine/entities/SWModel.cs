namespace domaine.entities
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class SWModel : DbContext
    {
        public SWModel()
            : base("name=SkiWorldDataSource")
        {
        }

        public virtual DbSet<access_tokens> access_tokens { get; set; }
        public virtual DbSet<ad_area> ad_area { get; set; }
        public virtual DbSet<ad_area_purchase_request> ad_area_purchase_request { get; set; }
        public virtual DbSet<agency> agency { get; set; }
        public virtual DbSet<course_notification> course_notification { get; set; }
        public virtual DbSet<courseparticipation> courseparticipation { get; set; }
        public virtual DbSet<coursereview> coursereview { get; set; }
        public virtual DbSet<courses> courses { get; set; }
        public virtual DbSet<establishment> establishment { get; set; }
        public virtual DbSet<_event> _event { get; set; }
        public virtual DbSet<event_invitation> event_invitation { get; set; }
        public virtual DbSet<job_apply> job_apply { get; set; }
        public virtual DbSet<job_offer> job_offer { get; set; }
        public virtual DbSet<keyword> keyword { get; set; }
        public virtual DbSet<offer> offer { get; set; }
        public virtual DbSet<offermessage> offermessage { get; set; }
        public virtual DbSet<offerrating> offerrating { get; set; }
        public virtual DbSet<questions> questions { get; set; }
        public virtual DbSet<recharging_coupon> recharging_coupon { get; set; }
        public virtual DbSet<reservation> reservation { get; set; }
        public virtual DbSet<seller> seller { get; set; }
        public virtual DbSet<test> test { get; set; }
        public virtual DbSet<testlevel> testlevel { get; set; }
        public virtual DbSet<user> user { get; set; }
        public virtual DbSet<user_event> user_event { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<access_tokens>()
                .Property(e => e.value)
                .IsUnicode(false);

            modelBuilder.Entity<ad_area>()
                .HasMany(e => e.ad_area_purchase_request)
                .WithOptional(e => e.ad_area)
                .HasForeignKey(e => e.adArea_id);

            modelBuilder.Entity<agency>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<agency>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<agency>()
                .HasMany(e => e.job_offer)
                .WithOptional(e => e.agency)
                .HasForeignKey(e => e.agency_id);

            modelBuilder.Entity<agency>()
                .HasMany(e => e.establishment)
                .WithOptional(e => e.agency1)
                .HasForeignKey(e => e.agency);

            modelBuilder.Entity<course_notification>()
                .Property(e => e.msg)
                .IsUnicode(false);

            modelBuilder.Entity<course_notification>()
                .HasMany(e => e.courses1)
                .WithOptional(e => e.course_notification1)
                .HasForeignKey(e => e.notification_id);

            modelBuilder.Entity<coursereview>()
                .Property(e => e.content)
                .IsUnicode(false);

            modelBuilder.Entity<courses>()
                .Property(e => e.courseLevel)
                .IsUnicode(false);

            modelBuilder.Entity<courses>()
                .Property(e => e.courseName)
                .IsUnicode(false);

            modelBuilder.Entity<courses>()
                .Property(e => e.courseState)
                .IsUnicode(false);

            modelBuilder.Entity<courses>()
                .Property(e => e.location)
                .IsUnicode(false);

            modelBuilder.Entity<courses>()
                .HasMany(e => e.course_notification)
                .WithOptional(e => e.courses)
                .HasForeignKey(e => e.course_courseID);

            modelBuilder.Entity<courses>()
                .HasMany(e => e.courseparticipation)
                .WithRequired(e => e.courses)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<courses>()
                .HasMany(e => e.coursereview)
                .WithRequired(e => e.courses)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<establishment>()
                .Property(e => e.DTYPE)
                .IsUnicode(false);

            modelBuilder.Entity<establishment>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<establishment>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<establishment>()
                .Property(e => e.nomResort)
                .IsUnicode(false);

            modelBuilder.Entity<establishment>()
                .Property(e => e.nomChalet)
                .IsUnicode(false);

            modelBuilder.Entity<_event>()
                .Property(e => e.Image)
                .IsUnicode(false);

            modelBuilder.Entity<_event>()
                .Property(e => e.city)
                .IsUnicode(false);

            modelBuilder.Entity<_event>()
                .Property(e => e.country)
                .IsUnicode(false);

            modelBuilder.Entity<_event>()
                .Property(e => e.street)
                .IsUnicode(false);

            modelBuilder.Entity<_event>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<_event>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<_event>()
                .HasMany(e => e.event_invitation)
                .WithRequired(e => e._event)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<_event>()
                .HasMany(e => e.user_event)
                .WithRequired(e => e._event)
                .HasForeignKey(e => e.myParticipation_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<_event>()
                .HasMany(e => e.user_event1)
                .WithRequired(e => e.event1)
                .HasForeignKey(e => e.myEvents_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<_event>()
                .HasMany(e => e.keyword)
                .WithOptional(e => e._event)
                .HasForeignKey(e => e.event_id);

            modelBuilder.Entity<_event>()
                .HasMany(e => e.keyword1)
                .WithMany(e => e.event1)
                .Map(m => m.ToTable("event_keyword").MapLeftKey("Event_id"));

            modelBuilder.Entity<job_apply>()
                .Property(e => e.message)
                .IsUnicode(false);

            modelBuilder.Entity<job_offer>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<job_offer>()
                .HasMany(e => e.job_apply)
                .WithOptional(e => e.job_offer)
                .HasForeignKey(e => e.offer_id);

            modelBuilder.Entity<keyword>()
                .Property(e => e.content)
                .IsUnicode(false);

            modelBuilder.Entity<offer>()
                .Property(e => e.type)
                .IsUnicode(false);

            modelBuilder.Entity<offer>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<offer>()
                .Property(e => e.label)
                .IsUnicode(false);

            modelBuilder.Entity<offer>()
                .Property(e => e.etat)
                .IsUnicode(false);

            modelBuilder.Entity<offer>()
                .Property(e => e.typ)
                .IsUnicode(false);

            modelBuilder.Entity<offer>()
                .HasMany(e => e.reservation)
                .WithOptional(e => e.offer)
                .HasForeignKey(e => e.offer_id);

            modelBuilder.Entity<offer>()
                .HasMany(e => e.offerrating)
                .WithOptional(e => e.offer)
                .HasForeignKey(e => e.offer_id);

            modelBuilder.Entity<offer>()
                .HasMany(e => e.offermessage)
                .WithOptional(e => e.offer)
                .HasForeignKey(e => e.offer_id);

            modelBuilder.Entity<offermessage>()
                .Property(e => e.mContent)
                .IsUnicode(false);

            modelBuilder.Entity<offerrating>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<questions>()
                .Property(e => e.rightAnswer)
                .IsUnicode(false);

            modelBuilder.Entity<questions>()
                .Property(e => e.statement)
                .IsUnicode(false);

            modelBuilder.Entity<questions>()
                .Property(e => e.wrongAnwer1)
                .IsUnicode(false);

            modelBuilder.Entity<questions>()
                .Property(e => e.wrongAnwer2)
                .IsUnicode(false);

            modelBuilder.Entity<recharging_coupon>()
                .Property(e => e.code)
                .IsUnicode(false);

            modelBuilder.Entity<seller>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<seller>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<seller>()
                .Property(e => e.phoneNumber)
                .IsUnicode(false);

            modelBuilder.Entity<test>()
                .HasMany(e => e.testlevel)
                .WithOptional(e => e.test)
                .HasForeignKey(e => e.test_idTest);

            modelBuilder.Entity<test>()
                .HasMany(e => e.questions)
                .WithMany(e => e.test)
                .Map(m => m.ToTable("test_questions").MapLeftKey("tests_idTest"));

            modelBuilder.Entity<user>()
                .Property(e => e.city)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.country)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.street)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.confirmationCode)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.firstName)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.lastName)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.login)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.phoneNumber)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .HasMany(e => e.access_tokens)
                .WithRequired(e => e.user)
                .HasForeignKey(e => e.user_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<user>()
                .HasMany(e => e.ad_area_purchase_request)
                .WithOptional(e => e.user)
                .HasForeignKey(e => e.user_id);

            modelBuilder.Entity<user>()
                .HasMany(e => e.agency)
                .WithOptional(e => e.user)
                .HasForeignKey(e => e.agent_id);

            modelBuilder.Entity<user>()
                .HasMany(e => e.course_notification)
                .WithOptional(e => e.user)
                .HasForeignKey(e => e.user_id);

            modelBuilder.Entity<user>()
                .HasMany(e => e.courseparticipation)
                .WithRequired(e => e.user)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<user>()
                .HasMany(e => e.coursereview)
                .WithRequired(e => e.user)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<user>()
                .HasMany(e => e.courses)
                .WithOptional(e => e.user)
                .HasForeignKey(e => e.guide_id);

            modelBuilder.Entity<user>()
                .HasMany(e => e._event)
                .WithRequired(e => e.user1)
                .HasForeignKey(e => e.user)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<user>()
                .HasMany(e => e.event_invitation)
                .WithRequired(e => e.user)
                .HasForeignKey(e => e.userInviterId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<user>()
                .HasMany(e => e.event_invitation1)
                .WithRequired(e => e.user1)
                .HasForeignKey(e => e.userInvitedId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<user>()
                .HasMany(e => e.job_apply)
                .WithOptional(e => e.user)
                .HasForeignKey(e => e.user_id);

            modelBuilder.Entity<user>()
                .HasMany(e => e.offermessage)
                .WithOptional(e => e.user)
                .HasForeignKey(e => e.user_id);

            modelBuilder.Entity<user>()
                .HasMany(e => e.offerrating)
                .WithOptional(e => e.user)
                .HasForeignKey(e => e.user_id);

            modelBuilder.Entity<user>()
                .HasMany(e => e.reservation)
                .WithOptional(e => e.user)
                .HasForeignKey(e => e.user_id);

            modelBuilder.Entity<user>()
                .HasMany(e => e.testlevel)
                .WithOptional(e => e.user)
                .HasForeignKey(e => e.user_id);

            modelBuilder.Entity<user>()
                .HasMany(e => e.user_event)
                .WithRequired(e => e.user)
                .HasForeignKey(e => e.User_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<user>()
                .HasMany(e => e.event1)
                .WithMany(e => e.user2)
                .Map(m => m.ToTable("event_user").MapLeftKey("users_id").MapRightKey("Event_id"));
        }
    }
}
