using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace WebApi.DataModel
{
    public partial class SchoolCrossContext : IdentityDbContext<AspNetUsers>
    {

        public SchoolCrossContext(DbContextOptions<SchoolCrossContext> options,
                                  IConfiguration configuration)
            : base(options)
        {
            this.configuration = configuration;
        }

        private readonly IConfiguration configuration;
        public virtual DbSet<AccountsTypes> AccountsTypes { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<Classes> Classes { get; set; }
        public virtual DbSet<ClassPerson> ClassPerson { get; set; }
        public virtual DbSet<CurriculumItem> CurriculumItem { get; set; }
        public virtual DbSet<CurriculumMonths> CurriculumMonths { get; set; }
        public virtual DbSet<DaysCode> DaysCode { get; set; }
        public virtual DbSet<Departments> Departments { get; set; }
        public virtual DbSet<Ectypes> Ectypes { get; set; }
        public virtual DbSet<EducationalCenters> EducationalCenters { get; set; }
        public virtual DbSet<HomeWork> HomeWork { get; set; }
        public virtual DbSet<Hwatachment> Hwatachment { get; set; }
        public virtual DbSet<Messages> Messages { get; set; }
        public virtual DbSet<MessagesTypes> MessagesTypes { get; set; }
        public virtual DbSet<MonthsCode> MonthsCode { get; set; }
        public virtual DbSet<MonthsTypeCode> MonthsTypeCode { get; set; }
        public virtual DbSet<ParentChild> ParentChild { get; set; }
        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<PersonAbsences> PersonAbsences { get; set; }
        public virtual DbSet<PraiseComplaints> PraiseComplaints { get; set; }
        public virtual DbSet<SchoolSchedule> SchoolSchedule { get; set; }
        public virtual DbSet<Settings> Settings { get; set; }
        public virtual DbSet<StudentCurriculumGrade> StudentCurriculumGrade { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(this.configuration["Database:ConnectionString"]);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountsTypes>(entity =>
            {
                entity.HasKey(e => e.AccountTypeId);

                entity.ToTable("AccountsTypes", "Core");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TypeAr)
                    .HasColumnName("Type_AR")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(128)
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId");
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey, e.UserId });

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.Property(e => e.UserId).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId");
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.Property(e => e.UserId).HasMaxLength(128);

                entity.Property(e => e.RoleId).HasMaxLength(128);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId");
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(128)
                    .ValueGeneratedNever();

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.LockoutEndDateUtc).HasColumnType("datetime");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<Classes>(entity =>
            {
                entity.HasKey(e => e.ClassId);

                entity.ToTable("Classes", "School");

                entity.Property(e => e.ClassId).HasColumnName("ClassID");

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.Guid).HasMaxLength(128);

                entity.Property(e => e.Title).HasMaxLength(1050);

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Classes)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK_Classes_Departments");

                entity.HasOne(d => d.EducationalCenter)
                    .WithMany(p => p.Classes)
                    .HasForeignKey(d => d.EducationalCenterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Classes_EducationalCenters");
            });

            modelBuilder.Entity<ClassPerson>(entity =>
            {
                entity.ToTable("ClassPerson", "School");

                entity.Property(e => e.ClassId).HasColumnName("ClassID");

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.ClassPerson)
                    .HasForeignKey(d => d.ClassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClassPerson_Classes");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.ClassPerson)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClassPerson_Person1");
            });

            modelBuilder.Entity<CurriculumItem>(entity =>
            {
                entity.ToTable("CurriculumItem", "School");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(1050);

                entity.Property(e => e.Note).HasMaxLength(1050);

                entity.HasOne(d => d.EducationalCenter)
                    .WithMany(p => p.CurriculumItem)
                    .HasForeignKey(d => d.EducationalCenterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CurriculumItem_EducationalCenters");
            });

            modelBuilder.Entity<CurriculumMonths>(entity =>
            {
                entity.ToTable("CurriculumMonths", "School");

                entity.HasOne(d => d.EducationalCenter)
                    .WithMany(p => p.CurriculumMonths)
                    .HasForeignKey(d => d.EducationalCenterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EducationCenterMonths_EducationalCenters");

                entity.HasOne(d => d.MonthCode)
                    .WithMany(p => p.CurriculumMonths)
                    .HasForeignKey(d => d.MonthCodeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EducationCenterMonths_MonthsCode");

                entity.HasOne(d => d.MonthTypeCode)
                    .WithMany(p => p.CurriculumMonths)
                    .HasForeignKey(d => d.MonthTypeCodeId)
                    .HasConstraintName("FK_EducationCenterMonths_MonthsTypeCode");
            });

            modelBuilder.Entity<DaysCode>(entity =>
            {
                entity.HasKey(e => e.DayId);

                entity.ToTable("DaysCode", "Core");

                entity.Property(e => e.DayNameAr)
                    .HasColumnName("DayName_Ar")
                    .HasMaxLength(50);

                entity.Property(e => e.DayNameEn)
                    .HasColumnName("DayName_En")
                    .HasMaxLength(50);

                entity.Property(e => e.OrderId).HasColumnName("OrderID");
            });

            modelBuilder.Entity<Departments>(entity =>
            {
                entity.HasKey(e => e.DepartmentId);

                entity.ToTable("Departments", "School");

                entity.Property(e => e.DepartmentName).HasMaxLength(1050);

                entity.HasOne(d => d.EducationalCenter)
                    .WithMany(p => p.Departments)
                    .HasForeignKey(d => d.EducationalCenterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Departments_EducationalCenters");
            });

            modelBuilder.Entity<Ectypes>(entity =>
            {
                entity.HasKey(e => e.EctypeId);

                entity.ToTable("ECtypes", "Core");

                entity.Property(e => e.EctypeId).HasColumnName("ECTypeId");

                entity.Property(e => e.TypeAr)
                    .HasColumnName("Type_Ar")
                    .HasMaxLength(250);

                entity.Property(e => e.TypeCode).HasMaxLength(50);

                entity.Property(e => e.TypeEn).HasMaxLength(250);
            });

            modelBuilder.Entity<EducationalCenters>(entity =>
            {
                entity.HasKey(e => e.EducationalCenterId);

                entity.ToTable("EducationalCenters", "School");

                entity.Property(e => e.AddressState).HasMaxLength(50);

                entity.Property(e => e.AdressCity).HasMaxLength(1050);

                entity.Property(e => e.CenterCode).HasMaxLength(50);

                entity.Property(e => e.CenterName)
                    .IsRequired()
                    .HasMaxLength(1050);

                entity.Property(e => e.Country).HasMaxLength(250);

                entity.Property(e => e.CreatedTime).HasColumnType("datetime");

                entity.Property(e => e.CreatedUser).HasMaxLength(1050);

                entity.Property(e => e.EctypeId).HasColumnName("ECTypeId");

                entity.Property(e => e.Email).HasMaxLength(1050);

                entity.Property(e => e.GuidId)
                    .HasColumnName("GuidID")
                    .HasMaxLength(128);

                entity.Property(e => e.LastModeDate).HasColumnType("datetime");

                entity.Property(e => e.Phone).HasMaxLength(50);

                entity.HasOne(d => d.Ectype)
                    .WithMany(p => p.EducationalCenters)
                    .HasForeignKey(d => d.EctypeId)
                    .HasConstraintName("FK_EducationalCenters_ECtypes");
            });

            modelBuilder.Entity<HomeWork>(entity =>
            {
                entity.ToTable("HomeWork", "School");

                entity.Property(e => e.ClassId).HasColumnName("ClassID");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Domain)
                    .HasMaxLength(1050)
                    .HasDefaultValueSql("(N'SchoolCross')");

                entity.Property(e => e.Text).IsRequired();

                entity.Property(e => e.Title).HasMaxLength(256);
            });

            modelBuilder.Entity<Hwatachment>(entity =>
            {
                entity.ToTable("HWatachment", "School");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.CreateUserId)
                    .HasColumnName("CreateUserID")
                    .HasMaxLength(1050);

                entity.Property(e => e.Domain)
                    .IsRequired()
                    .HasMaxLength(1050)
                    .HasDefaultValueSql("(N'SchoolCross')");

                entity.Property(e => e.Guid)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastModDate).HasColumnType("datetime");

                entity.Property(e => e.LastModUserId)
                    .HasColumnName("LastModUserID")
                    .HasMaxLength(50);

                entity.HasOne(d => d.Hw)
                    .WithMany(p => p.Hwatachment)
                    .HasForeignKey(d => d.HwId)
                    .HasConstraintName("FK_HWatachment_HomeWork");
            });

            modelBuilder.Entity<Messages>(entity =>
            {
                entity.HasKey(e => e.MessageId);

                entity.ToTable("Messages", "School");

                entity.Property(e => e.MessageId).ValueGeneratedOnAdd();

                entity.Property(e => e.Domain)
                    .HasMaxLength(1050)
                    .HasDefaultValueSql("(N'SchoolCross')");

                entity.Property(e => e.MessageDate).HasColumnType("datetime");

                entity.Property(e => e.MessageText).IsRequired();

                entity.Property(e => e.Title).HasMaxLength(256);

                entity.HasOne(d => d.EducationalCenter)
                    .WithMany(p => p.Messages)
                    .HasForeignKey(d => d.EducationalCenterId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Message_EducationCneter");

                entity.HasOne(d => d.FromPerson)
                    .WithMany(p => p.MessagesFromPerson)
                    .HasForeignKey(d => d.FromPersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Messages_Person");

                entity.HasOne(d => d.Message)
                    .WithOne(p => p.InverseMessage)
                    .HasForeignKey<Messages>(d => d.MessageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Messages_Messages");

                entity.HasOne(d => d.MessageType)
                    .WithMany(p => p.Messages)
                    .HasForeignKey(d => d.MessageTypeId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Messages_MessagesType");

                entity.HasOne(d => d.ToPerson)
                    .WithMany(p => p.MessagesToPerson)
                    .HasForeignKey(d => d.ToPersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Messages_Person1");
            });

            modelBuilder.Entity<MessagesTypes>(entity =>
            {
                entity.HasKey(e => e.MessageTypeId);

                entity.ToTable("MessagesTypes", "Core");

                entity.Property(e => e.Code).HasMaxLength(10);

                entity.Property(e => e.DefaultTitle).HasMaxLength(1050);

                entity.Property(e => e.Text)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TextAr)
                    .HasColumnName("Text_Ar")
                    .HasMaxLength(1050);

                entity.Property(e => e.TextEn)
                    .HasColumnName("Text_En")
                    .HasMaxLength(1050);

                entity.Property(e => e.TextFr)
                    .HasColumnName("Text_Fr")
                    .HasMaxLength(1050);
            });

            modelBuilder.Entity<MonthsCode>(entity =>
            {
                entity.HasKey(e => e.MonthCodeId);

                entity.ToTable("MonthsCode", "Core");

                entity.Property(e => e.Code).HasMaxLength(50);

                entity.Property(e => e.NameAr)
                    .IsRequired()
                    .HasColumnName("Name_Ar")
                    .HasMaxLength(50);

                entity.Property(e => e.NameEn)
                    .HasColumnName("Name_En")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<MonthsTypeCode>(entity =>
            {
                entity.HasKey(e => e.MonthTypeCodeId);

                entity.ToTable("MonthsTypeCode", "Core");

                entity.Property(e => e.MonthTypeCodeId).ValueGeneratedNever();

                entity.Property(e => e.TypeCode).HasMaxLength(10);

                entity.Property(e => e.TypeDesc)
                    .IsRequired()
                    .HasMaxLength(1050);
            });

            modelBuilder.Entity<ParentChild>(entity =>
            {
                entity.ToTable("ParentChild", "School");

                entity.Property(e => e.ParentChildId).ValueGeneratedOnAdd();

                entity.Property(e => e.CreatedDateTime).HasColumnType("datetime");

                entity.Property(e => e.CreatedUser)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastModifiedDateTime).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedUser)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.ChildPerson)
                    .WithMany(p => p.ParentChildChildPerson)
                    .HasForeignKey(d => d.ChildPersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClassPerson_2");

                entity.HasOne(d => d.ParentChildNavigation)
                    .WithOne(p => p.InverseParentChildNavigation)
                    .HasForeignKey<ParentChild>(d => d.ParentChildId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ParentChild_ParentChild");

                entity.HasOne(d => d.ParentPerson)
                    .WithMany(p => p.ParentChildParentPerson)
                    .HasForeignKey(d => d.ParentPersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClassPerson_1");
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.ToTable("Person", "School");

                entity.Property(e => e.ActivationCode).HasMaxLength(128);

                entity.Property(e => e.AddressCity).HasMaxLength(50);

                entity.Property(e => e.AddressLine1).HasMaxLength(500);

                entity.Property(e => e.AddressLine2).HasMaxLength(500);

                entity.Property(e => e.AddressState).HasMaxLength(50);

                entity.Property(e => e.AddressZip).HasMaxLength(50);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Dob)
                    .HasColumnName("DOB")
                    .HasColumnType("date");

                entity.Property(e => e.Email).HasMaxLength(1050);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.FullName)
                    .HasColumnName("Full_Name")
                    .HasMaxLength(1050);

                entity.Property(e => e.ImportRefId).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.MiddelName).HasMaxLength(50);

                entity.Property(e => e.NotificationTokenId)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.Phone).HasMaxLength(50);

                entity.Property(e => e.Title).HasMaxLength(1050);

                entity.Property(e => e.WebUserId).HasMaxLength(128);

                entity.HasOne(d => d.AccountType)
                    .WithMany(p => p.Person)
                    .HasForeignKey(d => d.AccountTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Person_AccountsTypes");

                entity.HasOne(d => d.EducationalCenter)
                    .WithMany(p => p.Person)
                    .HasForeignKey(d => d.EducationalCenterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Person_EducationalCenters");
            });

            modelBuilder.Entity<PersonAbsences>(entity =>
            {
                entity.ToTable("PersonAbsences", "School");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ClassId).HasColumnName("ClassID");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.CreateUser).HasMaxLength(250);

                entity.Property(e => e.DateAbsences).HasColumnType("datetime");

                entity.Property(e => e.LastModeUser).HasMaxLength(250);

                entity.Property(e => e.ModDate).HasColumnType("datetime");

                entity.Property(e => e.Note).HasMaxLength(2050);

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.PersonAbsences)
                    .HasForeignKey(d => d.ClassId)
                    .HasConstraintName("FK_PersonAbsences_Classes");

                entity.HasOne(d => d.EducationalCenter)
                    .WithMany(p => p.PersonAbsences)
                    .HasForeignKey(d => d.EducationalCenterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PersonAbsences_EducationalCenters");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.PersonAbsences)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PersonAbsences_Person");
            });

            modelBuilder.Entity<PraiseComplaints>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedUser).HasMaxLength(50);

                entity.Property(e => e.DateAdd).HasColumnType("date");

                entity.Property(e => e.Type).HasMaxLength(50);

                entity.Property(e => e.UserId).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.PraiseComplaints)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_DriverPraiseComplaints_AspNetUsers");
            });

            modelBuilder.Entity<SchoolSchedule>(entity =>
            {
                entity.ToTable("SchoolSchedule", "School");

                entity.Property(e => e.ClassId).HasColumnName("ClassID");

                entity.Property(e => e.ItemTime).HasColumnType("datetime");

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.SchoolSchedule)
                    .HasForeignKey(d => d.ClassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SchoolSchedule_Classes");

                entity.HasOne(d => d.CurricclumItem)
                    .WithMany(p => p.SchoolSchedule)
                    .HasForeignKey(d => d.CurricclumItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SchoolSchedule_CurriculumItem");

                entity.HasOne(d => d.Day)
                    .WithMany(p => p.SchoolSchedule)
                    .HasForeignKey(d => d.DayId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SchoolSchedule_DaysCode");

                entity.HasOne(d => d.EducationalCenter)
                    .WithMany(p => p.SchoolSchedule)
                    .HasForeignKey(d => d.EducationalCenterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SchoolSchedule_EducationalCenters");
            });

            modelBuilder.Entity<Settings>(entity =>
            {
                entity.HasKey(e => e.SettingId);

                entity.ToTable("Settings", "Core");

                entity.Property(e => e.SettingId).HasColumnName("SettingID");

                entity.Property(e => e.Lang).HasMaxLength(50);

                entity.Property(e => e.StatusId).HasColumnName("StatusID");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(128);
            });

            modelBuilder.Entity<StudentCurriculumGrade>(entity =>
            {
                entity.HasKey(e => e.StCurriculumGradeId);

                entity.ToTable("StudentCurriculumGrade", "School");

                entity.Property(e => e.PersonId).HasColumnName("PersonID");

                entity.HasOne(d => d.CurriculumItem)
                    .WithMany(p => p.StudentCurriculumGrade)
                    .HasForeignKey(d => d.CurriculumItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StudentCurriculumGrade_CurriculumItem");

                entity.HasOne(d => d.CurriculumMonth)
                    .WithMany(p => p.StudentCurriculumGrade)
                    .HasForeignKey(d => d.CurriculumMonthId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StudentCurriculumGrade_CurriculumMonths");

                entity.HasOne(d => d.EducationalCenter)
                    .WithMany(p => p.StudentCurriculumGrade)
                    .HasForeignKey(d => d.EducationalCenterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StudentCurriculumGrade_EducationalCenters");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.StudentCurriculumGrade)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StudentCurriculumGrade_Person");
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
