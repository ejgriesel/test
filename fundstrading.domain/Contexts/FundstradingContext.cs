using fundstrading.domain.Models;
using Microsoft.EntityFrameworkCore;

namespace fundstrading.domain.Context
{
    public partial class FundstradingContext : DbContext
    {
        public FundstradingContext()
        {
        }

        public FundstradingContext(DbContextOptions<FundstradingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Apirequest> Apirequest { get; set; }
        public virtual DbSet<Apiresponse> Apiresponse { get; set; }
        public virtual DbSet<Bank> Bank { get; set; }
        public virtual DbSet<Chain> Chain { get; set; }
        public virtual DbSet<Channel> Channel { get; set; }
        public virtual DbSet<Channeltemplate> Channeltemplate { get; set; }
        public virtual DbSet<Command> Command { get; set; }
        public virtual DbSet<Feeinstruction> Feeinstruction { get; set; }
        public virtual DbSet<Fixmessage> Fixmessage { get; set; }
        public virtual DbSet<Fixregistration> Fixregistration { get; set; }
        public virtual DbSet<Fixregistrationupdate> Fixregistrationupdate { get; set; }
        public virtual DbSet<Instruction> Instruction { get; set; }
        public virtual DbSet<Productmapping> Productmapping { get; set; }
        public virtual DbSet<Recurring> Recurring { get; set; }
        public virtual DbSet<Registration> Registration { get; set; }
        public virtual DbSet<Session> Session { get; set; }
        public virtual DbSet<Setup> Setup { get; set; }
        public virtual DbSet<Transactionreport> Transactionreport { get; set; }
        public virtual DbSet<Transactionsupdate> Transactionsupdate { get; set; }

        // Unable to generate entity type for table 'dbo.setupfeature'. Please see the warning messages.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //Configuring goes here :)
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<Apirequest>(entity =>
            {
                entity.ToTable("apirequest");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Commandid).HasColumnName("commandid");

                entity.Property(e => e.Datetime)
                    .HasColumnName("datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.Raw)
                    .HasColumnName("raw")
                    .IsUnicode(false);

                entity.HasOne(p => p.Command);
            });

            modelBuilder.Entity<Apiresponse>(entity =>
            {
                entity.ToTable("apiresponse");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Accepted).HasColumnName("accepted");

                entity.Property(e => e.Commandid).HasColumnName("commandid");

                entity.Property(e => e.Datetime)
                    .HasColumnName("datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.Instructionid)
                    .HasColumnName("instructionid")
                    .IsUnicode(false);

                entity.Property(e => e.Raw)
                    .HasColumnName("raw")
                    .IsUnicode(false);

                entity.Property(e => e.ResponseCode).HasColumnName("responseCode");

                entity.HasOne(p => p.Command);
            });

            modelBuilder.Entity<Bank>(entity =>
            {
                entity.ToTable("bank");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Channelid).HasColumnName("channelid");

                entity.Property(e => e.Graphitecode)
                    .IsRequired()
                    .HasColumnName("graphitecode")
                    .IsUnicode(false);

                entity.Property(e => e.Universalbranchcode)
                    .IsRequired()
                    .HasColumnName("universalbranchcode")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Chain>(entity =>
            {
                entity.ToTable("chain");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Commandid).HasColumnName("commandid");

                entity.Property(e => e.Datetime)
                    .HasColumnName("datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.Fqcnstring)
                    .IsRequired()
                    .HasColumnName("fqcnstring")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Channel>(entity =>
            {
                entity.ToTable("channel");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Apikey)
                    .IsRequired()
                    .HasColumnName("apikey")
                    .IsUnicode(false);

                entity.Property(e => e.Appid)
                    .IsRequired()
                    .HasColumnName("appid")
                    .IsUnicode(false);

                entity.Property(e => e.Baseurl)
                    .IsRequired()
                    .HasColumnName("baseurl")
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .IsUnicode(false);

                entity.Property(e => e.Userid)
                    .IsRequired()
                    .HasColumnName("userid")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Channeltemplate>(entity =>
            {
                entity.ToTable("channeltemplate");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Channelid).HasColumnName("channelid");

                entity.Property(e => e.Investortypeid).HasColumnName("investortypeid");

                entity.Property(e => e.Template)
                    .IsRequired()
                    .HasColumnName("template")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Command>(entity =>
            {
                entity.ToTable("command");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Datetime)
                    .HasColumnName("datetime")
                    .HasColumnType("datetime");

                entity.HasOne(p => p.Apirequest);
                entity.HasOne(p => p.Apirequest);
                entity.HasOne(p => p.Instruction);
            });

            modelBuilder.Entity<Feeinstruction>(entity =>
            {
                entity.ToTable("feeinstruction");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Applied)
                    .HasColumnName("applied")
                    .HasColumnType("datetime");

                entity.Property(e => e.Channelid).HasColumnName("channelid");

                entity.Property(e => e.Correlationid)
                    .HasColumnName("correlationid")
                    .IsUnicode(false);

                entity.Property(e => e.Datetime)
                    .HasColumnName("datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.Failed).HasColumnName("failed");

                entity.Property(e => e.Feecode)
                    .IsRequired()
                    .HasColumnName("feecode")
                    .IsUnicode(false);

                entity.Property(e => e.Feeinstructionid)
                    .HasColumnName("feeinstructionid")
                    .IsUnicode(false);

                entity.Property(e => e.Investmentcode)
                    .HasColumnName("investmentcode")
                    .IsUnicode(false);

                entity.Property(e => e.Postinstructionid)
                    .HasColumnName("postinstructionid")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Fixmessage>(entity =>
            {
                entity.ToTable("fixmessage");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Commandid).HasColumnName("commandid");

                entity.Property(e => e.Datetime)
                    .HasColumnName("datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.Incoming).HasColumnName("incoming");

                entity.Property(e => e.Messagetype)
                    .HasColumnName("messagetype")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Raw)
                    .IsRequired()
                    .HasColumnName("raw")
                    .IsUnicode(false);

                entity.Property(e => e.Sessionid).HasColumnName("sessionid");
            });

            modelBuilder.Entity<Fixregistration>(entity =>
            {
                entity.ToTable("fixregistration");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Commandid).HasColumnName("commandid");

                entity.Property(e => e.Datetime)
                    .HasColumnName("datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.Error)
                    .HasColumnName("error")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Haserror)
                    .HasColumnName("haserror")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Instructionid)
                    .HasColumnName("instructionid")
                    .IsUnicode(false);

                entity.Property(e => e.Investorcode)
                    .HasColumnName("investorcode")
                    .IsUnicode(false);

                entity.Property(e => e.Pending).HasColumnName("pending");

                entity.Property(e => e.Registid)
                    .IsRequired()
                    .HasColumnName("registid")
                    .IsUnicode(false);

                entity.Property(e => e.Registrefid)
                    .HasColumnName("registrefid")
                    .IsUnicode(false);

                entity.Property(e => e.Reported)
                    .HasColumnName("reported")
                    .HasColumnType("datetime");

                entity.Property(e => e.Tryreport)
                    .HasColumnName("tryreport")
                    .HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<Fixregistrationupdate>(entity =>
            {
                entity.ToTable("fixregistrationupdate");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Channelid).HasColumnName("channelid");

                entity.Property(e => e.Commandid).HasColumnName("commandid");

                entity.Property(e => e.Datetime)
                    .HasColumnName("datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.Haserror).HasColumnName("haserror");

                entity.Property(e => e.Instructionid)
                    .IsRequired()
                    .HasColumnName("instructionid")
                    .IsUnicode(false);

                entity.Property(e => e.Registid)
                    .HasColumnName("registid")
                    .IsUnicode(false);

                entity.Property(e => e.Registrefid)
                    .HasColumnName("registrefid")
                    .IsUnicode(false);

                entity.Property(e => e.Reported)
                    .HasColumnName("reported")
                    .HasColumnType("datetime");

                entity.Property(e => e.Sessionid).HasColumnName("sessionid");

                entity.Property(e => e.Tryreport)
                    .IsRequired()
                    .HasColumnName("tryreport")
                    .HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<Instruction>(entity =>
            {
                entity.ToTable("instruction");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Channelid).HasColumnName("channelid");

                entity.Property(e => e.Commandid).HasColumnName("commandid");

                entity.Property(e => e.Datetime)
                    .HasColumnName("datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.Instancestatus).HasColumnName("instancestatus");

                entity.Property(e => e.Instructionid)
                    .IsRequired()
                    .HasColumnName("instructionid")
                    .IsUnicode(false);

                entity.Property(e => e.Instructiontype)
                    .IsRequired()
                    .HasColumnName("instructiontype")
                    .IsUnicode(false);

                entity.Property(e => e.Recurring).HasColumnName("recurring");

                entity.Property(e => e.Reported)
                    .HasColumnName("reported")
                    .HasColumnType("datetime");

                entity.HasOne(p => p.Command);
                entity.HasOne(p => p.Channel);
            });

            modelBuilder.Entity<Productmapping>(entity =>
            {
                entity.ToTable("productmapping");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Channelid).HasColumnName("channelid");

                entity.Property(e => e.Incoming)
                    .IsRequired()
                    .HasColumnName("incoming")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Outgoing)
                    .IsRequired()
                    .HasColumnName("outgoing")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Channel)
                    .WithMany(p => p.Productmapping)
                    .HasForeignKey(d => d.Channelid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_productmapping_channelid_channel_id");
            });

            modelBuilder.Entity<Recurring>(entity =>
            {
                entity.ToTable("recurring");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Cancelid).HasColumnName("cancelid");

                entity.Property(e => e.Channelid).HasColumnName("channelid");

                entity.Property(e => e.Datetime)
                    .HasColumnName("datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.Enddate)
                    .HasColumnName("enddate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Graphitecode)
                    .IsRequired()
                    .HasColumnName("graphitecode")
                    .IsUnicode(false);

                entity.Property(e => e.Recurringtype)
                    .IsRequired()
                    .HasColumnName("recurringtype")
                    .IsUnicode(false);

                entity.Property(e => e.Reported)
                    .HasColumnName("reported")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<Registration>(entity =>
            {
                entity.ToTable("registration");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Acknowledged).HasColumnName("acknowledged");

                entity.Property(e => e.Channelid).HasColumnName("channelid");

                entity.Property(e => e.Datetime)
                    .HasColumnName("datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.Haserror).HasColumnName("haserror");

                entity.Property(e => e.Instructionid)
                    .HasColumnName("instructionid")
                    .IsUnicode(false);

                entity.Property(e => e.Investorcode)
                    .HasColumnName("investorcode")
                    .IsUnicode(false);

                entity.Property(e => e.Iosaccount)
                    .IsRequired()
                    .HasColumnName("iosaccount")
                    .IsUnicode(false);

                entity.Property(e => e.Pending).HasColumnName("pending");

                entity.Property(e => e.Reported)
                    .HasColumnName("reported")
                    .HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasDefaultValueSql("((-1))");

                entity.Property(e => e.Tryreport)
                    .IsRequired()
                    .HasColumnName("tryreport")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Xml)
                    .IsRequired()
                    .HasColumnName("xml")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Session>(entity =>
            {
                entity.ToTable("session");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Beginstring)
                    .IsRequired()
                    .HasColumnName("beginstring")
                    .IsUnicode(false);

                entity.Property(e => e.Channelid).HasColumnName("channelid");

                entity.Property(e => e.Onbehalfofcompid)
                    .HasColumnName("onbehalfofcompid")
                    .IsUnicode(false);

                entity.Property(e => e.Roe)
                    .IsRequired()
                    .HasColumnName("roe")
                    .IsUnicode(false);

                entity.Property(e => e.Sendercompid)
                    .IsRequired()
                    .HasColumnName("sendercompid")
                    .IsUnicode(false);

                entity.Property(e => e.Targetcompid)
                    .IsRequired()
                    .HasColumnName("targetcompid")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Setup>(entity =>
            {
                entity.ToTable("setup");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Channelid).HasColumnName("channelid");

                entity.Property(e => e.Sessionid).HasColumnName("sessionid");
            });

            modelBuilder.Entity<Transactionreport>(entity =>
            {
                entity.ToTable("transactionreport");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Channelid).HasColumnName("channelid");

                entity.Property(e => e.Processed)
                    .HasColumnName("processed")
                    .HasColumnType("datetime");

                entity.Property(e => e.Reported)
                    .HasColumnName("reported")
                    .HasColumnType("datetime");

                entity.Property(e => e.Transactionid)
                    .HasColumnName("transactionid")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Transactionsupdate>(entity =>
            {
                entity.ToTable("transactionsupdate");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Commandid).HasColumnName("commandid");

                entity.Property(e => e.Datetime)
                    .HasColumnName("datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.Newcommandid).HasColumnName("newcommandid");

                entity.Property(e => e.Originalcommandid).HasColumnName("originalcommandid");

                entity.Property(e => e.Raw)
                    .IsRequired()
                    .HasColumnName("raw")
                    .IsUnicode(false);

                entity.Property(e => e.Sessionid).HasColumnName("sessionid");
            });
        }
    }
}
