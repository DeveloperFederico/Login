using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace LoginAPI.Models.DB
{
    public partial class cuestionarioContext : DbContext
    {
        public cuestionarioContext()
        {
        }

        public cuestionarioContext(DbContextOptions<cuestionarioContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Tcadministrator> tcadministrators { get; set; } = null!;
        public virtual DbSet<Tccandidate> Tccandidates { get; set; } = null!;
        public virtual DbSet<Tcjobprofile> Tcjobprofiles { get; set; } = null!;
        public virtual DbSet<Tclanguage> Tclanguages { get; set; } = null!;
        public virtual DbSet<Tcquestion> Tcquestions { get; set; } = null!;
        public virtual DbSet<Tcquestionary> Tcquestionaries { get; set; } = null!;
        public virtual DbSet<Tcquestionaryquestion> Tcquestionaryquestions { get; set; } = null!;
        public virtual DbSet<Tcquestionarystate> Tcquestionarystates { get; set; } = null!;
        public virtual DbSet<Tcquestiontype> Tcquestiontypes { get; set; } = null!;
        public virtual DbSet<Tcrangeprofessional> Tcrangeprofessionals { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost;Database=cuestionario;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tcadministrator>(entity =>
            {
                entity.HasKey(e => e.Causer);

                entity.ToTable("tcadministrator");

                entity.Property(e => e.CadateCreated)
                    .HasColumnType("datetime")
                    .HasColumnName("cadateCreated");

                entity.Property(e => e.Capassword)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("capassword");

                entity.Property(e => e.Causer)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("causer");
            });

            modelBuilder.Entity<Tccandidate>(entity =>
            {
                entity.HasKey(e => e.CcidUser)
                    .HasName("PK__tccandid__26C765C4763B6463");

                entity.ToTable("tccandidate");

                entity.Property(e => e.CcidUser).HasColumnName("CCIdUser");

                entity.Property(e => e.Ccemail)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("CCEMAIL");

                entity.Property(e => e.CclastName)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("CCLastName");

                entity.Property(e => e.Ccmobile)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CCMobile");

                entity.Property(e => e.Ccnames)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("CCNames");
            });

            modelBuilder.Entity<Tcjobprofile>(entity =>
            {
                entity.HasKey(e => e.CjpidJobProfile)
                    .HasName("PK__tcjobpro__8A98D7A6687B5564");

                entity.ToTable("tcjobprofile");

                entity.Property(e => e.CjpidJobProfile).HasColumnName("CJPIdJobProfile");

                entity.Property(e => e.CjpidLanguage).HasColumnName("CJPIdLanguage");

                entity.Property(e => e.CjpidRange).HasColumnName("CJPIdRange");

                entity.HasOne(d => d.CjpidLanguageNavigation)
                    .WithMany(p => p.Tcjobprofiles)
                    .HasForeignKey(d => d.CjpidLanguage)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("tcjobprofile_tclanguage_FK");

                entity.HasOne(d => d.CjpidRangeNavigation)
                    .WithMany(p => p.Tcjobprofiles)
                    .HasForeignKey(d => d.CjpidRange)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("tcjobprofile_tcrangeprofessional_FK");
            });

            modelBuilder.Entity<Tclanguage>(entity =>
            {
                entity.HasKey(e => e.ClidLanguage)
                    .HasName("PK__tclangua__44437AE870B4E81B");

                entity.ToTable("tclanguage");

                entity.Property(e => e.ClidLanguage).HasColumnName("CLIdLanguage");

                entity.Property(e => e.Cldescription)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CLDescription");
            });

            modelBuilder.Entity<Tcquestion>(entity =>
            {
                entity.HasKey(e => e.CqidQuestion)
                    .HasName("PK__tcquesti__4B68B3F046BCD509");

                entity.ToTable("tcquestion");

                entity.Property(e => e.CqidQuestion).HasColumnName("CQIdQuestion");

                entity.Property(e => e.Cqdescription)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("CQDescription");

                entity.Property(e => e.CqidJobProfile).HasColumnName("CQIdJobProfile");

                entity.Property(e => e.CqidTypeQuestion).HasColumnName("CQIdTypeQuestion");

                entity.HasOne(d => d.CqidJobProfileNavigation)
                    .WithMany(p => p.Tcquestions)
                    .HasForeignKey(d => d.CqidJobProfile)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("TCQuestion_tcjobprofile_FK");

                entity.HasOne(d => d.CqidTypeQuestionNavigation)
                    .WithMany(p => p.Tcquestions)
                    .HasForeignKey(d => d.CqidTypeQuestion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("TCQuestion_tcquestiontype_FK");
            });

            modelBuilder.Entity<Tcquestionary>(entity =>
            {
                entity.HasKey(e => e.CqidQuestionary)
                    .HasName("PK__tcquesti__2FCBB2A75D16F93A");

                entity.ToTable("tcquestionary");

                entity.Property(e => e.CqidQuestionary).HasColumnName("CQIdQuestionary");

                entity.Property(e => e.Cqactive).HasColumnName("CQActive");

                entity.Property(e => e.CqidUser).HasColumnName("CQIdUser");

                entity.Property(e => e.CqjpidJobProfile).HasColumnName("CQJPIdJobProfile");

                entity.Property(e => e.Cqresult)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("CQResult");

                entity.Property(e => e.Cqsid).HasColumnName("CQSId");

                entity.HasOne(d => d.CqidUserNavigation)
                    .WithMany(p => p.Tcquestionaries)
                    .HasForeignKey(d => d.CqidUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("tcquestionary_tccandidate_FK");

                entity.HasOne(d => d.CqjpidJobProfileNavigation)
                    .WithMany(p => p.Tcquestionaries)
                    .HasForeignKey(d => d.CqjpidJobProfile)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("tcquestionary_tcjobprofile_FK");

                entity.HasOne(d => d.Cqs)
                    .WithMany(p => p.Tcquestionaries)
                    .HasForeignKey(d => d.Cqsid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("tcquestionary_tcquestionarystate_FK");
            });

            modelBuilder.Entity<Tcquestionaryquestion>(entity =>
            {
                entity.HasKey(e => new { e.CqqidQuestionary, e.CqqidQuestion })
                    .HasName("PK__tcquesti__46A0B0708ECEEBF6");

                entity.ToTable("tcquestionaryquestion");

                entity.Property(e => e.CqqidQuestionary).HasColumnName("CQQIdQuestionary");

                entity.Property(e => e.CqqidQuestion).HasColumnName("CQQIdQuestion");

                entity.Property(e => e.Cqqanswer)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("CQQANSWER");

                entity.HasOne(d => d.CqqidQuestionNavigation)
                    .WithMany(p => p.Tcquestionaryquestions)
                    .HasForeignKey(d => d.CqqidQuestion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("tcquestionaryquestion_tcquestion_FK");
            });

            modelBuilder.Entity<Tcquestionarystate>(entity =>
            {
                entity.HasKey(e => e.Cqsid)
                    .HasName("PK__tcquesti__7A7AF1B7553E065B");

                entity.ToTable("tcquestionarystate");

                entity.Property(e => e.Cqsid).HasColumnName("CQSId");

                entity.Property(e => e.Cqsdescription)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CQSDescription");
            });

            modelBuilder.Entity<Tcquestiontype>(entity =>
            {
                entity.HasKey(e => e.Cqtid)
                    .HasName("PK__tcquesti__649954907ED5EA4E");

                entity.ToTable("tcquestiontype");

                entity.Property(e => e.Cqtid).HasColumnName("CQTId");

                entity.Property(e => e.Cqtdescription)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CQTDescription");
            });

            modelBuilder.Entity<Tcrangeprofessional>(entity =>
            {
                entity.HasKey(e => e.CrpidRange)
                    .HasName("PK__tcrangep__36449D475D71CA63");

                entity.ToTable("tcrangeprofessional");

                entity.Property(e => e.CrpidRange).HasColumnName("CRPIdRange");

                entity.Property(e => e.Crpdescription)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CRPDescription");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
